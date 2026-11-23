using System.Collections.Generic;

namespace taller_final_simulacion.Modelos
{
    /// <summary>
    /// Problema de validación detectado sobre un parámetro del sistema.
    /// <see cref="Campo"/> identifica el campo del formulario asociado para poder
    /// marcarlo con el <see cref="System.Windows.Forms.ErrorProvider"/>.
    /// </summary>
    /// <param name="Campo">Clave lógica del campo (por ejemplo "m1", "k3", "tiempo").</param>
    /// <param name="Mensaje">Descripción legible del problema encontrado.</param>
    public sealed record ValidationIssue(string Campo, string Mensaje);

    /// <summary>
    /// Parámetros físicos y de simulación del sistema mecánico de 3 grados de libertad.
    /// Los desplazamientos se miden desde la posición de equilibrio estático
    /// (se ignora la gravedad) y el signo positivo apunta hacia abajo.
    /// </summary>
    public sealed record SystemParameters
    {
        /// <summary>Masa m1 (kg).</summary>
        public double M1 { get; init; }

        /// <summary>Masa m2 (kg).</summary>
        public double M2 { get; init; }

        /// <summary>Masa m3 (kg).</summary>
        public double M3 { get; init; }

        /// <summary>Constante elástica k1 del soporte superior a m1 (N/m).</summary>
        public double K1 { get; init; }

        /// <summary>Constante elástica k2 entre m1 y m3 (N/m).</summary>
        public double K2 { get; init; }

        /// <summary>Constante elástica k3 entre m3 y el soporte inferior (N/m).</summary>
        public double K3 { get; init; }

        /// <summary>Constante elástica k4 del soporte superior a m2 (N/m).</summary>
        public double K4 { get; init; }

        /// <summary>Coeficiente de amortiguamiento b1 en paralelo con k1 (N·s/m).</summary>
        public double B1 { get; init; }

        /// <summary>Coeficiente de amortiguamiento b2 en paralelo con k4 (N·s/m).</summary>
        public double B2 { get; init; }

        /// <summary>Coeficiente de amortiguamiento b3 entre m2 y m3 (N·s/m).</summary>
        public double B3 { get; init; }

        /// <summary>Amplitud A de la fuerza rectangular aplicada sobre m3 (N).</summary>
        public double ForceAmplitude { get; init; }

        /// <summary>Duración Tf de la fuerza rectangular (s).</summary>
        public double ForceDuration { get; init; }

        /// <summary>Tiempo total de simulación T (s).</summary>
        public double SimulationTime { get; init; }

        /// <summary>Cantidad de muestras N de la simulación.</summary>
        public int SampleCount { get; init; }

        /// <summary>Factor de escala de la animación (píxeles por metro). Sólo afecta a la visualización.</summary>
        public double AnimationScale { get; init; }

        /// <summary>Cantidad máxima de muestras admitidas (protección frente a simulaciones desmedidas).</summary>
        public const int MaxSamples = 200_000;

        /// <summary>
        /// Conjunto de valores por defecto: producen una respuesta visible y dinámica
        /// (oscilación amortiguada clara) con un pulso de fuerza sobre m3.
        /// </summary>
        public static SystemParameters Default => new()
        {
            M1 = 1.0,
            M2 = 1.0,
            M3 = 1.5,
            K1 = 120.0,
            K2 = 80.0,
            K3 = 100.0,
            K4 = 90.0,
            B1 = 2.0,
            B2 = 1.5,
            B3 = 1.0,
            ForceAmplitude = 10.0,
            ForceDuration = 1.0,
            SimulationTime = 10.0,
            SampleCount = 1000,
            AnimationScale = 100.0,
        };

        /// <summary>
        /// Valida los rangos físicos y de simulación.
        /// Devuelve la lista de problemas encontrados (vacía si todo es correcto).
        /// </summary>
        public IReadOnlyList<ValidationIssue> Validate()
        {
            List<ValidationIssue> issues = new();

            ValidarMasa(issues, "m1", M1);
            ValidarMasa(issues, "m2", M2);
            ValidarMasa(issues, "m3", M3);

            ValidarNoNegativo(issues, "k1", K1);
            ValidarNoNegativo(issues, "k2", K2);
            ValidarNoNegativo(issues, "k3", K3);
            ValidarNoNegativo(issues, "k4", K4);

            ValidarNoNegativo(issues, "b1", B1);
            ValidarNoNegativo(issues, "b2", B2);
            ValidarNoNegativo(issues, "b3", B3);

            if (!double.IsFinite(ForceAmplitude))
                issues.Add(new ValidationIssue("amplitud", "La amplitud de la fuerza debe ser un número finito."));
            else if (ForceAmplitude < 0)
                issues.Add(new ValidationIssue("amplitud", "La amplitud de la fuerza no puede ser negativa."));

            if (!double.IsFinite(ForceDuration))
                issues.Add(new ValidationIssue("duracion", "La duración de la fuerza debe ser un número finito."));
            else if (ForceDuration < 0)
                issues.Add(new ValidationIssue("duracion", "La duración de la fuerza no puede ser negativa."));

            if (!double.IsFinite(SimulationTime))
                issues.Add(new ValidationIssue("tiempo", "El tiempo de simulación debe ser un número finito."));
            else if (SimulationTime <= 0)
                issues.Add(new ValidationIssue("tiempo", "El tiempo de simulación debe ser mayor que 0 s."));

            if (SampleCount < 2)
                issues.Add(new ValidationIssue("muestras", "El número de muestras debe ser al menos 2."));
            else if (SampleCount > MaxSamples)
                issues.Add(new ValidationIssue("muestras", $"El número de muestras no puede superar {MaxSamples:N0}."));

            if (!double.IsFinite(AnimationScale))
                issues.Add(new ValidationIssue("escala", "El factor de escala debe ser un número finito."));
            else if (AnimationScale <= 0)
                issues.Add(new ValidationIssue("escala", "El factor de escala debe ser mayor que 0."));

            return issues;
        }

        /// <summary>
        /// Advertencias (no impiden simular) sobre configuraciones coherentes pero poco útiles.
        /// </summary>
        public IReadOnlyList<string> ValidateWarnings()
        {
            List<string> avisos = new();

            if (ForceDuration > SimulationTime)
                avisos.Add($"La duración de la fuerza ({ForceDuration:F3} s) supera el tiempo de simulación ({SimulationTime:F3} s): el pulso quedará truncado.");

            if (ForceAmplitude == 0)
                avisos.Add("La amplitud de la fuerza es 0: el sistema no está excitado y sólo oscila con las condiciones iniciales nulas.");

            if (K1 + K2 + K3 + K4 == 0)
                avisos.Add("Todas las constantes elásticas son 0: el sistema no tiene rigidez y no se generará respuesta.");

            if (B1 + B2 + B3 == 0)
                avisos.Add("Todos los amortiguadores son 0: la respuesta no se disipará y puede crecer de forma sostenida.");

            return avisos;
        }

        private static void ValidarMasa(List<ValidationIssue> issues, string campo, double valor)
        {
            if (!double.IsFinite(valor))
                issues.Add(new ValidationIssue(campo, $"La masa {campo} debe ser un número finito."));
            else if (valor <= 0)
                issues.Add(new ValidationIssue(campo, $"La masa {campo} debe ser mayor que 0 kg."));
        }

        private static void ValidarNoNegativo(List<ValidationIssue> issues, string campo, double valor)
        {
            if (!double.IsFinite(valor))
                issues.Add(new ValidationIssue(campo, $"El valor de {campo} debe ser un número finito (no NaN ni infinito)."));
            else if (valor < 0)
                issues.Add(new ValidationIssue(campo, $"El valor de {campo} no puede ser negativo."));
        }
    }
}
