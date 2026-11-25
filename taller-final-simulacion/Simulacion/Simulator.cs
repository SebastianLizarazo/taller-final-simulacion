using System;
using System.Collections.Generic;
using System.Linq;
using taller_final_simulacion.Modelos;

namespace taller_final_simulacion.Simulacion
{
    /// <summary>
    /// Error lanzado cuando la integración numérica produce valores no finitos
    /// (divergencia) o cuando la configuración de la simulación es inviable.
    /// </summary>
    public sealed class SimulationException : Exception
    {
        public SimulationException(string message) : base(message)
        {
        }

        public SimulationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Integrador numérico del sistema mecánico de 3 grados de libertad.
    ///
    /// Modelo (desplazamientos medidos desde el equilibrio estático, positivo hacia abajo):
    ///
    ///   m1·ÿ1 = −k1·y1 − b1·ẏ1 − k2·(y1 − y3)
    ///   m2·ÿ2 = −k4·y2 − b2·ẏ2 − b3·(ẏ2 − ẏ3)
    ///   m3·ÿ3 = F(t) − k2·(y3 − y1) − b3·(ẏ3 − ẏ2) − k3·y3
    ///
    /// Vector de estado: x = [y1, y2, y3, v1, v2, v3] con v = ẏ.
    ///
    /// Se usa Runge-Kutta de 4.º orden (RK4) porque:
    ///   - es de orden global 4 para problemas no lineales: a igual esfuerzo computacional
    ///     entrega un error mucho menor que Euler o Verlet;
    ///   - la función de derivadas es suave y Lipschitz en el tiempo (la fuerza es una
    ///     discontinuidad acotada, que afecta a la precisión local pero no a la estabilidad);
    ///   - es fácil de implementar y mantiene el orden de las muestras sin
    ///     necesidad de resolver el sistema lineal M·ÿ + C·ẏ + K·y = f de forma explícita.
    ///
    /// Para robustez frente a sistemas rígidos (constantes elásticas elevadas), el paso
    /// entre muestras se subdivide en subpasos internos cuyo tamaño no supera
    /// <see cref="MaxInternalStep"/>; de ese modo el error de truncamiento local se mantiene
    /// acotado aunque el usuario pida muy pocas muestras.
    /// </summary>
    public static class Simulator
    {
        /// <summary>Tamaño máximo del paso interno de integración (s).</summary>
        public const double MaxInternalStep = 1.0e-3;

        /// <summary>
        /// Integración del sistema con paso fijo entre muestras.
        /// </summary>
        /// <param name="parametros">Parámetros físicos y de simulación.</param>
        /// <param name="progreso">
        /// Callback opcional de progreso: recibe (muestras procesadas, total de muestras).
        /// Se invoca desde el hilo de trabajo, por lo que el llamador debe publicar el
        /// progreso en la interfaz mediante un IProgress o un Invoke al hilo de UI.
        /// </param>
        public static SimulationResult Run(SystemParameters parametros, Action<int, int>? progreso = null)
        {
            ArgumentNullException.ThrowIfNull(parametros);

            IReadOnlyList<ValidationIssue> problemas = parametros.Validate();
            if (problemas.Count > 0)
            {
                throw new SimulationException(
                    "La configuración no es válida: " + string.Join(" ", problemas.Select(p => p.Mensaje)));
            }

            int totalMuestras = parametros.SampleCount;
            double tiempoTotal = parametros.SimulationTime;
            double pasoExterno = tiempoTotal / (totalMuestras - 1);

            // Subdivisión del paso entre muestras para no perder estabilidad con sistemas rígidos.
            int subpasos = (int)Math.Ceiling(pasoExterno / MaxInternalStep);
            if (subpasos < 1)
            {
                subpasos = 1;
            }

            double pasoInterno = pasoExterno / subpasos;

            double[] tiempo = new double[totalMuestras];
            double[] fuerza = new double[totalMuestras];
            double[] y1 = new double[totalMuestras];
            double[] y2 = new double[totalMuestras];
            double[] y3 = new double[totalMuestras];
            double[] v1 = new double[totalMuestras];
            double[] v2 = new double[totalMuestras];
            double[] v3 = new double[totalMuestras];

            // Estado inicial: y(0) = 0 y ẏ(0) = 0 (condiciones iniciales nulas).
            double[] estado = new double[6];
            double[] k1 = new double[6];
            double[] k2 = new double[6];
            double[] k3 = new double[6];
            double[] k4 = new double[6];
            double[] auxiliar = new double[6];

            int saltoProgreso = Math.Max(1, totalMuestras / 100);

            for (int i = 0; i < totalMuestras; i++)
            {
                double t = i * pasoExterno;
                tiempo[i] = t;
                fuerza[i] = Fuerza(parametros, t);

                y1[i] = estado[0];
                y2[i] = estado[1];
                y3[i] = estado[2];
                v1[i] = estado[3];
                v2[i] = estado[4];
                v3[i] = estado[5];

                VerificarEstado(estado, t);

                if (i < totalMuestras - 1)
                {
                    double tActual = t;
                    for (int s = 0; s < subpasos; s++)
                    {
                        tActual = IntegrarIntervalo(parametros, tActual, pasoInterno, estado, k1, k2, k3, k4, auxiliar);
                    }
                }

                if (progreso is not null && (i % saltoProgreso == 0 || i == totalMuestras - 1))
                {
                    progreso(i + 1, totalMuestras);
                }
            }

            return new SimulationResult(tiempo, fuerza, y1, y2, y3, v1, v2, v3, pasoExterno);
        }

        /// <summary>
        /// Fuerza externa sobre m3: pulso rectangular de amplitud A entre 0 y Tf.
        /// Es el valor que se informa en la tabla de muestras (intervalo cerrado [0, Tf]).
        /// </summary>
        private static double Fuerza(SystemParameters p, double t)
        {
            if (t < 0)
            {
                return 0;
            }

            return t <= p.ForceDuration ? p.ForceAmplitude : 0;
        }

        /// <summary>
        /// Lado de la discontinuidad de la fuerza en el que se encuentra un tramo integrado.
        /// El pulso se evalúa con el valor por la izquierda en t = Tf mientras el tramo está
        /// dentro del pulso, y con el valor por la derecha una vez superado: así la etapa del
        /// RK4 que cae exactamente en la discontinuidad usa el valor que corresponde a su
        /// propio tramo y no al del vecino.
        /// </summary>
        private enum LadoDelPulso
        {
            /// <summary>Tramo dentro del pulso: 0 <= t <= Tf.</summary>
            Activo,

            /// <summary>Tramo con el pulso ya retirado: t >= Tf.</summary>
            Terminado,
        }

        /// <summary>
        /// Integración de un intervalo de tiempo, con división por evento en la
        /// discontinuidad de la fuerza (t = Tf).
        ///
        /// Un RK4 clásico no puede integrar un paso que cruza una discontinuidad: el error
        /// local es de orden h (no de orden h⁴). Por eso, si el final del intervalo cae
        /// más allá de Tf, el paso se divide en dos: el primero con la fuerza activa
        /// (etapas dentro de [t, Tf]) y el segundo con la fuerza ya retirada.
        /// </summary>
        /// <returns>El instante final del intervalo integrado.</returns>
        private static double IntegrarIntervalo(
            SystemParameters p,
            double t,
            double h,
            double[] estado,
            double[] k1,
            double[] k2,
            double[] k3,
            double[] k4,
            double[] auxiliar)
        {
            double tf = p.ForceDuration;

            if (tf > 0 && t < tf && t + h > tf)
            {
                // Primera parte: el pulso sigue activo. Su extremo derecho cae en la
                // discontinuidad, donde manda el valor por la izquierda.
                double h1 = tf - t;
                IntegrarPasoRK4(p, t, h1, LadoDelPulso.Activo, estado, k1, k2, k3, k4, auxiliar);
                t += h1;
                h -= h1;
            }

            // Segunda parte: el pulso ya terminó (o el intervalo entero está dentro del
            // pulso). En t = Tf manda el valor por la derecha de la discontinuidad.
            LadoDelPulso lado = t >= 0 && t < tf ? LadoDelPulso.Activo : LadoDelPulso.Terminado;
            IntegrarPasoRK4(p, t, h, lado, estado, k1, k2, k3, k4, auxiliar);

            return t + h;
        }

        /// <summary>
        /// Derivadas del vector de estado x = [y1, y2, y3, v1, v2, v3] en el instante t.
        /// </summary>
        private static void Derivadas(SystemParameters p, LadoDelPulso lado, double t, double[] x, double[] dx)
        {
            double y1 = x[0];
            double y2 = x[1];
            double y3 = x[2];
            double v1 = x[3];
            double v2 = x[4];
            double v3 = x[5];

            // La fuerza se evalúa en el instante de cada etapa, no una sola vez por paso.
            double fuerza = FuerzaDeEtapa(p, lado, t);

            dx[0] = v1;
            dx[1] = v2;
            dx[2] = v3;
            dx[3] = (-p.K1 * y1 - p.B1 * v1 - p.K2 * (y1 - y3)) / p.M1;
            dx[4] = (-p.K4 * y2 - p.B2 * v2 - p.B3 * (v2 - v3)) / p.M2;
            dx[5] = (fuerza - p.K2 * (y3 - y1) - p.B3 * (v3 - v2) - p.K3 * y3) / p.M3;
        }

        /// <summary>
        /// Fuerza externa en el instante de una etapa del RK4.
        /// Dentro del pulso manda la amplitud A; fuera del pulso, 0. El lado de la
        /// discontinuidad decide qué valor corresponde al instante exacto t = Tf.
        /// </summary>
        private static double FuerzaDeEtapa(SystemParameters p, LadoDelPulso lado, double t)
        {
            if (lado == LadoDelPulso.Terminado)
            {
                // Fuera del pulso (o justo a su derecha, en la discontinuidad).
                return 0;
            }

            // Dentro del pulso (o justo a su izquierda, en la discontinuidad).
            return t >= 0 && t <= p.ForceDuration ? p.ForceAmplitude : 0;
        }

        /// <summary>
        /// Un paso de Runge-Kutta de 4.º orden (RK4 clásico).
        /// Cada etapa evalúa las derivadas (y con ellas la fuerza) en su propio instante:
        /// t, t + h/2, t + h/2 y t + h.
        /// </summary>
        private static void IntegrarPasoRK4(
            SystemParameters p,
            double t,
            double h,
            LadoDelPulso lado,
            double[] x,
            double[] k1,
            double[] k2,
            double[] k3,
            double[] k4,
            double[] auxiliar)
        {
            Derivadas(p, lado, t, x, k1);

            for (int i = 0; i < 6; i++)
            {
                auxiliar[i] = x[i] + 0.5 * h * k1[i];
            }
            Derivadas(p, lado, t + 0.5 * h, auxiliar, k2);

            for (int i = 0; i < 6; i++)
            {
                auxiliar[i] = x[i] + 0.5 * h * k2[i];
            }
            Derivadas(p, lado, t + 0.5 * h, auxiliar, k3);

            for (int i = 0; i < 6; i++)
            {
                auxiliar[i] = x[i] + h * k3[i];
            }
            Derivadas(p, lado, t + h, auxiliar, k4);

            for (int i = 0; i < 6; i++)
            {
                x[i] += (h / 6.0) * (k1[i] + 2.0 * k2[i] + 2.0 * k3[i] + k4[i]);
            }
        }

        /// <summary>
        /// Detecta divergencia numérica: valores no finitos o amplitudes físicamente absurdas.
        /// </summary>
        private static void VerificarEstado(double[] estado, double t)
        {
            for (int i = 0; i < estado.Length; i++)
            {
                if (!double.IsFinite(estado[i]))
                {
                    throw new SimulationException(
                        $"La integración divergió: se obtuvo un valor no finito ({estado[i]}) en el instante t = {t:F6} s. " +
                        "Revise los parámetros (rigidez, amortiguamiento y masas).");
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(estado[i]) > 1.0e6)
                {
                    throw new SimulationException(
                        $"La integración divergió: el desplazamiento de la masa {i + 1} alcanzó un valor absurdo " +
                        $"({estado[i]:E6} m) en el instante t = {t:F6} s. Revise los parámetros.");
                }
            }
        }
    }
}
