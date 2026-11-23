using System;
using System.Collections.Generic;

namespace taller_final_simulacion.Modelos
{
    /// <summary>
    /// Análisis de los desplazamientos de una masa: máximo, mínimo y máximo absoluto,
    /// con el instante (tiempo) en el que se producen.
    /// </summary>
    /// <param name="Masa">Identificador de la masa (m1, m2 o m3).</param>
    /// <param name="ValorMaximo">Desplazamiento máximo (positivo) alcanzado, en metros.</param>
    /// <param name="TiempoMaximo">Instante en el que se alcanza el desplazamiento máximo, en segundos.</param>
    /// <param name="ValorMinimo">Desplazamiento mínimo (más negativo) alcanzado, en metros.</param>
    /// <param name="TiempoMinimo">Instante en el que se alcanza el desplazamiento mínimo, en segundos.</param>
    /// <param name="ValorMaximoAbsoluto">Mayor valor de |y(t)| alcanzado, en metros.</param>
    /// <param name="TiempoMaximoAbsoluto">Instante en el que se alcanza el máximo absoluto, en segundos.</param>
    public sealed record MassAnalysis(
        string Masa,
        double ValorMaximo,
        double TiempoMaximo,
        double ValorMinimo,
        double TiempoMinimo,
        double ValorMaximoAbsoluto,
        double TiempoMaximoAbsoluto);

    /// <summary>
    /// Resultado completo de una simulación: series temporales de fuerza, desplazamientos
    /// y velocidades, más el análisis de máximos de cada masa.
    /// </summary>
    public sealed class SimulationResult
    {
        public SimulationResult(
            double[] tiempo,
            double[] fuerza,
            double[] y1,
            double[] y2,
            double[] y3,
            double[] v1,
            double[] v2,
            double[] v3,
            double pasoTemporal)
        {
            ArgumentNullException.ThrowIfNull(tiempo);
            ArgumentNullException.ThrowIfNull(fuerza);
            ArgumentNullException.ThrowIfNull(y1);
            ArgumentNullException.ThrowIfNull(y2);
            ArgumentNullException.ThrowIfNull(y3);
            ArgumentNullException.ThrowIfNull(v1);
            ArgumentNullException.ThrowIfNull(v2);
            ArgumentNullException.ThrowIfNull(v3);

            int n = tiempo.Length;
            if (fuerza.Length != n || y1.Length != n || y2.Length != n || y3.Length != n ||
                v1.Length != n || v2.Length != n || v3.Length != n)
            {
                throw new ArgumentException("Todas las series deben tener la misma cantidad de muestras.");
            }

            Time = tiempo;
            Force = fuerza;
            Y1 = y1;
            Y2 = y2;
            Y3 = y3;
            V1 = v1;
            V2 = v2;
            V3 = v3;
            TimeStep = pasoTemporal;

            MassAnalysis[] analisis =
            {
                Analizar("m1", y1, tiempo),
                Analizar("m2", y2, tiempo),
                Analizar("m3", y3, tiempo),
            };
            Analysis = analisis;
        }

        /// <summary>Instantes de muestreo (s).</summary>
        public double[] Time { get; }

        /// <summary>Fuerza externa aplicada sobre m3 (N).</summary>
        public double[] Force { get; }

        /// <summary>Desplazamiento de m1 (m).</summary>
        public double[] Y1 { get; }

        /// <summary>Desplazamiento de m2 (m).</summary>
        public double[] Y2 { get; }

        /// <summary>Desplazamiento de m3 (m).</summary>
        public double[] Y3 { get; }

        /// <summary>Velocidad de m1 (m/s).</summary>
        public double[] V1 { get; }

        /// <summary>Velocidad de m2 (m/s).</summary>
        public double[] V2 { get; }

        /// <summary>Velocidad de m3 (m/s).</summary>
        public double[] V3 { get; }

        /// <summary>Paso temporal entre muestras (Δt = T/(N-1)).</summary>
        public double TimeStep { get; }

        /// <summary>Cantidad de muestras del resultado.</summary>
        public int SampleCount => Time.Length;

        /// <summary>Análisis de máximos, mínimo y máximo absoluto de cada masa.</summary>
        public IReadOnlyList<MassAnalysis> Analysis { get; }

        /// <summary>
        /// Calcula los extremos de una serie de desplazamientos.
        /// </summary>
        private static MassAnalysis Analizar(string masa, double[] serie, double[] tiempos)
        {
            double valorMaximo = double.NegativeInfinity;
            double tiempoMaximo = 0;
            double valorMinimo = double.PositiveInfinity;
            double tiempoMinimo = 0;
            double valorMaximoAbsoluto = 0;
            double tiempoMaximoAbsoluto = 0;

            for (int i = 0; i < serie.Length; i++)
            {
                double valor = serie[i];

                if (valor > valorMaximo)
                {
                    valorMaximo = valor;
                    tiempoMaximo = tiempos[i];
                }

                if (valor < valorMinimo)
                {
                    valorMinimo = valor;
                    tiempoMinimo = tiempos[i];
                }

                if (Math.Abs(valor) > valorMaximoAbsoluto)
                {
                    valorMaximoAbsoluto = Math.Abs(valor);
                    tiempoMaximoAbsoluto = tiempos[i];
                }
            }

            return new MassAnalysis(
                masa,
                valorMaximo,
                tiempoMaximo,
                valorMinimo,
                tiempoMinimo,
                valorMaximoAbsoluto,
                tiempoMaximoAbsoluto);
        }
    }
}
