using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using taller_final_simulacion.Controles;
using taller_final_simulacion.Modelos;
using taller_final_simulacion.Simulacion;
using Color = System.Drawing.Color;

namespace taller_final_simulacion
{
    /// <summary>
    /// Ventana principal de la simulación del sistema mecánico de 3 grados de libertad.
    ///
    /// Toda la interfaz (controles, columnas de las tablas y temporizador) está declarada
    /// en <see cref="Form1.Designer.cs"/>: este archivo sólo contiene lógica, nunca crea
    /// controles ni los agrega al formulario.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>Colores de las tres curvas de la gráfica.</summary>
        private static readonly string ColorCurvaY1 = "#1f77b4";

        private static readonly string ColorCurvaY2 = "#2ca02c";
        private static readonly string ColorCurvaY3 = "#d62728";
        private static readonly string ColorLineaTiempo = "#7f7f7f";

        /// <summary>Resultado de la última simulación (null si todavía no se simuló).</summary>
        private SimulationResult? _resultado;

        /// <summary>Parámetros de la última simulación.</summary>
        private SystemParameters? _parametros;

        /// <summary>Índice de la muestra que se está mostrando en la animación.</summary>
        private int _indiceMuestra;

        /// <summary>True mientras hay una simulación en curso.</summary>
        private bool _simulando;

        /// <summary>Curvas de desplazamiento (una por masa).</summary>
        private ScottPlot.Plottables.Scatter? _curvaY1;
        private ScottPlot.Plottables.Scatter? _curvaY2;
        private ScottPlot.Plottables.Scatter? _curvaY3;

        /// <summary>Marcadores de avance: línea vertical y puntos sobre cada curva.</summary>
        private ScottPlot.Plottables.VerticalLine? _lineaTiempo;
        private ScottPlot.Plottables.Marker? _marcadorY1;
        private ScottPlot.Plottables.Marker? _marcadorY2;
        private ScottPlot.Plottables.Marker? _marcadorY3;

        /// <summary>
        /// Instante en que arrancó la reproducción actual. Permite avanzar la animación
        /// en tiempo real: el índice de muestra se deriva del tiempo físico transcurrido
        /// y no de la cantidad de eventos de temporizador recibidos.
        /// </summary>
        private DateTime _inicioReproduccion;

        /// <summary>Texto de aviso de escala ya mostrado (evita repintados innecesarios).</summary>
        private string _avisoEscalaActual = string.Empty;

        public Form1()
        {
            InitializeComponent();

            CargarValoresPorDefecto();
            ConfigurarGrafica();
            ActualizarEstadoControles();
            ActualizarVistaAnimacion();
        }

        #region Acciones de la interfaz

        /// <summary>
        /// Simula el sistema con los parámetros actuales y refresca gráfica, tabla,
        /// análisis y animación. Puede ejecutarse tantas veces como haga falta.
        /// </summary>
        private async void btnSimular_Click(object? sender, EventArgs e)
        {
            if (_simulando)
            {
                return;
            }

            try
            {
                if (!LeerParametros(out SystemParameters parametros, out List<string> errores))
                {
                    MostrarErrores(errores);
                    return;
                }

                _simulando = true;
                ActualizarEstadoControles();

                timerAnimacion.Stop();
                lblProgreso.Text = "Simulando...";
                lblAviso.Text = string.Empty;
                progressBarSimulacion.Value = 0;

                // La integración se ejecuta en un hilo de trabajo para no bloquear la interfaz.
                IProgress<int> progreso = new Progress<int>(porcentaje =>
                {
                    progressBarSimulacion.Value = Math.Clamp(porcentaje, 0, 100);
                    lblProgreso.Text = $"Simulando... {porcentaje}%";
                });

                SimulationResult resultado = await Task.Run(() => Simulator.Run(
                    parametros,
                    (hechos, total) => progreso.Report(total == 0 ? 100 : hechos * 100 / total)));

                _parametros = parametros;
                _resultado = resultado;

                ActualizarGrafica(resultado);
                ActualizarAnalisis(resultado);
                CargarTablaMuestras(resultado);
                ReiniciarAnimacion();

                progressBarSimulacion.Value = 100;
                lblProgreso.Text = $"Simulación terminada: {resultado.SampleCount:N0} muestras, Δt = {resultado.TimeStep:F6} s.";
                lblAviso.Text = string.Join(Environment.NewLine, parametros.ValidateWarnings());
            }
            catch (Exception ex)
            {
                lblProgreso.Text = "Error en la simulación.";
                lblAviso.Text = string.Empty;
                MessageBox.Show(this, ex.Message, "Error de simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _simulando = false;
                ActualizarEstadoControles();
            }
        }

        /// <summary>Inicia o detiene la reproducción de la animación.</summary>
        private void btnReproducir_Click(object? sender, EventArgs e)
        {
            if (_resultado is null)
            {
                MessageBox.Show(this, "Primero hay que ejecutar una simulación (botón Simular).", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (timerAnimacion.Enabled)
            {
                timerAnimacion.Stop();
            }
            else
            {
                if (_indiceMuestra >= _resultado.SampleCount - 1)
                {
                    _indiceMuestra = 0;
                }

                // La reproducción avanza en tiempo real: se ancla el arranque al instante
                // físico que ya se viene mostrando, para poder reanudar desde ahí.
                _inicioReproduccion = DateTime.UtcNow - TimeSpan.FromSeconds(_indiceMuestra * _resultado.TimeStep);

                timerAnimacion.Start();
            }

            ActualizarEstadoControles();
            ActualizarVistaAnimacion();
        }

        /// <summary>Vuelve al instante inicial de la animación.</summary>
        private void btnReiniciar_Click(object? sender, EventArgs e)
        {
            timerAnimacion.Stop();
            _indiceMuestra = 0;
            _inicioReproduccion = DateTime.UtcNow;
            ActualizarEstadoControles();
            ActualizarVistaAnimacion();
        }

        /// <summary>Restituye los valores por defecto de todos los parámetros.</summary>
        private void btnRestablecer_Click(object? sender, EventArgs e)
        {
            CargarValoresPorDefecto();
            errorProvider.Clear();
            lblAviso.Text = string.Empty;
            lblProgreso.Text = "Valores por defecto restaurados. Pulse Simular para recalcular.";
            ActualizarEstadoControles();
        }

        #endregion

        #region Temporizador de la animación

        /// <summary>
        /// Avanza un paso la animación. El índice de muestra es la única fuente de verdad:
        /// la misma muestra alimenta la animación, el marcador de la gráfica y la tabla.
        /// </summary>
        private void timerAnimacion_Tick(object? sender, EventArgs e)
        {
            if (_resultado is null)
            {
                timerAnimacion.Stop();
                ActualizarEstadoControles();
                return;
            }

            // El índice se deriva del tiempo real transcurrido y no del número de eventos
            // recibidos: si un fotograma se retrasa, la animación salta a la muestra que
            // corresponde en lugar de acumular retraso (y mensajes de temporizador).
            double segundos = (DateTime.UtcNow - _inicioReproduccion).TotalSeconds;
            int objetivo = (int)(segundos / _resultado.TimeStep);

            _indiceMuestra = Math.Clamp(objetivo, 0, _resultado.SampleCount - 1);

            if (_indiceMuestra >= _resultado.SampleCount - 1)
            {
                timerAnimacion.Stop();
                ActualizarEstadoControles();
            }

            ActualizarVistaAnimacion();
        }

        #endregion

        #region Dibujo de la animación (GDI+)

        /// <summary>
        /// Dibuja el mecanismo con GDI+ sobre el panel declarado en el diseñador.
        /// </summary>
        private void panelAnimacion_Paint(object? sender, PaintEventArgs e)
        {
            double y1 = 0;
            double y2 = 0;
            double y3 = 0;

            if (_resultado is not null)
            {
                int indice = Math.Clamp(_indiceMuestra, 0, _resultado.SampleCount - 1);
                y1 = _resultado.Y1[indice];
                y2 = _resultado.Y2[indice];
                y3 = _resultado.Y3[indice];
            }

            EstadoMecanico estado = new()
            {
                Y1 = y1,
                Y2 = y2,
                Y3 = y3,
                Escala = ObtenerEscalaVisual(),
            };

            bool recortado = DibujadorMecanismo.Dibujar(e.Graphics, panelAnimacion.ClientSize, estado);

            string aviso = recortado ? "Escala excesiva: dibujo recortado" : string.Empty;
            if (aviso != _avisoEscalaActual)
            {
                _avisoEscalaActual = aviso;
                lblAvisoEscala.Text = aviso;
            }
        }

        /// <summary>
        /// Factor de escala de la animación (píxeles por metro). Sólo afecta a la
        /// visualización: nunca modifica los resultados físicos de la simulación.
        /// </summary>
        private double ObtenerEscalaVisual()
        {
            if (TryParseNumero(txtEscala.Text.Trim(), out double escala) && escala > 0)
            {
                return escala;
            }

            return _parametros?.AnimationScale ?? 100.0;
        }

        #endregion

        #region Gráfica (ScottPlot)

        /// <summary>Configura títulos y ejes de la gráfica.</summary>
        private void ConfigurarGrafica()
        {
            ScottPlot.Plot plot = graficaPlot.Plot;
            plot.Axes.Bottom.Label.Text = "Tiempo (s)";
            plot.Axes.Left.Label.Text = "Desplazamiento (m)";
            plot.Axes.Title.Label.Text = "Respuesta del sistema de 3 masas, 4 resortes y 3 amortiguadores";
            graficaPlot.Refresh();
        }

        /// <summary>
        /// Dibuja las tres curvas de desplazamiento y crea los marcadores de avance.
        /// </summary>
        private void ActualizarGrafica(SimulationResult resultado)
        {
            ScottPlot.Plot plot = graficaPlot.Plot;
            plot.Clear();

            _curvaY1 = plot.Add.Scatter(resultado.Time, resultado.Y1, ScottPlot.Color.FromHex(ColorCurvaY1));
            _curvaY1.LegendText = "y1(t)  (m1)";
            _curvaY1.LineWidth = 2f;
            _curvaY1.MarkerStyle = ScottPlot.MarkerStyle.None;

            _curvaY2 = plot.Add.Scatter(resultado.Time, resultado.Y2, ScottPlot.Color.FromHex(ColorCurvaY2));
            _curvaY2.LegendText = "y2(t)  (m2)";
            _curvaY2.LineWidth = 2f;
            _curvaY2.MarkerStyle = ScottPlot.MarkerStyle.None;

            _curvaY3 = plot.Add.Scatter(resultado.Time, resultado.Y3, ScottPlot.Color.FromHex(ColorCurvaY3));
            _curvaY3.LegendText = "y3(t)  (m3)";
            _curvaY3.LineWidth = 2f;
            _curvaY3.MarkerStyle = ScottPlot.MarkerStyle.None;

            // Marcadores de avance: línea vertical en el instante actual y puntos sobre cada curva.
            _lineaTiempo = plot.Add.VerticalLine(0, 1.5f, ScottPlot.Color.FromHex(ColorLineaTiempo), ScottPlot.LinePattern.Dashed);
            _marcadorY1 = plot.Add.Marker(0, 0, ScottPlot.MarkerShape.FilledCircle, 9f, ScottPlot.Color.FromHex(ColorCurvaY1));
            _marcadorY2 = plot.Add.Marker(0, 0, ScottPlot.MarkerShape.FilledCircle, 9f, ScottPlot.Color.FromHex(ColorCurvaY2));
            _marcadorY3 = plot.Add.Marker(0, 0, ScottPlot.MarkerShape.FilledCircle, 9f, ScottPlot.Color.FromHex(ColorCurvaY3));

            plot.Axes.Bottom.Label.Text = "Tiempo (s)";
            plot.Axes.Left.Label.Text = "Desplazamiento (m)";
            plot.Axes.Title.Label.Text = "Respuesta del sistema de 3 masas, 4 resortes y 3 amortiguadores";
            plot.ShowLegend(ScottPlot.Alignment.UpperRight);
            plot.Axes.AutoScale();

            graficaPlot.Refresh();
        }

        /// <summary>
        /// Actualiza el marcador de la gráfica para que coincida exactamente con el
        /// instante mostrado en la animación.
        /// </summary>
        private void ActualizarMarcadorGrafica(int indice)
        {
            if (_resultado is null)
            {
                return;
            }

            double t = _resultado.Time[indice];

            if (_lineaTiempo is not null)
            {
                _lineaTiempo.X = t;
            }

            if (_marcadorY1 is not null)
            {
                _marcadorY1.X = t;
                _marcadorY1.Y = _resultado.Y1[indice];
            }

            if (_marcadorY2 is not null)
            {
                _marcadorY2.X = t;
                _marcadorY2.Y = _resultado.Y2[indice];
            }

            if (_marcadorY3 is not null)
            {
                _marcadorY3.X = t;
                _marcadorY3.Y = _resultado.Y3[indice];
            }

            graficaPlot.Refresh();
        }

        #endregion

        #region Tablas

        /// <summary>
        /// Carga la tabla de muestras en modo virtual: el DataGridView pide los valores
        /// por celda (CellValueNeeded), de modo que no hay que crear un objeto por muestra.
        /// </summary>
        private void CargarTablaMuestras(SimulationResult resultado)
        {
            dgvMuestras.SuspendLayout();
            try
            {
                dgvMuestras.RowCount = resultado.SampleCount;
                dgvMuestras.ClearSelection();
            }
            finally
            {
                dgvMuestras.ResumeLayout();
            }
        }

        /// <summary>Devuelve el valor de una celda de la tabla de muestras.</summary>
        private void dgvMuestras_CellValueNeeded(object? sender, DataGridViewCellValueEventArgs e)
        {
            if (_resultado is null || e.RowIndex < 0 || e.RowIndex >= _resultado.SampleCount)
            {
                e.Value = null;
                return;
            }

            int fila = e.RowIndex;

            if (e.ColumnIndex == colIndice.Index)
            {
                e.Value = fila;
            }
            else if (e.ColumnIndex == colTiempo.Index)
            {
                e.Value = _resultado.Time[fila];
            }
            else if (e.ColumnIndex == colFuerza.Index)
            {
                e.Value = _resultado.Force[fila];
            }
            else if (e.ColumnIndex == colY1.Index)
            {
                e.Value = _resultado.Y1[fila];
            }
            else if (e.ColumnIndex == colY2.Index)
            {
                e.Value = _resultado.Y2[fila];
            }
            else if (e.ColumnIndex == colY3.Index)
            {
                e.Value = _resultado.Y3[fila];
            }
            else
            {
                e.Value = null;
            }
        }

        /// <summary>Llena la tabla de análisis de máximos de cada masa.</summary>
        private void ActualizarAnalisis(SimulationResult resultado)
        {
            dgvAnalisis.SuspendLayout();
            try
            {
                dgvAnalisis.Rows.Clear();
                dgvAnalisis.Rows.Add(resultado.Analysis.Count);

                for (int i = 0; i < resultado.Analysis.Count; i++)
                {
                    MassAnalysis analisis = resultado.Analysis[i];

                    dgvAnalisis.Rows[i].Cells[colMasa.Index].Value = analisis.Masa;
                    dgvAnalisis.Rows[i].Cells[colMaximo.Index].Value = analisis.ValorMaximo;
                    dgvAnalisis.Rows[i].Cells[colTiempoMaximo.Index].Value = analisis.TiempoMaximo;
                    dgvAnalisis.Rows[i].Cells[colMinimo.Index].Value = analisis.ValorMinimo;
                    dgvAnalisis.Rows[i].Cells[colTiempoMinimo.Index].Value = analisis.TiempoMinimo;
                    dgvAnalisis.Rows[i].Cells[colMaximoAbsoluto.Index].Value = analisis.ValorMaximoAbsoluto;
                    dgvAnalisis.Rows[i].Cells[colTiempoMaximoAbsoluto.Index].Value = analisis.TiempoMaximoAbsoluto;
                }
            }
            finally
            {
                dgvAnalisis.ResumeLayout();
            }
        }

        #endregion

        #region Sincronización de la vista

        /// <summary>
        /// Refresca la animación, el marcador de la gráfica, las etiquetas de estado
        /// y la fila seleccionada de la tabla para el instante actual.
        /// </summary>
        private void ActualizarVistaAnimacion()
        {
            if (_resultado is null)
            {
                lblTiempoActual.Text = "t = --";
                lblFuerzaActual.Text = "F = --";
                lblY1Actual.Text = "y1 = --";
                lblY2Actual.Text = "y2 = --";
                lblY3Actual.Text = "y3 = --";
                panelAnimacion.Invalidate();
                return;
            }

            int indice = Math.Clamp(_indiceMuestra, 0, _resultado.SampleCount - 1);

            lblTiempoActual.Text = $"t = {_resultado.Time[indice]:F4} s  (i = {indice + 1}/{_resultado.SampleCount})";
            lblFuerzaActual.Text = $"F = {_resultado.Force[indice]:F3} N";
            lblY1Actual.Text = $"y1 = {_resultado.Y1[indice]:G6} m";
            lblY2Actual.Text = $"y2 = {_resultado.Y2[indice]:G6} m";
            lblY3Actual.Text = $"y3 = {_resultado.Y3[indice]:G6} m";

            ActualizarMarcadorGrafica(indice);
            panelAnimacion.Invalidate();

            // La tabla NO se repinta durante la reproducción: repintar el DataGridView
            // dentro de los TableLayoutPanel del formulario cuesta decenas de milisegundos
            // y el temporizador no podría seguir el ritmo (se acumularían eventos).
            // La fila actual se muestra en las etiquetas; el usuario navega la tabla
            // haciendo clic en una fila (evento CellClick).
        }

        /// <summary>
        /// Permite navegar la animación desde la tabla: al hacer clic en una fila,
        /// la animación salta a ese instante.
        /// </summary>
        private void dgvMuestras_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (_resultado is null || e.RowIndex < 0 || e.RowIndex >= _resultado.SampleCount)
            {
                return;
            }

            _indiceMuestra = e.RowIndex;

            // Se reancla el arranque de la reproducción para que la animación continúe
            // desde el instante elegido.
            _inicioReproduccion = DateTime.UtcNow - TimeSpan.FromSeconds(_indiceMuestra * _resultado.TimeStep);

            ActualizarVistaAnimacion();
        }

        /// <summary>Vuelve al instante inicial y detiene la reproducción.</summary>
        private void ReiniciarAnimacion()
        {
            timerAnimacion.Stop();
            _indiceMuestra = 0;
            _inicioReproduccion = DateTime.UtcNow;
            ActualizarEstadoControles();
            ActualizarVistaAnimacion();
        }

        /// <summary>Activa o desactiva los botones según el estado de la aplicación.</summary>
        private void ActualizarEstadoControles()
        {
            bool hayResultado = _resultado is not null;

            btnSimular.Enabled = !_simulando;
            btnReproducir.Enabled = hayResultado && !_simulando;
            btnReiniciar.Enabled = hayResultado && !_simulando;
            btnRestablecer.Enabled = !_simulando;

            btnReproducir.Text = timerAnimacion.Enabled ? "Pausar" : "Reproducir";
        }

        #endregion

        #region Lectura y validación de parámetros

        /// <summary>
        /// Lee los campos del formulario, valida los rangos y devuelve los parámetros.
        /// Los errores se marcan con el ErrorProvider declarado en el diseñador.
        /// </summary>
        private bool LeerParametros(out SystemParameters parametros, out List<string> errores)
        {
            errores = new List<string>();
            errorProvider.Clear();

            // Campos cuyo contenido no se pudo interpretar: para ellos no se agrega el
            // error de rango, porque el mensaje de formato es más específico y ya fue avisado.
            HashSet<string> camposConErrorDeFormato = new();

            double m1 = LeerNumero(txtM1, "m1", errores, camposConErrorDeFormato);
            double m2 = LeerNumero(txtM2, "m2", errores, camposConErrorDeFormato);
            double m3 = LeerNumero(txtM3, "m3", errores, camposConErrorDeFormato);
            double k1 = LeerNumero(txtK1, "k1", errores, camposConErrorDeFormato);
            double k2 = LeerNumero(txtK2, "k2", errores, camposConErrorDeFormato);
            double k3 = LeerNumero(txtK3, "k3", errores, camposConErrorDeFormato);
            double k4 = LeerNumero(txtK4, "k4", errores, camposConErrorDeFormato);
            double b1 = LeerNumero(txtB1, "b1", errores, camposConErrorDeFormato);
            double b2 = LeerNumero(txtB2, "b2", errores, camposConErrorDeFormato);
            double b3 = LeerNumero(txtB3, "b3", errores, camposConErrorDeFormato);
            double amplitud = LeerNumero(txtAmplitud, "amplitud", errores, camposConErrorDeFormato);
            double duracion = LeerNumero(txtDuracion, "duracion", errores, camposConErrorDeFormato);
            double tiempo = LeerNumero(txtTiempo, "tiempo", errores, camposConErrorDeFormato);
            int muestras = LeerCantidadDeMuestras(errores, camposConErrorDeFormato);
            double escala = LeerNumero(txtEscala, "escala", errores, camposConErrorDeFormato);

            parametros = new SystemParameters
            {
                M1 = m1,
                M2 = m2,
                M3 = m3,
                K1 = k1,
                K2 = k2,
                K3 = k3,
                K4 = k4,
                B1 = b1,
                B2 = b2,
                B3 = b3,
                ForceAmplitude = amplitud,
                ForceDuration = duracion,
                SimulationTime = tiempo,
                SampleCount = muestras,
                AnimationScale = escala,
            };

            foreach (ValidationIssue issue in parametros.Validate())
            {
                if (camposConErrorDeFormato.Contains(issue.Campo))
                {
                    // El campo ya tiene un aviso más específico (vacío o no numérico).
                    continue;
                }

                errores.Add(issue.Mensaje);

                Control? campo = BuscarCampo(issue.Campo);
                if (campo is not null)
                {
                    errorProvider.SetError(campo, issue.Mensaje);
                }
            }

            return errores.Count == 0;
        }

        /// <summary>
        /// Lee el número de muestras, que debe ser un entero: la consigna exige un
        /// número de muestras entero (N >= 2 con un máximo razonable), no un valor
        /// fraccionario que luego se trunque.
        /// </summary>
        private int LeerCantidadDeMuestras(List<string> errores, HashSet<string> camposConErrorDeFormato)
        {
            string texto = txtMuestras.Text.Trim();

            if (texto.Length == 0)
            {
                errores.Add("El campo «número de muestras» está vacío.");
                errorProvider.SetError(txtMuestras, "Valor obligatorio: el campo está vacío.");
                camposConErrorDeFormato.Add("muestras");
                return 0;
            }

            if (!int.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valor)
                && !int.TryParse(texto, NumberStyles.Integer, CultureInfo.CurrentCulture, out valor))
            {
                errores.Add($"El campo «número de muestras» debe ser un número entero: «{texto}».");
                errorProvider.SetError(txtMuestras, "Debe ser un número entero (por ejemplo 1000).");
                camposConErrorDeFormato.Add("muestras");
                return 0;
            }

            errorProvider.SetError(txtMuestras, string.Empty);
            return valor;
        }

        /// <summary>Lee un campo numérico y registra el error si no es válido.</summary>
        private double LeerNumero(TextBox campo, string clave, List<string> errores, HashSet<string> camposConErrorDeFormato)
        {
            string texto = campo.Text.Trim();

            if (texto.Length == 0)
            {
                errores.Add($"El campo «{NombreCampo(clave)}» está vacío.");
                errorProvider.SetError(campo, "Valor obligatorio: el campo está vacío.");
                camposConErrorDeFormato.Add(clave);
                return 0;
            }

            if (!TryParseNumero(texto, out double valor))
            {
                errores.Add($"El campo «{NombreCampo(clave)}» no contiene un número válido: «{texto}».");
                errorProvider.SetError(campo, "Debe ser un número (por ejemplo 12.5 o 12,5).");
                camposConErrorDeFormato.Add(clave);
                return 0;
            }

            errorProvider.SetError(campo, string.Empty);
            return valor;
        }

        /// <summary>Nombre legible de un campo para los mensajes de error.</summary>
        private static string NombreCampo(string clave) => clave switch
        {
            "duracion" => "duración",
            "tiempo" => "tiempo de simulación",
            "muestras" => "número de muestras",
            "escala" => "factor de escala",
            "amplitud" => "amplitud de la fuerza",
            _ => clave,
        };

        /// <summary>
        /// Convierte un texto en número. Acepta punto o coma decimal: primero se
        /// interpreta con la cultura invariante y, si falla, con la cultura actual.
        /// </summary>
        private static bool TryParseNumero(string texto, out double valor)
        {
            const NumberStyles estilos = NumberStyles.Float;

            if (double.TryParse(texto, estilos, CultureInfo.InvariantCulture, out valor))
            {
                return true;
            }

            return double.TryParse(texto, estilos, CultureInfo.CurrentCulture, out valor);
        }

        /// <summary>Devuelve el control asociado a la clave de un campo.</summary>
        private Control? BuscarCampo(string clave) => clave switch
        {
            "m1" => txtM1,
            "m2" => txtM2,
            "m3" => txtM3,
            "k1" => txtK1,
            "k2" => txtK2,
            "k3" => txtK3,
            "k4" => txtK4,
            "b1" => txtB1,
            "b2" => txtB2,
            "b3" => txtB3,
            "amplitud" => txtAmplitud,
            "duracion" => txtDuracion,
            "tiempo" => txtTiempo,
            "muestras" => txtMuestras,
            "escala" => txtEscala,
            _ => null,
        };

        /// <summary>Muestra los errores de validación al usuario.</summary>
        private void MostrarErrores(List<string> errores)
        {
            lblProgreso.Text = "Corrija los campos marcados en rojo antes de simular.";

            MessageBox.Show(
                this,
                string.Join(Environment.NewLine, errores),
                "Parámetros no válidos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        /// <summary>Escribe los valores por defecto en los campos del formulario.</summary>
        private void CargarValoresPorDefecto()
        {
            SystemParameters porDefecto = SystemParameters.Default;
            CultureInfo cultura = CultureInfo.CurrentCulture;

            txtM1.Text = porDefecto.M1.ToString(cultura);
            txtM2.Text = porDefecto.M2.ToString(cultura);
            txtM3.Text = porDefecto.M3.ToString(cultura);
            txtK1.Text = porDefecto.K1.ToString(cultura);
            txtK2.Text = porDefecto.K2.ToString(cultura);
            txtK3.Text = porDefecto.K3.ToString(cultura);
            txtK4.Text = porDefecto.K4.ToString(cultura);
            txtB1.Text = porDefecto.B1.ToString(cultura);
            txtB2.Text = porDefecto.B2.ToString(cultura);
            txtB3.Text = porDefecto.B3.ToString(cultura);
            txtAmplitud.Text = porDefecto.ForceAmplitude.ToString(cultura);
            txtDuracion.Text = porDefecto.ForceDuration.ToString(cultura);
            txtTiempo.Text = porDefecto.SimulationTime.ToString(cultura);
            txtMuestras.Text = porDefecto.SampleCount.ToString(cultura);
            txtEscala.Text = porDefecto.AnimationScale.ToString(cultura);
        }

        #endregion
    }
}
