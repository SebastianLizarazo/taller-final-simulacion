#nullable enable

namespace taller_final_simulacion
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        // ---------------------------------------------------------------------
        // Controles de la interfaz (declarados en el diseñador: no se crean desde código)
        // ---------------------------------------------------------------------

        /// <summary>Control de graficado de ScottPlot (WinForms).</summary>
        private ScottPlot.WinForms.FormsPlot graficaPlot = null!;

        /// <summary>Panel con doble búfer donde se dibuja la animación con GDI+.</summary>
        private Controles.PanelDobleBuffer panelAnimacion = null!;

        /// <summary>Temporizador de la animación.</summary>
        private System.Windows.Forms.Timer timerAnimacion = null!;

        /// <summary>Proveedor de errores para la validación de los campos.</summary>
        private System.Windows.Forms.ErrorProvider errorProvider = null!;

        // Estructura general
        private System.Windows.Forms.TableLayoutPanel tlRaiz = null!;
        private System.Windows.Forms.TableLayoutPanel tlLateral = null!;
        private System.Windows.Forms.GroupBox gbParametros = null!;
        private System.Windows.Forms.Panel panelParametros = null!;
        private System.Windows.Forms.TableLayoutPanel tlParametros = null!;
        private System.Windows.Forms.GroupBox gbAcciones = null!;
        private System.Windows.Forms.TableLayoutPanel tlAcciones = null!;
        private System.Windows.Forms.FlowLayoutPanel flBotones = null!;
        private System.Windows.Forms.ProgressBar progressBarSimulacion = null!;
        private System.Windows.Forms.Label lblProgreso = null!;
        private System.Windows.Forms.Label lblAviso = null!;

        private System.Windows.Forms.TableLayoutPanel tlContenido = null!;
        private System.Windows.Forms.GroupBox gbGrafica = null!;
        private System.Windows.Forms.GroupBox gbAnimacion = null!;
        private System.Windows.Forms.TableLayoutPanel tlAnimacion = null!;
        private System.Windows.Forms.TableLayoutPanel tlEstadoAnimacion = null!;
        private System.Windows.Forms.GroupBox gbMuestras = null!;
        private System.Windows.Forms.GroupBox gbAnalisis = null!;
        private System.Windows.Forms.DataGridView dgvMuestras = null!;
        private System.Windows.Forms.DataGridView dgvAnalisis = null!;

        // Botones
        private System.Windows.Forms.Button btnSimular = null!;
        private System.Windows.Forms.Button btnReproducir = null!;
        private System.Windows.Forms.Button btnReiniciar = null!;
        private System.Windows.Forms.Button btnRestablecer = null!;

        // Campos de entrada de parámetros
        private System.Windows.Forms.Label lblCabeceraParametro = null!;
        private System.Windows.Forms.Label lblCabeceraValor = null!;
        private System.Windows.Forms.Label lblCabeceraUnidad = null!;
        private System.Windows.Forms.Label lblM1 = null!;
        private System.Windows.Forms.TextBox txtM1 = null!;
        private System.Windows.Forms.Label udM1 = null!;
        private System.Windows.Forms.Label lblM2 = null!;
        private System.Windows.Forms.TextBox txtM2 = null!;
        private System.Windows.Forms.Label udM2 = null!;
        private System.Windows.Forms.Label lblM3 = null!;
        private System.Windows.Forms.TextBox txtM3 = null!;
        private System.Windows.Forms.Label udM3 = null!;
        private System.Windows.Forms.Label lblK1 = null!;
        private System.Windows.Forms.TextBox txtK1 = null!;
        private System.Windows.Forms.Label udK1 = null!;
        private System.Windows.Forms.Label lblK2 = null!;
        private System.Windows.Forms.TextBox txtK2 = null!;
        private System.Windows.Forms.Label udK2 = null!;
        private System.Windows.Forms.Label lblK3 = null!;
        private System.Windows.Forms.TextBox txtK3 = null!;
        private System.Windows.Forms.Label udK3 = null!;
        private System.Windows.Forms.Label lblK4 = null!;
        private System.Windows.Forms.TextBox txtK4 = null!;
        private System.Windows.Forms.Label udK4 = null!;
        private System.Windows.Forms.Label lblB1 = null!;
        private System.Windows.Forms.TextBox txtB1 = null!;
        private System.Windows.Forms.Label udB1 = null!;
        private System.Windows.Forms.Label lblB2 = null!;
        private System.Windows.Forms.TextBox txtB2 = null!;
        private System.Windows.Forms.Label udB2 = null!;
        private System.Windows.Forms.Label lblB3 = null!;
        private System.Windows.Forms.TextBox txtB3 = null!;
        private System.Windows.Forms.Label udB3 = null!;
        private System.Windows.Forms.Label lblAmplitud = null!;
        private System.Windows.Forms.TextBox txtAmplitud = null!;
        private System.Windows.Forms.Label udAmplitud = null!;
        private System.Windows.Forms.Label lblDuracion = null!;
        private System.Windows.Forms.TextBox txtDuracion = null!;
        private System.Windows.Forms.Label udDuracion = null!;
        private System.Windows.Forms.Label lblTiempo = null!;
        private System.Windows.Forms.TextBox txtTiempo = null!;
        private System.Windows.Forms.Label udTiempo = null!;
        private System.Windows.Forms.Label lblMuestras = null!;
        private System.Windows.Forms.TextBox txtMuestras = null!;
        private System.Windows.Forms.Label udMuestras = null!;
        private System.Windows.Forms.Label lblEscala = null!;
        private System.Windows.Forms.TextBox txtEscala = null!;
        private System.Windows.Forms.Label udEscala = null!;

        // Etiquetas del estado instantáneo de la animación
        private System.Windows.Forms.Label lblTiempoActual = null!;
        private System.Windows.Forms.Label lblFuerzaActual = null!;
        private System.Windows.Forms.Label lblY1Actual = null!;
        private System.Windows.Forms.Label lblY2Actual = null!;
        private System.Windows.Forms.Label lblY3Actual = null!;
        private System.Windows.Forms.Label lblAvisoEscala = null!;

        // Columnas de la tabla de muestras
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndice = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempo = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuerza = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY1 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY2 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY3 = null!;

        // Columnas de la tabla de análisis
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasa = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaximo = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoMaximo = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinimo = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoMinimo = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaximoAbsoluto = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoMaximoAbsoluto = null!;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlRaiz = new System.Windows.Forms.TableLayoutPanel();
            this.tlLateral = new System.Windows.Forms.TableLayoutPanel();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.panelParametros = new System.Windows.Forms.Panel();
            this.tlParametros = new System.Windows.Forms.TableLayoutPanel();
            this.lblCabeceraParametro = new System.Windows.Forms.Label();
            this.lblCabeceraValor = new System.Windows.Forms.Label();
            this.lblCabeceraUnidad = new System.Windows.Forms.Label();
            this.lblM1 = new System.Windows.Forms.Label();
            this.txtM1 = new System.Windows.Forms.TextBox();
            this.udM1 = new System.Windows.Forms.Label();
            this.lblM2 = new System.Windows.Forms.Label();
            this.txtM2 = new System.Windows.Forms.TextBox();
            this.udM2 = new System.Windows.Forms.Label();
            this.lblM3 = new System.Windows.Forms.Label();
            this.txtM3 = new System.Windows.Forms.TextBox();
            this.udM3 = new System.Windows.Forms.Label();
            this.lblK1 = new System.Windows.Forms.Label();
            this.txtK1 = new System.Windows.Forms.TextBox();
            this.udK1 = new System.Windows.Forms.Label();
            this.lblK2 = new System.Windows.Forms.Label();
            this.txtK2 = new System.Windows.Forms.TextBox();
            this.udK2 = new System.Windows.Forms.Label();
            this.lblK3 = new System.Windows.Forms.Label();
            this.txtK3 = new System.Windows.Forms.TextBox();
            this.udK3 = new System.Windows.Forms.Label();
            this.lblK4 = new System.Windows.Forms.Label();
            this.txtK4 = new System.Windows.Forms.TextBox();
            this.udK4 = new System.Windows.Forms.Label();
            this.lblB1 = new System.Windows.Forms.Label();
            this.txtB1 = new System.Windows.Forms.TextBox();
            this.udB1 = new System.Windows.Forms.Label();
            this.lblB2 = new System.Windows.Forms.Label();
            this.txtB2 = new System.Windows.Forms.TextBox();
            this.udB2 = new System.Windows.Forms.Label();
            this.lblB3 = new System.Windows.Forms.Label();
            this.txtB3 = new System.Windows.Forms.TextBox();
            this.udB3 = new System.Windows.Forms.Label();
            this.lblAmplitud = new System.Windows.Forms.Label();
            this.txtAmplitud = new System.Windows.Forms.TextBox();
            this.udAmplitud = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.udDuracion = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.udTiempo = new System.Windows.Forms.Label();
            this.lblMuestras = new System.Windows.Forms.Label();
            this.txtMuestras = new System.Windows.Forms.TextBox();
            this.udMuestras = new System.Windows.Forms.Label();
            this.lblEscala = new System.Windows.Forms.Label();
            this.txtEscala = new System.Windows.Forms.TextBox();
            this.udEscala = new System.Windows.Forms.Label();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.tlAcciones = new System.Windows.Forms.TableLayoutPanel();
            this.flBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSimular = new System.Windows.Forms.Button();
            this.btnReproducir = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnRestablecer = new System.Windows.Forms.Button();
            this.progressBarSimulacion = new System.Windows.Forms.ProgressBar();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.tlContenido = new System.Windows.Forms.TableLayoutPanel();
            this.gbGrafica = new System.Windows.Forms.GroupBox();
            this.graficaPlot = new ScottPlot.WinForms.FormsPlot();
            this.gbAnimacion = new System.Windows.Forms.GroupBox();
            this.tlAnimacion = new System.Windows.Forms.TableLayoutPanel();
            this.panelAnimacion = new Controles.PanelDobleBuffer();
            this.tlEstadoAnimacion = new System.Windows.Forms.TableLayoutPanel();
            this.lblTiempoActual = new System.Windows.Forms.Label();
            this.lblFuerzaActual = new System.Windows.Forms.Label();
            this.lblY1Actual = new System.Windows.Forms.Label();
            this.lblY2Actual = new System.Windows.Forms.Label();
            this.lblY3Actual = new System.Windows.Forms.Label();
            this.lblAvisoEscala = new System.Windows.Forms.Label();
            this.gbMuestras = new System.Windows.Forms.GroupBox();
            this.dgvMuestras = new System.Windows.Forms.DataGridView();
            this.colIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuerza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbAnalisis = new System.Windows.Forms.GroupBox();
            this.dgvAnalisis = new System.Windows.Forms.DataGridView();
            this.colMasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaximoAbsoluto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoMaximoAbsoluto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerAnimacion = new System.Windows.Forms.Timer(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlRaiz.SuspendLayout();
            this.tlLateral.SuspendLayout();
            this.gbParametros.SuspendLayout();
            this.tlParametros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            this.tlAcciones.SuspendLayout();
            this.flBotones.SuspendLayout();
            this.tlContenido.SuspendLayout();
            this.gbGrafica.SuspendLayout();
            this.gbAnimacion.SuspendLayout();
            this.tlAnimacion.SuspendLayout();
            this.tlEstadoAnimacion.SuspendLayout();
            this.gbMuestras.SuspendLayout();
            this.dgvMuestras.SuspendLayout();
            this.gbAnalisis.SuspendLayout();
            this.dgvAnalisis.SuspendLayout();
            this.SuspendLayout();
            //
            // tlRaiz
            //
            this.tlRaiz.ColumnCount = 2;
            this.tlRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tlRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlRaiz.Location = new System.Drawing.Point(0, 0);
            this.tlRaiz.Name = "tlRaiz";
            this.tlRaiz.RowCount = 1;
            this.tlRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlRaiz.Size = new System.Drawing.Size(1400, 861);
            this.tlRaiz.TabIndex = 0;
            //
            // tlLateral
            //
            this.tlLateral.ColumnCount = 1;
            this.tlLateral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlLateral.Controls.Add(this.gbParametros, 0, 0);
            this.tlLateral.Controls.Add(this.gbAcciones, 0, 1);
            this.tlLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlLateral.Location = new System.Drawing.Point(0, 0);
            this.tlLateral.Name = "tlLateral";
            this.tlLateral.RowCount = 2;
            this.tlLateral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlLateral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlLateral.Size = new System.Drawing.Size(360, 861);
            this.tlLateral.TabIndex = 1;
            //
            // gbParametros
            //
            this.gbParametros.Controls.Add(this.panelParametros);
            this.gbParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbParametros.Location = new System.Drawing.Point(3, 3);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.gbParametros.Size = new System.Drawing.Size(354, 685);
            this.gbParametros.TabIndex = 0;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Parámetros del sistema";
            //
            // panelParametros (contenedor con desplazamiento vertical)
            //
            this.panelParametros.AutoScroll = true;
            this.panelParametros.Controls.Add(this.tlParametros);
            this.panelParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParametros.Location = new System.Drawing.Point(6, 17);
            this.panelParametros.Name = "panelParametros";
            this.panelParametros.Size = new System.Drawing.Size(346, 657);
            this.panelParametros.TabIndex = 0;
            //
            // tlParametros
            //
            this.tlParametros.AutoSize = true;
            this.tlParametros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlParametros.ColumnCount = 3;
            this.tlParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tlParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlParametros.Controls.Add(this.lblCabeceraParametro, 0, 0);
            this.tlParametros.Controls.Add(this.lblCabeceraValor, 1, 0);
            this.tlParametros.Controls.Add(this.lblCabeceraUnidad, 2, 0);
            this.tlParametros.Controls.Add(this.lblM1, 0, 1);
            this.tlParametros.Controls.Add(this.txtM1, 1, 1);
            this.tlParametros.Controls.Add(this.udM1, 2, 1);
            this.tlParametros.Controls.Add(this.lblM2, 0, 2);
            this.tlParametros.Controls.Add(this.txtM2, 1, 2);
            this.tlParametros.Controls.Add(this.udM2, 2, 2);
            this.tlParametros.Controls.Add(this.lblM3, 0, 3);
            this.tlParametros.Controls.Add(this.txtM3, 1, 3);
            this.tlParametros.Controls.Add(this.udM3, 2, 3);
            this.tlParametros.Controls.Add(this.lblK1, 0, 4);
            this.tlParametros.Controls.Add(this.txtK1, 1, 4);
            this.tlParametros.Controls.Add(this.udK1, 2, 4);
            this.tlParametros.Controls.Add(this.lblK2, 0, 5);
            this.tlParametros.Controls.Add(this.txtK2, 1, 5);
            this.tlParametros.Controls.Add(this.udK2, 2, 5);
            this.tlParametros.Controls.Add(this.lblK3, 0, 6);
            this.tlParametros.Controls.Add(this.txtK3, 1, 6);
            this.tlParametros.Controls.Add(this.udK3, 2, 6);
            this.tlParametros.Controls.Add(this.lblK4, 0, 7);
            this.tlParametros.Controls.Add(this.txtK4, 1, 7);
            this.tlParametros.Controls.Add(this.udK4, 2, 7);
            this.tlParametros.Controls.Add(this.lblB1, 0, 8);
            this.tlParametros.Controls.Add(this.txtB1, 1, 8);
            this.tlParametros.Controls.Add(this.udB1, 2, 8);
            this.tlParametros.Controls.Add(this.lblB2, 0, 9);
            this.tlParametros.Controls.Add(this.txtB2, 1, 9);
            this.tlParametros.Controls.Add(this.udB2, 2, 9);
            this.tlParametros.Controls.Add(this.lblB3, 0, 10);
            this.tlParametros.Controls.Add(this.txtB3, 1, 10);
            this.tlParametros.Controls.Add(this.udB3, 2, 10);
            this.tlParametros.Controls.Add(this.lblAmplitud, 0, 11);
            this.tlParametros.Controls.Add(this.txtAmplitud, 1, 11);
            this.tlParametros.Controls.Add(this.udAmplitud, 2, 11);
            this.tlParametros.Controls.Add(this.lblDuracion, 0, 12);
            this.tlParametros.Controls.Add(this.txtDuracion, 1, 12);
            this.tlParametros.Controls.Add(this.udDuracion, 2, 12);
            this.tlParametros.Controls.Add(this.lblTiempo, 0, 13);
            this.tlParametros.Controls.Add(this.txtTiempo, 1, 13);
            this.tlParametros.Controls.Add(this.udTiempo, 2, 13);
            this.tlParametros.Controls.Add(this.lblMuestras, 0, 14);
            this.tlParametros.Controls.Add(this.txtMuestras, 1, 14);
            this.tlParametros.Controls.Add(this.udMuestras, 2, 14);
            this.tlParametros.Controls.Add(this.lblEscala, 0, 15);
            this.tlParametros.Controls.Add(this.txtEscala, 1, 15);
            this.tlParametros.Controls.Add(this.udEscala, 2, 15);
            this.tlParametros.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlParametros.Location = new System.Drawing.Point(3, 17);
            this.tlParametros.Name = "tlParametros";
            this.tlParametros.RowCount = 16;
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlParametros.Size = new System.Drawing.Size(340, 416);
            this.tlParametros.TabIndex = 0;
            //
            // Cabeceras de la tabla de parámetros
            //
            this.lblCabeceraParametro.AutoSize = true;
            this.lblCabeceraParametro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCabeceraParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCabeceraParametro.Location = new System.Drawing.Point(3, 0);
            this.lblCabeceraParametro.Name = "lblCabeceraParametro";
            this.lblCabeceraParametro.Size = new System.Drawing.Size(144, 26);
            this.lblCabeceraParametro.TabIndex = 0;
            this.lblCabeceraParametro.Text = "Parámetro";
            this.lblCabeceraParametro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCabeceraValor.AutoSize = true;
            this.lblCabeceraValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCabeceraValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCabeceraValor.Location = new System.Drawing.Point(153, 0);
            this.lblCabeceraValor.Name = "lblCabeceraValor";
            this.lblCabeceraValor.Size = new System.Drawing.Size(89, 26);
            this.lblCabeceraValor.TabIndex = 1;
            this.lblCabeceraValor.Text = "Valor";
            this.lblCabeceraValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCabeceraUnidad.AutoSize = true;
            this.lblCabeceraUnidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCabeceraUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCabeceraUnidad.Location = new System.Drawing.Point(248, 0);
            this.lblCabeceraUnidad.Name = "lblCabeceraUnidad";
            this.lblCabeceraUnidad.Size = new System.Drawing.Size(74, 26);
            this.lblCabeceraUnidad.TabIndex = 2;
            this.lblCabeceraUnidad.Text = "Unidad";
            this.lblCabeceraUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Etiquetas y campos de los parámetros
            //
            this.lblM1.AutoSize = true;
            this.lblM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblM1.Location = new System.Drawing.Point(3, 26);
            this.lblM1.Name = "lblM1";
            this.lblM1.Size = new System.Drawing.Size(144, 26);
            this.lblM1.TabIndex = 3;
            this.lblM1.Text = "m1  (masa)";
            this.lblM1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtM1.Location = new System.Drawing.Point(153, 29);
            this.txtM1.Name = "txtM1";
            this.txtM1.Size = new System.Drawing.Size(89, 20);
            this.txtM1.TabIndex = 4;
            this.txtM1.Text = "1";
            this.udM1.AutoSize = true;
            this.udM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udM1.Location = new System.Drawing.Point(248, 26);
            this.udM1.Name = "udM1";
            this.udM1.Size = new System.Drawing.Size(74, 26);
            this.udM1.TabIndex = 5;
            this.udM1.Text = "kg";
            this.udM1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblM2.AutoSize = true;
            this.lblM2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblM2.Location = new System.Drawing.Point(3, 52);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(144, 26);
            this.lblM2.TabIndex = 6;
            this.lblM2.Text = "m2  (masa)";
            this.lblM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtM2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtM2.Location = new System.Drawing.Point(153, 55);
            this.txtM2.Name = "txtM2";
            this.txtM2.Size = new System.Drawing.Size(89, 20);
            this.txtM2.TabIndex = 7;
            this.txtM2.Text = "1";
            this.udM2.AutoSize = true;
            this.udM2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udM2.Location = new System.Drawing.Point(248, 52);
            this.udM2.Name = "udM2";
            this.udM2.Size = new System.Drawing.Size(74, 26);
            this.udM2.TabIndex = 8;
            this.udM2.Text = "kg";
            this.udM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblM3.AutoSize = true;
            this.lblM3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblM3.Location = new System.Drawing.Point(3, 78);
            this.lblM3.Name = "lblM3";
            this.lblM3.Size = new System.Drawing.Size(144, 26);
            this.lblM3.TabIndex = 9;
            this.lblM3.Text = "m3  (masa)";
            this.lblM3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtM3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtM3.Location = new System.Drawing.Point(153, 81);
            this.txtM3.Name = "txtM3";
            this.txtM3.Size = new System.Drawing.Size(89, 20);
            this.txtM3.TabIndex = 10;
            this.txtM3.Text = "1,5";
            this.udM3.AutoSize = true;
            this.udM3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udM3.Location = new System.Drawing.Point(248, 78);
            this.udM3.Name = "udM3";
            this.udM3.Size = new System.Drawing.Size(74, 26);
            this.udM3.TabIndex = 11;
            this.udM3.Text = "kg";
            this.udM3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblK1.AutoSize = true;
            this.lblK1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblK1.Location = new System.Drawing.Point(3, 104);
            this.lblK1.Name = "lblK1";
            this.lblK1.Size = new System.Drawing.Size(144, 26);
            this.lblK1.TabIndex = 12;
            this.lblK1.Text = "k1  (resorte sup.-m1)";
            this.lblK1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtK1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtK1.Location = new System.Drawing.Point(153, 107);
            this.txtK1.Name = "txtK1";
            this.txtK1.Size = new System.Drawing.Size(89, 20);
            this.txtK1.TabIndex = 13;
            this.txtK1.Text = "120";
            this.udK1.AutoSize = true;
            this.udK1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udK1.Location = new System.Drawing.Point(248, 104);
            this.udK1.Name = "udK1";
            this.udK1.Size = new System.Drawing.Size(74, 26);
            this.udK1.TabIndex = 14;
            this.udK1.Text = "N/m";
            this.udK1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblK2.AutoSize = true;
            this.lblK2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblK2.Location = new System.Drawing.Point(3, 130);
            this.lblK2.Name = "lblK2";
            this.lblK2.Size = new System.Drawing.Size(144, 26);
            this.lblK2.TabIndex = 15;
            this.lblK2.Text = "k2  (resorte m1-m3)";
            this.lblK2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtK2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtK2.Location = new System.Drawing.Point(153, 133);
            this.txtK2.Name = "txtK2";
            this.txtK2.Size = new System.Drawing.Size(89, 20);
            this.txtK2.TabIndex = 16;
            this.txtK2.Text = "80";
            this.udK2.AutoSize = true;
            this.udK2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udK2.Location = new System.Drawing.Point(248, 130);
            this.udK2.Name = "udK2";
            this.udK2.Size = new System.Drawing.Size(74, 26);
            this.udK2.TabIndex = 17;
            this.udK2.Text = "N/m";
            this.udK2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblK3.AutoSize = true;
            this.lblK3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblK3.Location = new System.Drawing.Point(3, 156);
            this.lblK3.Name = "lblK3";
            this.lblK3.Size = new System.Drawing.Size(144, 26);
            this.lblK3.TabIndex = 18;
            this.lblK3.Text = "k3  (resorte m3-sup.inf.)";
            this.lblK3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtK3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtK3.Location = new System.Drawing.Point(153, 159);
            this.txtK3.Name = "txtK3";
            this.txtK3.Size = new System.Drawing.Size(89, 20);
            this.txtK3.TabIndex = 19;
            this.txtK3.Text = "100";
            this.udK3.AutoSize = true;
            this.udK3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udK3.Location = new System.Drawing.Point(248, 156);
            this.udK3.Name = "udK3";
            this.udK3.Size = new System.Drawing.Size(74, 26);
            this.udK3.TabIndex = 20;
            this.udK3.Text = "N/m";
            this.udK3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblK4.AutoSize = true;
            this.lblK4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblK4.Location = new System.Drawing.Point(3, 182);
            this.lblK4.Name = "lblK4";
            this.lblK4.Size = new System.Drawing.Size(144, 26);
            this.lblK4.TabIndex = 21;
            this.lblK4.Text = "k4  (resorte sup.-m2)";
            this.lblK4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtK4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtK4.Location = new System.Drawing.Point(153, 185);
            this.txtK4.Name = "txtK4";
            this.txtK4.Size = new System.Drawing.Size(89, 20);
            this.txtK4.TabIndex = 22;
            this.txtK4.Text = "90";
            this.udK4.AutoSize = true;
            this.udK4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udK4.Location = new System.Drawing.Point(248, 182);
            this.udK4.Name = "udK4";
            this.udK4.Size = new System.Drawing.Size(74, 26);
            this.udK4.TabIndex = 23;
            this.udK4.Text = "N/m";
            this.udK4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblB1.AutoSize = true;
            this.lblB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblB1.Location = new System.Drawing.Point(3, 208);
            this.lblB1.Name = "lblB1";
            this.lblB1.Size = new System.Drawing.Size(144, 26);
            this.lblB1.TabIndex = 24;
            this.lblB1.Text = "b1  (amort. sup.-m1)";
            this.lblB1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtB1.Location = new System.Drawing.Point(153, 211);
            this.txtB1.Name = "txtB1";
            this.txtB1.Size = new System.Drawing.Size(89, 20);
            this.txtB1.TabIndex = 25;
            this.txtB1.Text = "2";
            this.udB1.AutoSize = true;
            this.udB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udB1.Location = new System.Drawing.Point(248, 208);
            this.udB1.Name = "udB1";
            this.udB1.Size = new System.Drawing.Size(74, 26);
            this.udB1.TabIndex = 26;
            this.udB1.Text = "N·s/m";
            this.udB1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblB2.AutoSize = true;
            this.lblB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblB2.Location = new System.Drawing.Point(3, 234);
            this.lblB2.Name = "lblB2";
            this.lblB2.Size = new System.Drawing.Size(144, 26);
            this.lblB2.TabIndex = 27;
            this.lblB2.Text = "b2  (amort. sup.-m2)";
            this.lblB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtB2.Location = new System.Drawing.Point(153, 237);
            this.txtB2.Name = "txtB2";
            this.txtB2.Size = new System.Drawing.Size(89, 20);
            this.txtB2.TabIndex = 28;
            this.txtB2.Text = "1,5";
            this.udB2.AutoSize = true;
            this.udB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udB2.Location = new System.Drawing.Point(248, 234);
            this.udB2.Name = "udB2";
            this.udB2.Size = new System.Drawing.Size(74, 26);
            this.udB2.TabIndex = 29;
            this.udB2.Text = "N·s/m";
            this.udB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblB3.AutoSize = true;
            this.lblB3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblB3.Location = new System.Drawing.Point(3, 260);
            this.lblB3.Name = "lblB3";
            this.lblB3.Size = new System.Drawing.Size(144, 26);
            this.lblB3.TabIndex = 30;
            this.lblB3.Text = "b3  (amort. m2-m3)";
            this.lblB3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtB3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtB3.Location = new System.Drawing.Point(153, 263);
            this.txtB3.Name = "txtB3";
            this.txtB3.Size = new System.Drawing.Size(89, 20);
            this.txtB3.TabIndex = 31;
            this.txtB3.Text = "1";
            this.udB3.AutoSize = true;
            this.udB3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udB3.Location = new System.Drawing.Point(248, 260);
            this.udB3.Name = "udB3";
            this.udB3.Size = new System.Drawing.Size(74, 26);
            this.udB3.TabIndex = 32;
            this.udB3.Text = "N·s/m";
            this.udB3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAmplitud.AutoSize = true;
            this.lblAmplitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmplitud.Location = new System.Drawing.Point(3, 286);
            this.lblAmplitud.Name = "lblAmplitud";
            this.lblAmplitud.Size = new System.Drawing.Size(144, 26);
            this.lblAmplitud.TabIndex = 33;
            this.lblAmplitud.Text = "A  (amplitud de F)";
            this.lblAmplitud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAmplitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmplitud.Location = new System.Drawing.Point(153, 289);
            this.txtAmplitud.Name = "txtAmplitud";
            this.txtAmplitud.Size = new System.Drawing.Size(89, 20);
            this.txtAmplitud.TabIndex = 34;
            this.txtAmplitud.Text = "10";
            this.udAmplitud.AutoSize = true;
            this.udAmplitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udAmplitud.Location = new System.Drawing.Point(248, 286);
            this.udAmplitud.Name = "udAmplitud";
            this.udAmplitud.Size = new System.Drawing.Size(74, 26);
            this.udAmplitud.TabIndex = 35;
            this.udAmplitud.Text = "N";
            this.udAmplitud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDuracion.Location = new System.Drawing.Point(3, 312);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(144, 26);
            this.lblDuracion.TabIndex = 36;
            this.lblDuracion.Text = "Tf  (duración de F)";
            this.lblDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDuracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDuracion.Location = new System.Drawing.Point(153, 315);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(89, 20);
            this.txtDuracion.TabIndex = 37;
            this.txtDuracion.Text = "1";
            this.udDuracion.AutoSize = true;
            this.udDuracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udDuracion.Location = new System.Drawing.Point(248, 312);
            this.udDuracion.Name = "udDuracion";
            this.udDuracion.Size = new System.Drawing.Size(74, 26);
            this.udDuracion.TabIndex = 38;
            this.udDuracion.Text = "s";
            this.udDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTiempo.Location = new System.Drawing.Point(3, 338);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(144, 26);
            this.lblTiempo.TabIndex = 39;
            this.lblTiempo.Text = "T  (tiempo simulación)";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTiempo.Location = new System.Drawing.Point(153, 341);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(89, 20);
            this.txtTiempo.TabIndex = 40;
            this.txtTiempo.Text = "10";
            this.udTiempo.AutoSize = true;
            this.udTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udTiempo.Location = new System.Drawing.Point(248, 338);
            this.udTiempo.Name = "udTiempo";
            this.udTiempo.Size = new System.Drawing.Size(74, 26);
            this.udTiempo.TabIndex = 41;
            this.udTiempo.Text = "s";
            this.udTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMuestras.AutoSize = true;
            this.lblMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMuestras.Location = new System.Drawing.Point(3, 364);
            this.lblMuestras.Name = "lblMuestras";
            this.lblMuestras.Size = new System.Drawing.Size(144, 26);
            this.lblMuestras.TabIndex = 42;
            this.lblMuestras.Text = "N  (nº de muestras)";
            this.lblMuestras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMuestras.Location = new System.Drawing.Point(153, 367);
            this.txtMuestras.Name = "txtMuestras";
            this.txtMuestras.Size = new System.Drawing.Size(89, 20);
            this.txtMuestras.TabIndex = 43;
            this.txtMuestras.Text = "1000";
            this.udMuestras.AutoSize = true;
            this.udMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udMuestras.Location = new System.Drawing.Point(248, 364);
            this.udMuestras.Name = "udMuestras";
            this.udMuestras.Size = new System.Drawing.Size(74, 26);
            this.udMuestras.TabIndex = 44;
            this.udMuestras.Text = "-";
            this.udMuestras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEscala.AutoSize = true;
            this.lblEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEscala.Location = new System.Drawing.Point(3, 390);
            this.lblEscala.Name = "lblEscala";
            this.lblEscala.Size = new System.Drawing.Size(144, 26);
            this.lblEscala.TabIndex = 45;
            this.lblEscala.Text = "Escala  (animación)";
            this.lblEscala.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEscala.Location = new System.Drawing.Point(153, 393);
            this.txtEscala.Name = "txtEscala";
            this.txtEscala.Size = new System.Drawing.Size(89, 20);
            this.txtEscala.TabIndex = 46;
            this.txtEscala.Text = "100";
            this.udEscala.AutoSize = true;
            this.udEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udEscala.Location = new System.Drawing.Point(248, 390);
            this.udEscala.Name = "udEscala";
            this.udEscala.Size = new System.Drawing.Size(74, 26);
            this.udEscala.TabIndex = 47;
            this.udEscala.Text = "px/m";
            this.udEscala.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // gbAcciones
            //
            this.gbAcciones.Controls.Add(this.tlAcciones);
            this.gbAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAcciones.Location = new System.Drawing.Point(3, 691);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.gbAcciones.Size = new System.Drawing.Size(354, 167);
            this.gbAcciones.TabIndex = 1;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            //
            // tlAcciones
            //
            this.tlAcciones.ColumnCount = 1;
            this.tlAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAcciones.Controls.Add(this.flBotones, 0, 0);
            this.tlAcciones.Controls.Add(this.progressBarSimulacion, 0, 1);
            this.tlAcciones.Controls.Add(this.lblProgreso, 0, 2);
            this.tlAcciones.Controls.Add(this.lblAviso, 0, 3);
            this.tlAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAcciones.Location = new System.Drawing.Point(6, 17);
            this.tlAcciones.Name = "tlAcciones";
            this.tlAcciones.RowCount = 4;
            this.tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAcciones.Size = new System.Drawing.Size(348, 144);
            this.tlAcciones.TabIndex = 0;
            //
            // flBotones
            //
            this.flBotones.Controls.Add(this.btnSimular);
            this.flBotones.Controls.Add(this.btnReproducir);
            this.flBotones.Controls.Add(this.btnReiniciar);
            this.flBotones.Controls.Add(this.btnRestablecer);
            this.flBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flBotones.Location = new System.Drawing.Point(3, 0);
            this.flBotones.Name = "flBotones";
            this.flBotones.Size = new System.Drawing.Size(342, 62);
            this.flBotones.TabIndex = 0;
            this.flBotones.WrapContents = true;
            //
            // btnSimular
            //
            this.btnSimular.AutoSize = true;
            this.btnSimular.Location = new System.Drawing.Point(3, 3);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(85, 23);
            this.btnSimular.TabIndex = 0;
            this.btnSimular.Text = "Simular";
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            //
            // btnReproducir
            //
            this.btnReproducir.AutoSize = true;
            this.btnReproducir.Location = new System.Drawing.Point(94, 3);
            this.btnReproducir.Name = "btnReproducir";
            this.btnReproducir.Size = new System.Drawing.Size(113, 23);
            this.btnReproducir.TabIndex = 1;
            this.btnReproducir.Text = "Reproducir";
            this.btnReproducir.UseVisualStyleBackColor = true;
            this.btnReproducir.Click += new System.EventHandler(this.btnReproducir_Click);
            //
            // btnReiniciar
            //
            this.btnReiniciar.AutoSize = true;
            this.btnReiniciar.Location = new System.Drawing.Point(213, 3);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(122, 23);
            this.btnReiniciar.TabIndex = 2;
            this.btnReiniciar.Text = "Reiniciar animación";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            //
            // btnRestablecer
            //
            this.btnRestablecer.AutoSize = true;
            this.btnRestablecer.Location = new System.Drawing.Point(3, 32);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(100, 23);
            this.btnRestablecer.TabIndex = 3;
            this.btnRestablecer.Text = "Restablecer";
            this.btnRestablecer.UseVisualStyleBackColor = true;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            //
            // progressBarSimulacion
            //
            this.progressBarSimulacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarSimulacion.Location = new System.Drawing.Point(3, 62);
            this.progressBarSimulacion.Name = "progressBarSimulacion";
            this.progressBarSimulacion.Size = new System.Drawing.Size(342, 20);
            this.progressBarSimulacion.TabIndex = 1;
            //
            // lblProgreso
            //
            this.lblProgreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgreso.Location = new System.Drawing.Point(3, 82);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(342, 20);
            this.lblProgreso.TabIndex = 2;
            this.lblProgreso.Text = "Listo para simular.";
            this.lblProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblAviso
            //
            this.lblAviso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAviso.Location = new System.Drawing.Point(3, 102);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(342, 39);
            this.lblAviso.TabIndex = 3;
            this.lblAviso.Text = "";
            //
            // tlContenido
            //
            this.tlContenido.ColumnCount = 2;
            this.tlContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlContenido.Controls.Add(this.gbGrafica, 0, 0);
            this.tlContenido.Controls.Add(this.gbAnimacion, 1, 0);
            this.tlContenido.Controls.Add(this.gbMuestras, 0, 1);
            this.tlContenido.Controls.Add(this.gbAnalisis, 1, 1);
            this.tlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlContenido.Location = new System.Drawing.Point(363, 3);
            this.tlContenido.Name = "tlContenido";
            this.tlContenido.RowCount = 2;
            this.tlContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlContenido.Size = new System.Drawing.Size(1034, 855);
            this.tlContenido.TabIndex = 2;
            //
            // gbGrafica
            //
            this.gbGrafica.Controls.Add(this.graficaPlot);
            this.gbGrafica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGrafica.Location = new System.Drawing.Point(3, 3);
            this.gbGrafica.Name = "gbGrafica";
            this.gbGrafica.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.gbGrafica.Size = new System.Drawing.Size(514, 467);
            this.gbGrafica.TabIndex = 0;
            this.gbGrafica.TabStop = false;
            this.gbGrafica.Text = "Respuesta temporal (ScottPlot)";
            //
            // graficaPlot
            //
            this.graficaPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficaPlot.Location = new System.Drawing.Point(6, 17);
            this.graficaPlot.Name = "graficaPlot";
            this.graficaPlot.Size = new System.Drawing.Size(508, 447);
            this.graficaPlot.TabIndex = 0;
            //
            // gbAnimacion
            //
            this.gbAnimacion.Controls.Add(this.tlAnimacion);
            this.gbAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAnimacion.Location = new System.Drawing.Point(520, 3);
            this.gbAnimacion.Name = "gbAnimacion";
            this.gbAnimacion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.gbAnimacion.Size = new System.Drawing.Size(514, 467);
            this.gbAnimacion.TabIndex = 1;
            this.gbAnimacion.TabStop = false;
            this.gbAnimacion.Text = "Animación del sistema";
            //
            // tlAnimacion
            //
            this.tlAnimacion.ColumnCount = 1;
            this.tlAnimacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAnimacion.Controls.Add(this.panelAnimacion, 0, 0);
            this.tlAnimacion.Controls.Add(this.tlEstadoAnimacion, 0, 1);
            this.tlAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAnimacion.Location = new System.Drawing.Point(6, 17);
            this.tlAnimacion.Name = "tlAnimacion";
            this.tlAnimacion.RowCount = 2;
            this.tlAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tlAnimacion.Size = new System.Drawing.Size(508, 444);
            this.tlAnimacion.TabIndex = 0;
            //
            // panelAnimacion
            //
            this.panelAnimacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnimacion.Location = new System.Drawing.Point(0, 0);
            this.panelAnimacion.Name = "panelAnimacion";
            this.panelAnimacion.Size = new System.Drawing.Size(508, 372);
            this.panelAnimacion.TabIndex = 0;
            this.panelAnimacion.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAnimacion_Paint);
            //
            // tlEstadoAnimacion
            //
            this.tlEstadoAnimacion.ColumnCount = 2;
            this.tlEstadoAnimacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlEstadoAnimacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlEstadoAnimacion.Controls.Add(this.lblTiempoActual, 0, 0);
            this.tlEstadoAnimacion.Controls.Add(this.lblFuerzaActual, 1, 0);
            this.tlEstadoAnimacion.Controls.Add(this.lblY1Actual, 0, 1);
            this.tlEstadoAnimacion.Controls.Add(this.lblY2Actual, 1, 1);
            this.tlEstadoAnimacion.Controls.Add(this.lblY3Actual, 0, 2);
            this.tlEstadoAnimacion.Controls.Add(this.lblAvisoEscala, 1, 2);
            this.tlEstadoAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlEstadoAnimacion.Location = new System.Drawing.Point(0, 372);
            this.tlEstadoAnimacion.Name = "tlEstadoAnimacion";
            this.tlEstadoAnimacion.RowCount = 3;
            this.tlEstadoAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlEstadoAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlEstadoAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlEstadoAnimacion.Size = new System.Drawing.Size(508, 72);
            this.tlEstadoAnimacion.TabIndex = 1;
            //
            // Etiquetas del estado instantáneo
            //
            this.lblTiempoActual.AutoSize = true;
            this.lblTiempoActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTiempoActual.Location = new System.Drawing.Point(0, 0);
            this.lblTiempoActual.Name = "lblTiempoActual";
            this.lblTiempoActual.Size = new System.Drawing.Size(254, 24);
            this.lblTiempoActual.TabIndex = 0;
            this.lblTiempoActual.Text = "t = --";
            this.lblTiempoActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFuerzaActual.AutoSize = true;
            this.lblFuerzaActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFuerzaActual.Location = new System.Drawing.Point(254, 0);
            this.lblFuerzaActual.Name = "lblFuerzaActual";
            this.lblFuerzaActual.Size = new System.Drawing.Size(254, 24);
            this.lblFuerzaActual.TabIndex = 1;
            this.lblFuerzaActual.Text = "F = --";
            this.lblFuerzaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblY1Actual.AutoSize = true;
            this.lblY1Actual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblY1Actual.Location = new System.Drawing.Point(0, 24);
            this.lblY1Actual.Name = "lblY1Actual";
            this.lblY1Actual.Size = new System.Drawing.Size(254, 24);
            this.lblY1Actual.TabIndex = 2;
            this.lblY1Actual.Text = "y1 = --";
            this.lblY1Actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblY2Actual.AutoSize = true;
            this.lblY2Actual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblY2Actual.Location = new System.Drawing.Point(254, 24);
            this.lblY2Actual.Name = "lblY2Actual";
            this.lblY2Actual.Size = new System.Drawing.Size(254, 24);
            this.lblY2Actual.TabIndex = 3;
            this.lblY2Actual.Text = "y2 = --";
            this.lblY2Actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblY3Actual.AutoSize = true;
            this.lblY3Actual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblY3Actual.Location = new System.Drawing.Point(0, 48);
            this.lblY3Actual.Name = "lblY3Actual";
            this.lblY3Actual.Size = new System.Drawing.Size(254, 24);
            this.lblY3Actual.TabIndex = 4;
            this.lblY3Actual.Text = "y3 = --";
            this.lblY3Actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAvisoEscala.AutoSize = true;
            this.lblAvisoEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvisoEscala.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAvisoEscala.Location = new System.Drawing.Point(254, 48);
            this.lblAvisoEscala.Name = "lblAvisoEscala";
            this.lblAvisoEscala.Size = new System.Drawing.Size(254, 24);
            this.lblAvisoEscala.TabIndex = 5;
            this.lblAvisoEscala.Text = "";
            this.lblAvisoEscala.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // gbMuestras
            //
            this.gbMuestras.Controls.Add(this.dgvMuestras);
            this.gbMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMuestras.Location = new System.Drawing.Point(3, 473);
            this.gbMuestras.Name = "gbMuestras";
            this.gbMuestras.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.gbMuestras.Size = new System.Drawing.Size(514, 382);
            this.gbMuestras.TabIndex = 2;
            this.gbMuestras.TabStop = false;
            this.gbMuestras.Text = "Muestras calculadas";
            //
            // dgvMuestras
            //
            this.dgvMuestras.AllowUserToAddRows = false;
            this.dgvMuestras.AllowUserToDeleteRows = false;
            this.dgvMuestras.AllowUserToResizeRows = false;
            this.dgvMuestras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuestras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndice,
            this.colTiempo,
            this.colFuerza,
            this.colY1,
            this.colY2,
            this.colY3});
            this.dgvMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMuestras.Location = new System.Drawing.Point(6, 17);
            this.dgvMuestras.Name = "dgvMuestras";
            this.dgvMuestras.ReadOnly = true;
            this.dgvMuestras.RowHeadersVisible = false;
            this.dgvMuestras.Size = new System.Drawing.Size(508, 358);
            this.dgvMuestras.TabIndex = 0;
            this.dgvMuestras.VirtualMode = true;
            this.dgvMuestras.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvMuestras_CellValueNeeded);
            //
            // Columnas de la tabla de muestras
            //
            this.colIndice.HeaderText = "i";
            this.colIndice.Name = "colIndice";
            this.colIndice.ReadOnly = true;
            this.colIndice.FillWeight = 40F;
            this.colIndice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIndice.DefaultCellStyle.Format = "0";
            this.colTiempo.HeaderText = "t (s)";
            this.colTiempo.Name = "colTiempo";
            this.colTiempo.ReadOnly = true;
            this.colTiempo.FillWeight = 70F;
            this.colTiempo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTiempo.DefaultCellStyle.Format = "F6";
            this.colFuerza.HeaderText = "F(t) (N)";
            this.colFuerza.Name = "colFuerza";
            this.colFuerza.ReadOnly = true;
            this.colFuerza.FillWeight = 70F;
            this.colFuerza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFuerza.DefaultCellStyle.Format = "G6";
            this.colY1.HeaderText = "y1 (m)";
            this.colY1.Name = "colY1";
            this.colY1.ReadOnly = true;
            this.colY1.FillWeight = 70F;
            this.colY1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colY1.DefaultCellStyle.Format = "G6";
            this.colY2.HeaderText = "y2 (m)";
            this.colY2.Name = "colY2";
            this.colY2.ReadOnly = true;
            this.colY2.FillWeight = 70F;
            this.colY2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colY2.DefaultCellStyle.Format = "G6";
            this.colY3.HeaderText = "y3 (m)";
            this.colY3.Name = "colY3";
            this.colY3.ReadOnly = true;
            this.colY3.FillWeight = 70F;
            this.colY3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colY3.DefaultCellStyle.Format = "G6";
            //
            // gbAnalisis
            //
            this.gbAnalisis.Controls.Add(this.dgvAnalisis);
            this.gbAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAnalisis.Location = new System.Drawing.Point(520, 473);
            this.gbAnalisis.Name = "gbAnalisis";
            this.gbAnalisis.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.gbAnalisis.Size = new System.Drawing.Size(514, 382);
            this.gbAnalisis.TabIndex = 3;
            this.gbAnalisis.TabStop = false;
            this.gbAnalisis.Text = "Análisis de desplazamientos máximos";
            //
            // dgvAnalisis
            //
            this.dgvAnalisis.AllowUserToAddRows = false;
            this.dgvAnalisis.AllowUserToDeleteRows = false;
            this.dgvAnalisis.AllowUserToResizeRows = false;
            this.dgvAnalisis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalisis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMasa,
            this.colMaximo,
            this.colTiempoMaximo,
            this.colMinimo,
            this.colTiempoMinimo,
            this.colMaximoAbsoluto,
            this.colTiempoMaximoAbsoluto});
            this.dgvAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnalisis.Location = new System.Drawing.Point(6, 17);
            this.dgvAnalisis.Name = "dgvAnalisis";
            this.dgvAnalisis.ReadOnly = true;
            this.dgvAnalisis.RowHeadersVisible = false;
            this.dgvAnalisis.Size = new System.Drawing.Size(508, 358);
            this.dgvAnalisis.TabIndex = 0;
            //
            // Columnas de la tabla de análisis
            //
            this.colMasa.HeaderText = "Masa";
            this.colMasa.Name = "colMasa";
            this.colMasa.ReadOnly = true;
            this.colMasa.FillWeight = 50F;
            this.colMasa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaximo.HeaderText = "Máximo (m)";
            this.colMaximo.Name = "colMaximo";
            this.colMaximo.ReadOnly = true;
            this.colMaximo.FillWeight = 60F;
            this.colMaximo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaximo.DefaultCellStyle.Format = "G6";
            this.colTiempoMaximo.HeaderText = "t (s)";
            this.colTiempoMaximo.Name = "colTiempoMaximo";
            this.colTiempoMaximo.ReadOnly = true;
            this.colTiempoMaximo.FillWeight = 45F;
            this.colTiempoMaximo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTiempoMaximo.DefaultCellStyle.Format = "F4";
            this.colMinimo.HeaderText = "Mínimo (m)";
            this.colMinimo.Name = "colMinimo";
            this.colMinimo.ReadOnly = true;
            this.colMinimo.FillWeight = 60F;
            this.colMinimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMinimo.DefaultCellStyle.Format = "G6";
            this.colTiempoMinimo.HeaderText = "t (s)";
            this.colTiempoMinimo.Name = "colTiempoMinimo";
            this.colTiempoMinimo.ReadOnly = true;
            this.colTiempoMinimo.FillWeight = 45F;
            this.colTiempoMinimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTiempoMinimo.DefaultCellStyle.Format = "F4";
            this.colMaximoAbsoluto.HeaderText = "Máx. absoluto (m)";
            this.colMaximoAbsoluto.Name = "colMaximoAbsoluto";
            this.colMaximoAbsoluto.ReadOnly = true;
            this.colMaximoAbsoluto.FillWeight = 70F;
            this.colMaximoAbsoluto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaximoAbsoluto.DefaultCellStyle.Format = "G6";
            this.colTiempoMaximoAbsoluto.HeaderText = "t (s)";
            this.colTiempoMaximoAbsoluto.Name = "colTiempoMaximoAbsoluto";
            this.colTiempoMaximoAbsoluto.ReadOnly = true;
            this.colTiempoMaximoAbsoluto.FillWeight = 45F;
            this.colTiempoMaximoAbsoluto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTiempoMaximoAbsoluto.DefaultCellStyle.Format = "F4";
            //
            // timerAnimacion
            //
            this.timerAnimacion.Interval = 30;
            this.timerAnimacion.Tick += new System.EventHandler(this.timerAnimacion_Tick);
            //
            // errorProvider
            //
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = System.Drawing.SystemIcons.Error;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 861);
            this.Controls.Add(this.tlRaiz);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulación de 3 masas, 4 resortes y 3 amortiguadores";
            this.tlRaiz.ResumeLayout(false);
            this.tlLateral.ResumeLayout(false);
            this.gbParametros.ResumeLayout(false);
            this.gbParametros.PerformLayout();
            this.tlParametros.ResumeLayout(false);
            this.tlParametros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            this.tlAcciones.ResumeLayout(false);
            this.flBotones.ResumeLayout(false);
            this.tlContenido.ResumeLayout(false);
            this.gbGrafica.ResumeLayout(false);
            this.gbAnimacion.ResumeLayout(false);
            this.tlAnimacion.ResumeLayout(false);
            this.tlEstadoAnimacion.ResumeLayout(false);
            this.tlEstadoAnimacion.PerformLayout();
            this.gbMuestras.ResumeLayout(false);
            this.dgvMuestras.ResumeLayout(false);
            this.gbAnalisis.ResumeLayout(false);
            this.dgvAnalisis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
