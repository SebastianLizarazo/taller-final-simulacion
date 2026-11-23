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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tlRaiz = new System.Windows.Forms.TableLayoutPanel();
            tlLateral = new System.Windows.Forms.TableLayoutPanel();
            gbParametros = new System.Windows.Forms.GroupBox();
            panelParametros = new System.Windows.Forms.Panel();
            tlParametros = new System.Windows.Forms.TableLayoutPanel();
            lblCabeceraParametro = new System.Windows.Forms.Label();
            lblCabeceraValor = new System.Windows.Forms.Label();
            lblCabeceraUnidad = new System.Windows.Forms.Label();
            lblM1 = new System.Windows.Forms.Label();
            txtM1 = new System.Windows.Forms.TextBox();
            udM1 = new System.Windows.Forms.Label();
            lblM2 = new System.Windows.Forms.Label();
            txtM2 = new System.Windows.Forms.TextBox();
            udM2 = new System.Windows.Forms.Label();
            lblM3 = new System.Windows.Forms.Label();
            txtM3 = new System.Windows.Forms.TextBox();
            udM3 = new System.Windows.Forms.Label();
            lblK1 = new System.Windows.Forms.Label();
            txtK1 = new System.Windows.Forms.TextBox();
            udK1 = new System.Windows.Forms.Label();
            lblK2 = new System.Windows.Forms.Label();
            txtK2 = new System.Windows.Forms.TextBox();
            udK2 = new System.Windows.Forms.Label();
            lblK3 = new System.Windows.Forms.Label();
            txtK3 = new System.Windows.Forms.TextBox();
            udK3 = new System.Windows.Forms.Label();
            lblK4 = new System.Windows.Forms.Label();
            txtK4 = new System.Windows.Forms.TextBox();
            udK4 = new System.Windows.Forms.Label();
            lblB1 = new System.Windows.Forms.Label();
            txtB1 = new System.Windows.Forms.TextBox();
            udB1 = new System.Windows.Forms.Label();
            lblB2 = new System.Windows.Forms.Label();
            txtB2 = new System.Windows.Forms.TextBox();
            udB2 = new System.Windows.Forms.Label();
            lblB3 = new System.Windows.Forms.Label();
            txtB3 = new System.Windows.Forms.TextBox();
            udB3 = new System.Windows.Forms.Label();
            lblAmplitud = new System.Windows.Forms.Label();
            txtAmplitud = new System.Windows.Forms.TextBox();
            udAmplitud = new System.Windows.Forms.Label();
            lblDuracion = new System.Windows.Forms.Label();
            txtDuracion = new System.Windows.Forms.TextBox();
            udDuracion = new System.Windows.Forms.Label();
            lblTiempo = new System.Windows.Forms.Label();
            txtTiempo = new System.Windows.Forms.TextBox();
            udTiempo = new System.Windows.Forms.Label();
            lblMuestras = new System.Windows.Forms.Label();
            txtMuestras = new System.Windows.Forms.TextBox();
            udMuestras = new System.Windows.Forms.Label();
            lblEscala = new System.Windows.Forms.Label();
            txtEscala = new System.Windows.Forms.TextBox();
            udEscala = new System.Windows.Forms.Label();
            gbAcciones = new System.Windows.Forms.GroupBox();
            tlAcciones = new System.Windows.Forms.TableLayoutPanel();
            flBotones = new System.Windows.Forms.FlowLayoutPanel();
            btnSimular = new System.Windows.Forms.Button();
            btnReproducir = new System.Windows.Forms.Button();
            btnReiniciar = new System.Windows.Forms.Button();
            btnRestablecer = new System.Windows.Forms.Button();
            progressBarSimulacion = new System.Windows.Forms.ProgressBar();
            lblProgreso = new System.Windows.Forms.Label();
            lblAviso = new System.Windows.Forms.Label();
            tlContenido = new System.Windows.Forms.TableLayoutPanel();
            gbGrafica = new System.Windows.Forms.GroupBox();
            graficaPlot = new ScottPlot.WinForms.FormsPlot();
            gbAnimacion = new System.Windows.Forms.GroupBox();
            tlAnimacion = new System.Windows.Forms.TableLayoutPanel();
            panelAnimacion = new taller_final_simulacion.Controles.PanelDobleBuffer();
            tlEstadoAnimacion = new System.Windows.Forms.TableLayoutPanel();
            lblTiempoActual = new System.Windows.Forms.Label();
            lblFuerzaActual = new System.Windows.Forms.Label();
            lblY1Actual = new System.Windows.Forms.Label();
            lblY2Actual = new System.Windows.Forms.Label();
            lblY3Actual = new System.Windows.Forms.Label();
            lblAvisoEscala = new System.Windows.Forms.Label();
            gbMuestras = new System.Windows.Forms.GroupBox();
            dgvMuestras = new System.Windows.Forms.DataGridView();
            colIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFuerza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colY1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colY2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colY3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            gbAnalisis = new System.Windows.Forms.GroupBox();
            dgvAnalisis = new System.Windows.Forms.DataGridView();
            colMasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTiempoMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTiempoMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMaximoAbsoluto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTiempoMaximoAbsoluto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            timerAnimacion = new System.Windows.Forms.Timer(components);
            errorProvider = new System.Windows.Forms.ErrorProvider(components);
            tlRaiz.SuspendLayout();
            tlLateral.SuspendLayout();
            gbParametros.SuspendLayout();
            panelParametros.SuspendLayout();
            tlParametros.SuspendLayout();
            gbAcciones.SuspendLayout();
            tlAcciones.SuspendLayout();
            flBotones.SuspendLayout();
            tlContenido.SuspendLayout();
            gbGrafica.SuspendLayout();
            gbAnimacion.SuspendLayout();
            tlAnimacion.SuspendLayout();
            tlEstadoAnimacion.SuspendLayout();
            gbMuestras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMuestras).BeginInit();
            gbAnalisis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnalisis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // tlRaiz
            // 
            tlRaiz.ColumnCount = 2;
            tlRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 514F));
            tlRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlRaiz.Controls.Add(tlLateral, 0, 0);
            tlRaiz.Controls.Add(tlContenido, 1, 0);
            tlRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            tlRaiz.Location = new System.Drawing.Point(0, 0);
            tlRaiz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tlRaiz.Name = "tlRaiz";
            tlRaiz.RowCount = 1;
            tlRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlRaiz.Size = new System.Drawing.Size(2000, 1435);
            tlRaiz.TabIndex = 0;
            // 
            // tlLateral
            // 
            tlLateral.ColumnCount = 1;
            tlLateral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlLateral.Controls.Add(gbParametros, 0, 0);
            tlLateral.Controls.Add(gbAcciones, 0, 1);
            tlLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            tlLateral.Location = new System.Drawing.Point(4, 5);
            tlLateral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tlLateral.Name = "tlLateral";
            tlLateral.RowCount = 2;
            tlLateral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlLateral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 283F));
            tlLateral.Size = new System.Drawing.Size(506, 1425);
            tlLateral.TabIndex = 1;
            // 
            // gbParametros
            // 
            gbParametros.Controls.Add(panelParametros);
            gbParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            gbParametros.Location = new System.Drawing.Point(4, 5);
            gbParametros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbParametros.Name = "gbParametros";
            gbParametros.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbParametros.Size = new System.Drawing.Size(498, 1132);
            gbParametros.TabIndex = 0;
            gbParametros.TabStop = false;
            gbParametros.Text = "Parámetros del sistema";
            // 
            // panelParametros
            // 
            panelParametros.AutoScroll = true;
            panelParametros.Controls.Add(tlParametros);
            panelParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            panelParametros.Location = new System.Drawing.Point(4, 29);
            panelParametros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelParametros.Name = "panelParametros";
            panelParametros.Size = new System.Drawing.Size(490, 1098);
            panelParametros.TabIndex = 0;
            // 
            // tlParametros
            // 
            tlParametros.AutoSize = true;
            tlParametros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlParametros.ColumnCount = 3;
            tlParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            tlParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            tlParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlParametros.Controls.Add(lblCabeceraParametro, 0, 0);
            tlParametros.Controls.Add(lblCabeceraValor, 1, 0);
            tlParametros.Controls.Add(lblCabeceraUnidad, 2, 0);
            tlParametros.Controls.Add(lblM1, 0, 1);
            tlParametros.Controls.Add(txtM1, 1, 1);
            tlParametros.Controls.Add(udM1, 2, 1);
            tlParametros.Controls.Add(lblM2, 0, 2);
            tlParametros.Controls.Add(txtM2, 1, 2);
            tlParametros.Controls.Add(udM2, 2, 2);
            tlParametros.Controls.Add(lblM3, 0, 3);
            tlParametros.Controls.Add(txtM3, 1, 3);
            tlParametros.Controls.Add(udM3, 2, 3);
            tlParametros.Controls.Add(lblK1, 0, 4);
            tlParametros.Controls.Add(txtK1, 1, 4);
            tlParametros.Controls.Add(udK1, 2, 4);
            tlParametros.Controls.Add(lblK2, 0, 5);
            tlParametros.Controls.Add(txtK2, 1, 5);
            tlParametros.Controls.Add(udK2, 2, 5);
            tlParametros.Controls.Add(lblK3, 0, 6);
            tlParametros.Controls.Add(txtK3, 1, 6);
            tlParametros.Controls.Add(udK3, 2, 6);
            tlParametros.Controls.Add(lblK4, 0, 7);
            tlParametros.Controls.Add(txtK4, 1, 7);
            tlParametros.Controls.Add(udK4, 2, 7);
            tlParametros.Controls.Add(lblB1, 0, 8);
            tlParametros.Controls.Add(txtB1, 1, 8);
            tlParametros.Controls.Add(udB1, 2, 8);
            tlParametros.Controls.Add(lblB2, 0, 9);
            tlParametros.Controls.Add(txtB2, 1, 9);
            tlParametros.Controls.Add(udB2, 2, 9);
            tlParametros.Controls.Add(lblB3, 0, 10);
            tlParametros.Controls.Add(txtB3, 1, 10);
            tlParametros.Controls.Add(udB3, 2, 10);
            tlParametros.Controls.Add(lblAmplitud, 0, 11);
            tlParametros.Controls.Add(txtAmplitud, 1, 11);
            tlParametros.Controls.Add(udAmplitud, 2, 11);
            tlParametros.Controls.Add(lblDuracion, 0, 12);
            tlParametros.Controls.Add(txtDuracion, 1, 12);
            tlParametros.Controls.Add(udDuracion, 2, 12);
            tlParametros.Controls.Add(lblTiempo, 0, 13);
            tlParametros.Controls.Add(txtTiempo, 1, 13);
            tlParametros.Controls.Add(udTiempo, 2, 13);
            tlParametros.Controls.Add(lblMuestras, 0, 14);
            tlParametros.Controls.Add(txtMuestras, 1, 14);
            tlParametros.Controls.Add(udMuestras, 2, 14);
            tlParametros.Controls.Add(lblEscala, 0, 15);
            tlParametros.Controls.Add(txtEscala, 1, 15);
            tlParametros.Controls.Add(udEscala, 2, 15);
            tlParametros.Dock = System.Windows.Forms.DockStyle.Top;
            tlParametros.Location = new System.Drawing.Point(0, 0);
            tlParametros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tlParametros.Name = "tlParametros";
            tlParametros.RowCount = 16;
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tlParametros.Size = new System.Drawing.Size(490, 665);
            tlParametros.TabIndex = 0;
            // 
            // lblCabeceraParametro
            // 
            lblCabeceraParametro.AutoSize = true;
            lblCabeceraParametro.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCabeceraParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            lblCabeceraParametro.Location = new System.Drawing.Point(4, 0);
            lblCabeceraParametro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCabeceraParametro.Name = "lblCabeceraParametro";
            lblCabeceraParametro.Size = new System.Drawing.Size(206, 43);
            lblCabeceraParametro.TabIndex = 0;
            lblCabeceraParametro.Text = "Parámetro";
            lblCabeceraParametro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCabeceraValor
            // 
            lblCabeceraValor.AutoSize = true;
            lblCabeceraValor.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCabeceraValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            lblCabeceraValor.Location = new System.Drawing.Point(218, 0);
            lblCabeceraValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCabeceraValor.Name = "lblCabeceraValor";
            lblCabeceraValor.Size = new System.Drawing.Size(128, 43);
            lblCabeceraValor.TabIndex = 1;
            lblCabeceraValor.Text = "Valor";
            lblCabeceraValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCabeceraUnidad
            // 
            lblCabeceraUnidad.AutoSize = true;
            lblCabeceraUnidad.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCabeceraUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            lblCabeceraUnidad.Location = new System.Drawing.Point(354, 0);
            lblCabeceraUnidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCabeceraUnidad.Name = "lblCabeceraUnidad";
            lblCabeceraUnidad.Size = new System.Drawing.Size(139, 43);
            lblCabeceraUnidad.TabIndex = 2;
            lblCabeceraUnidad.Text = "Unidad";
            lblCabeceraUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblM1
            // 
            lblM1.AutoSize = true;
            lblM1.Dock = System.Windows.Forms.DockStyle.Fill;
            lblM1.Location = new System.Drawing.Point(4, 43);
            lblM1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblM1.Name = "lblM1";
            lblM1.Size = new System.Drawing.Size(206, 43);
            lblM1.TabIndex = 3;
            lblM1.Text = "m1  (masa)";
            lblM1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtM1
            // 
            txtM1.Dock = System.Windows.Forms.DockStyle.Fill;
            txtM1.Location = new System.Drawing.Point(218, 48);
            txtM1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtM1.Name = "txtM1";
            txtM1.Size = new System.Drawing.Size(128, 31);
            txtM1.TabIndex = 4;
            txtM1.Text = "1";
            // 
            // udM1
            // 
            udM1.AutoSize = true;
            udM1.Dock = System.Windows.Forms.DockStyle.Fill;
            udM1.Location = new System.Drawing.Point(354, 43);
            udM1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udM1.Name = "udM1";
            udM1.Size = new System.Drawing.Size(139, 43);
            udM1.TabIndex = 5;
            udM1.Text = "kg";
            udM1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblM2
            // 
            lblM2.AutoSize = true;
            lblM2.Dock = System.Windows.Forms.DockStyle.Fill;
            lblM2.Location = new System.Drawing.Point(4, 86);
            lblM2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblM2.Name = "lblM2";
            lblM2.Size = new System.Drawing.Size(206, 43);
            lblM2.TabIndex = 6;
            lblM2.Text = "m2  (masa)";
            lblM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtM2
            // 
            txtM2.Dock = System.Windows.Forms.DockStyle.Fill;
            txtM2.Location = new System.Drawing.Point(218, 91);
            txtM2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtM2.Name = "txtM2";
            txtM2.Size = new System.Drawing.Size(128, 31);
            txtM2.TabIndex = 7;
            txtM2.Text = "1";
            // 
            // udM2
            // 
            udM2.AutoSize = true;
            udM2.Dock = System.Windows.Forms.DockStyle.Fill;
            udM2.Location = new System.Drawing.Point(354, 86);
            udM2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udM2.Name = "udM2";
            udM2.Size = new System.Drawing.Size(139, 43);
            udM2.TabIndex = 8;
            udM2.Text = "kg";
            udM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblM3
            // 
            lblM3.AutoSize = true;
            lblM3.Dock = System.Windows.Forms.DockStyle.Fill;
            lblM3.Location = new System.Drawing.Point(4, 129);
            lblM3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblM3.Name = "lblM3";
            lblM3.Size = new System.Drawing.Size(206, 43);
            lblM3.TabIndex = 9;
            lblM3.Text = "m3  (masa)";
            lblM3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtM3
            // 
            txtM3.Dock = System.Windows.Forms.DockStyle.Fill;
            txtM3.Location = new System.Drawing.Point(218, 134);
            txtM3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtM3.Name = "txtM3";
            txtM3.Size = new System.Drawing.Size(128, 31);
            txtM3.TabIndex = 10;
            txtM3.Text = "1,5";
            // 
            // udM3
            // 
            udM3.AutoSize = true;
            udM3.Dock = System.Windows.Forms.DockStyle.Fill;
            udM3.Location = new System.Drawing.Point(354, 129);
            udM3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udM3.Name = "udM3";
            udM3.Size = new System.Drawing.Size(139, 43);
            udM3.TabIndex = 11;
            udM3.Text = "kg";
            udM3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblK1
            // 
            lblK1.AutoSize = true;
            lblK1.Dock = System.Windows.Forms.DockStyle.Fill;
            lblK1.Location = new System.Drawing.Point(4, 172);
            lblK1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblK1.Name = "lblK1";
            lblK1.Size = new System.Drawing.Size(206, 43);
            lblK1.TabIndex = 12;
            lblK1.Text = "k1  (resorte sup.-m1)";
            lblK1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtK1
            // 
            txtK1.Dock = System.Windows.Forms.DockStyle.Fill;
            txtK1.Location = new System.Drawing.Point(218, 177);
            txtK1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtK1.Name = "txtK1";
            txtK1.Size = new System.Drawing.Size(128, 31);
            txtK1.TabIndex = 13;
            txtK1.Text = "120";
            // 
            // udK1
            // 
            udK1.AutoSize = true;
            udK1.Dock = System.Windows.Forms.DockStyle.Fill;
            udK1.Location = new System.Drawing.Point(354, 172);
            udK1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udK1.Name = "udK1";
            udK1.Size = new System.Drawing.Size(139, 43);
            udK1.TabIndex = 14;
            udK1.Text = "N/m";
            udK1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblK2
            // 
            lblK2.AutoSize = true;
            lblK2.Dock = System.Windows.Forms.DockStyle.Fill;
            lblK2.Location = new System.Drawing.Point(4, 215);
            lblK2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblK2.Name = "lblK2";
            lblK2.Size = new System.Drawing.Size(206, 43);
            lblK2.TabIndex = 15;
            lblK2.Text = "k2  (resorte m1-m3)";
            lblK2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtK2
            // 
            txtK2.Dock = System.Windows.Forms.DockStyle.Fill;
            txtK2.Location = new System.Drawing.Point(218, 220);
            txtK2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtK2.Name = "txtK2";
            txtK2.Size = new System.Drawing.Size(128, 31);
            txtK2.TabIndex = 16;
            txtK2.Text = "80";
            // 
            // udK2
            // 
            udK2.AutoSize = true;
            udK2.Dock = System.Windows.Forms.DockStyle.Fill;
            udK2.Location = new System.Drawing.Point(354, 215);
            udK2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udK2.Name = "udK2";
            udK2.Size = new System.Drawing.Size(139, 43);
            udK2.TabIndex = 17;
            udK2.Text = "N/m";
            udK2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblK3
            // 
            lblK3.AutoSize = true;
            lblK3.Dock = System.Windows.Forms.DockStyle.Fill;
            lblK3.Location = new System.Drawing.Point(4, 258);
            lblK3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblK3.Name = "lblK3";
            lblK3.Size = new System.Drawing.Size(206, 43);
            lblK3.TabIndex = 18;
            lblK3.Text = "k3  (resorte m3-sup.inf.)";
            lblK3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtK3
            // 
            txtK3.Dock = System.Windows.Forms.DockStyle.Fill;
            txtK3.Location = new System.Drawing.Point(218, 263);
            txtK3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtK3.Name = "txtK3";
            txtK3.Size = new System.Drawing.Size(128, 31);
            txtK3.TabIndex = 19;
            txtK3.Text = "100";
            // 
            // udK3
            // 
            udK3.AutoSize = true;
            udK3.Dock = System.Windows.Forms.DockStyle.Fill;
            udK3.Location = new System.Drawing.Point(354, 258);
            udK3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udK3.Name = "udK3";
            udK3.Size = new System.Drawing.Size(139, 43);
            udK3.TabIndex = 20;
            udK3.Text = "N/m";
            udK3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblK4
            // 
            lblK4.AutoSize = true;
            lblK4.Dock = System.Windows.Forms.DockStyle.Fill;
            lblK4.Location = new System.Drawing.Point(4, 301);
            lblK4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblK4.Name = "lblK4";
            lblK4.Size = new System.Drawing.Size(206, 43);
            lblK4.TabIndex = 21;
            lblK4.Text = "k4  (resorte sup.-m2)";
            lblK4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtK4
            // 
            txtK4.Dock = System.Windows.Forms.DockStyle.Fill;
            txtK4.Location = new System.Drawing.Point(218, 306);
            txtK4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtK4.Name = "txtK4";
            txtK4.Size = new System.Drawing.Size(128, 31);
            txtK4.TabIndex = 22;
            txtK4.Text = "90";
            // 
            // udK4
            // 
            udK4.AutoSize = true;
            udK4.Dock = System.Windows.Forms.DockStyle.Fill;
            udK4.Location = new System.Drawing.Point(354, 301);
            udK4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udK4.Name = "udK4";
            udK4.Size = new System.Drawing.Size(139, 43);
            udK4.TabIndex = 23;
            udK4.Text = "N/m";
            udK4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblB1
            // 
            lblB1.AutoSize = true;
            lblB1.Dock = System.Windows.Forms.DockStyle.Fill;
            lblB1.Location = new System.Drawing.Point(4, 344);
            lblB1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblB1.Name = "lblB1";
            lblB1.Size = new System.Drawing.Size(206, 43);
            lblB1.TabIndex = 24;
            lblB1.Text = "b1  (amort. sup.-m1)";
            lblB1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtB1
            // 
            txtB1.Dock = System.Windows.Forms.DockStyle.Fill;
            txtB1.Location = new System.Drawing.Point(218, 349);
            txtB1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtB1.Name = "txtB1";
            txtB1.Size = new System.Drawing.Size(128, 31);
            txtB1.TabIndex = 25;
            txtB1.Text = "2";
            // 
            // udB1
            // 
            udB1.AutoSize = true;
            udB1.Dock = System.Windows.Forms.DockStyle.Fill;
            udB1.Location = new System.Drawing.Point(354, 344);
            udB1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udB1.Name = "udB1";
            udB1.Size = new System.Drawing.Size(139, 43);
            udB1.TabIndex = 26;
            udB1.Text = "N·s/m";
            udB1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblB2
            // 
            lblB2.AutoSize = true;
            lblB2.Dock = System.Windows.Forms.DockStyle.Fill;
            lblB2.Location = new System.Drawing.Point(4, 387);
            lblB2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblB2.Name = "lblB2";
            lblB2.Size = new System.Drawing.Size(206, 43);
            lblB2.TabIndex = 27;
            lblB2.Text = "b2  (amort. sup.-m2)";
            lblB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtB2
            // 
            txtB2.Dock = System.Windows.Forms.DockStyle.Fill;
            txtB2.Location = new System.Drawing.Point(218, 392);
            txtB2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtB2.Name = "txtB2";
            txtB2.Size = new System.Drawing.Size(128, 31);
            txtB2.TabIndex = 28;
            txtB2.Text = "1,5";
            // 
            // udB2
            // 
            udB2.AutoSize = true;
            udB2.Dock = System.Windows.Forms.DockStyle.Fill;
            udB2.Location = new System.Drawing.Point(354, 387);
            udB2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udB2.Name = "udB2";
            udB2.Size = new System.Drawing.Size(139, 43);
            udB2.TabIndex = 29;
            udB2.Text = "N·s/m";
            udB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblB3
            // 
            lblB3.AutoSize = true;
            lblB3.Dock = System.Windows.Forms.DockStyle.Fill;
            lblB3.Location = new System.Drawing.Point(4, 430);
            lblB3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblB3.Name = "lblB3";
            lblB3.Size = new System.Drawing.Size(206, 43);
            lblB3.TabIndex = 30;
            lblB3.Text = "b3  (amort. m2-m3)";
            lblB3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtB3
            // 
            txtB3.Dock = System.Windows.Forms.DockStyle.Fill;
            txtB3.Location = new System.Drawing.Point(218, 435);
            txtB3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtB3.Name = "txtB3";
            txtB3.Size = new System.Drawing.Size(128, 31);
            txtB3.TabIndex = 31;
            txtB3.Text = "1";
            // 
            // udB3
            // 
            udB3.AutoSize = true;
            udB3.Dock = System.Windows.Forms.DockStyle.Fill;
            udB3.Location = new System.Drawing.Point(354, 430);
            udB3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udB3.Name = "udB3";
            udB3.Size = new System.Drawing.Size(139, 43);
            udB3.TabIndex = 32;
            udB3.Text = "N·s/m";
            udB3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmplitud
            // 
            lblAmplitud.AutoSize = true;
            lblAmplitud.Dock = System.Windows.Forms.DockStyle.Fill;
            lblAmplitud.Location = new System.Drawing.Point(4, 473);
            lblAmplitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAmplitud.Name = "lblAmplitud";
            lblAmplitud.Size = new System.Drawing.Size(206, 43);
            lblAmplitud.TabIndex = 33;
            lblAmplitud.Text = "A  (amplitud de F)";
            lblAmplitud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmplitud
            // 
            txtAmplitud.Dock = System.Windows.Forms.DockStyle.Fill;
            txtAmplitud.Location = new System.Drawing.Point(218, 478);
            txtAmplitud.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtAmplitud.Name = "txtAmplitud";
            txtAmplitud.Size = new System.Drawing.Size(128, 31);
            txtAmplitud.TabIndex = 34;
            txtAmplitud.Text = "10";
            // 
            // udAmplitud
            // 
            udAmplitud.AutoSize = true;
            udAmplitud.Dock = System.Windows.Forms.DockStyle.Fill;
            udAmplitud.Location = new System.Drawing.Point(354, 473);
            udAmplitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udAmplitud.Name = "udAmplitud";
            udAmplitud.Size = new System.Drawing.Size(139, 43);
            udAmplitud.TabIndex = 35;
            udAmplitud.Text = "N";
            udAmplitud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDuracion.Location = new System.Drawing.Point(4, 516);
            lblDuracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new System.Drawing.Size(206, 43);
            lblDuracion.TabIndex = 36;
            lblDuracion.Text = "Tf  (duración de F)";
            lblDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDuracion
            // 
            txtDuracion.Dock = System.Windows.Forms.DockStyle.Fill;
            txtDuracion.Location = new System.Drawing.Point(218, 521);
            txtDuracion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new System.Drawing.Size(128, 31);
            txtDuracion.TabIndex = 37;
            txtDuracion.Text = "1";
            // 
            // udDuracion
            // 
            udDuracion.AutoSize = true;
            udDuracion.Dock = System.Windows.Forms.DockStyle.Fill;
            udDuracion.Location = new System.Drawing.Point(354, 516);
            udDuracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udDuracion.Name = "udDuracion";
            udDuracion.Size = new System.Drawing.Size(139, 43);
            udDuracion.TabIndex = 38;
            udDuracion.Text = "s";
            udDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTiempo.Location = new System.Drawing.Point(4, 559);
            lblTiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new System.Drawing.Size(206, 43);
            lblTiempo.TabIndex = 39;
            lblTiempo.Text = "T  (tiempo simulación)";
            lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTiempo
            // 
            txtTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            txtTiempo.Location = new System.Drawing.Point(218, 564);
            txtTiempo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtTiempo.Name = "txtTiempo";
            txtTiempo.Size = new System.Drawing.Size(128, 31);
            txtTiempo.TabIndex = 40;
            txtTiempo.Text = "10";
            // 
            // udTiempo
            // 
            udTiempo.AutoSize = true;
            udTiempo.Dock = System.Windows.Forms.DockStyle.Fill;
            udTiempo.Location = new System.Drawing.Point(354, 559);
            udTiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udTiempo.Name = "udTiempo";
            udTiempo.Size = new System.Drawing.Size(139, 43);
            udTiempo.TabIndex = 41;
            udTiempo.Text = "s";
            udTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMuestras
            // 
            lblMuestras.AutoSize = true;
            lblMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            lblMuestras.Location = new System.Drawing.Point(4, 602);
            lblMuestras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMuestras.Name = "lblMuestras";
            lblMuestras.Size = new System.Drawing.Size(206, 43);
            lblMuestras.TabIndex = 42;
            lblMuestras.Text = "N  (nº de muestras)";
            lblMuestras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMuestras
            // 
            txtMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            txtMuestras.Location = new System.Drawing.Point(218, 607);
            txtMuestras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtMuestras.Name = "txtMuestras";
            txtMuestras.Size = new System.Drawing.Size(128, 31);
            txtMuestras.TabIndex = 43;
            txtMuestras.Text = "1000";
            // 
            // udMuestras
            // 
            udMuestras.AutoSize = true;
            udMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            udMuestras.Location = new System.Drawing.Point(354, 602);
            udMuestras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udMuestras.Name = "udMuestras";
            udMuestras.Size = new System.Drawing.Size(139, 43);
            udMuestras.TabIndex = 44;
            udMuestras.Text = "-";
            udMuestras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEscala
            // 
            lblEscala.AutoSize = true;
            lblEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            lblEscala.Location = new System.Drawing.Point(4, 645);
            lblEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEscala.Name = "lblEscala";
            lblEscala.Size = new System.Drawing.Size(206, 43);
            lblEscala.TabIndex = 45;
            lblEscala.Text = "Escala  (animación)";
            lblEscala.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEscala
            // 
            txtEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            txtEscala.Location = new System.Drawing.Point(218, 650);
            txtEscala.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtEscala.Name = "txtEscala";
            txtEscala.Size = new System.Drawing.Size(128, 31);
            txtEscala.TabIndex = 46;
            txtEscala.Text = "100";
            // 
            // udEscala
            // 
            udEscala.AutoSize = true;
            udEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            udEscala.Location = new System.Drawing.Point(354, 645);
            udEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            udEscala.Name = "udEscala";
            udEscala.Size = new System.Drawing.Size(139, 43);
            udEscala.TabIndex = 47;
            udEscala.Text = "px/m";
            udEscala.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbAcciones
            // 
            gbAcciones.Controls.Add(tlAcciones);
            gbAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            gbAcciones.Location = new System.Drawing.Point(4, 1147);
            gbAcciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbAcciones.Name = "gbAcciones";
            gbAcciones.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbAcciones.Size = new System.Drawing.Size(498, 273);
            gbAcciones.TabIndex = 1;
            gbAcciones.TabStop = false;
            gbAcciones.Text = "Acciones";
            // 
            // tlAcciones
            // 
            tlAcciones.ColumnCount = 1;
            tlAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlAcciones.Controls.Add(flBotones, 0, 0);
            tlAcciones.Controls.Add(progressBarSimulacion, 0, 1);
            tlAcciones.Controls.Add(lblProgreso, 0, 2);
            tlAcciones.Controls.Add(lblAviso, 0, 3);
            tlAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            tlAcciones.Location = new System.Drawing.Point(4, 29);
            tlAcciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tlAcciones.Name = "tlAcciones";
            tlAcciones.RowCount = 4;
            tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            tlAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlAcciones.Size = new System.Drawing.Size(490, 239);
            tlAcciones.TabIndex = 0;
            // 
            // flBotones
            // 
            flBotones.Controls.Add(btnSimular);
            flBotones.Controls.Add(btnReproducir);
            flBotones.Controls.Add(btnReiniciar);
            flBotones.Controls.Add(btnRestablecer);
            flBotones.AutoSize = true;
            flBotones.Dock = System.Windows.Forms.DockStyle.Top;
            flBotones.Location = new System.Drawing.Point(4, 5);
            flBotones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            flBotones.Name = "flBotones";
            flBotones.Size = new System.Drawing.Size(482, 93);
            flBotones.TabIndex = 0;
            // 
            // btnSimular
            // 
            btnSimular.AutoSize = true;
            btnSimular.Location = new System.Drawing.Point(4, 5);
            btnSimular.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnSimular.Name = "btnSimular";
            btnSimular.Size = new System.Drawing.Size(121, 58);
            btnSimular.TabIndex = 0;
            btnSimular.Text = "Simular";
            btnSimular.UseVisualStyleBackColor = true;
            btnSimular.Click += btnSimular_Click;
            // 
            // btnReproducir
            // 
            btnReproducir.AutoSize = true;
            btnReproducir.Location = new System.Drawing.Point(133, 5);
            btnReproducir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnReproducir.Name = "btnReproducir";
            btnReproducir.Size = new System.Drawing.Size(161, 58);
            btnReproducir.TabIndex = 1;
            btnReproducir.Text = "Reproducir";
            btnReproducir.UseVisualStyleBackColor = true;
            btnReproducir.Click += btnReproducir_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.AutoSize = true;
            btnReiniciar.Location = new System.Drawing.Point(4, 73);
            btnReiniciar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new System.Drawing.Size(246, 58);
            btnReiniciar.TabIndex = 2;
            btnReiniciar.Text = "Reiniciar animación";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // btnRestablecer
            // 
            btnRestablecer.AutoSize = true;
            btnRestablecer.Location = new System.Drawing.Point(258, 73);
            btnRestablecer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnRestablecer.Name = "btnRestablecer";
            btnRestablecer.Size = new System.Drawing.Size(159, 58);
            btnRestablecer.TabIndex = 3;
            btnRestablecer.Text = "Restablecer";
            btnRestablecer.UseVisualStyleBackColor = true;
            btnRestablecer.Click += btnRestablecer_Click;
            // 
            // progressBarSimulacion
            // 
            progressBarSimulacion.Dock = System.Windows.Forms.DockStyle.Fill;
            progressBarSimulacion.Location = new System.Drawing.Point(4, 108);
            progressBarSimulacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            progressBarSimulacion.Name = "progressBarSimulacion";
            progressBarSimulacion.Size = new System.Drawing.Size(482, 23);
            progressBarSimulacion.TabIndex = 1;
            // 
            // lblProgreso
            // 
            lblProgreso.Dock = System.Windows.Forms.DockStyle.Fill;
            lblProgreso.Location = new System.Drawing.Point(4, 136);
            lblProgreso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblProgreso.Name = "lblProgreso";
            lblProgreso.Size = new System.Drawing.Size(482, 33);
            lblProgreso.TabIndex = 2;
            lblProgreso.Text = "Listo para simular.";
            lblProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAviso
            // 
            lblAviso.Dock = System.Windows.Forms.DockStyle.Fill;
            lblAviso.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            lblAviso.Location = new System.Drawing.Point(4, 169);
            lblAviso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new System.Drawing.Size(482, 70);
            lblAviso.TabIndex = 3;
            // 
            // tlContenido
            // 
            tlContenido.ColumnCount = 2;
            tlContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlContenido.Controls.Add(gbGrafica, 0, 0);
            tlContenido.Controls.Add(gbAnimacion, 1, 0);
            tlContenido.Controls.Add(gbMuestras, 0, 1);
            tlContenido.Controls.Add(gbAnalisis, 1, 1);
            tlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            tlContenido.Location = new System.Drawing.Point(518, 5);
            tlContenido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tlContenido.Name = "tlContenido";
            tlContenido.RowCount = 2;
            tlContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            tlContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            tlContenido.Size = new System.Drawing.Size(1478, 1425);
            tlContenido.TabIndex = 2;
            // 
            // gbGrafica
            // 
            gbGrafica.Controls.Add(graficaPlot);
            gbGrafica.Dock = System.Windows.Forms.DockStyle.Fill;
            gbGrafica.Location = new System.Drawing.Point(4, 5);
            gbGrafica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbGrafica.Name = "gbGrafica";
            gbGrafica.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbGrafica.Size = new System.Drawing.Size(731, 773);
            gbGrafica.TabIndex = 0;
            gbGrafica.TabStop = false;
            gbGrafica.Text = "Respuesta temporal (ScottPlot)";
            // 
            // graficaPlot
            // 
            graficaPlot.DisplayScale = 1.5F;
            graficaPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            graficaPlot.Location = new System.Drawing.Point(4, 29);
            graficaPlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            graficaPlot.Name = "graficaPlot";
            graficaPlot.Size = new System.Drawing.Size(723, 739);
            graficaPlot.TabIndex = 0;
            // 
            // gbAnimacion
            // 
            gbAnimacion.Controls.Add(tlAnimacion);
            gbAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            gbAnimacion.Location = new System.Drawing.Point(743, 5);
            gbAnimacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbAnimacion.Name = "gbAnimacion";
            gbAnimacion.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbAnimacion.Size = new System.Drawing.Size(731, 773);
            gbAnimacion.TabIndex = 1;
            gbAnimacion.TabStop = false;
            gbAnimacion.Text = "Animación del sistema";
            // 
            // tlAnimacion
            // 
            tlAnimacion.ColumnCount = 1;
            tlAnimacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlAnimacion.Controls.Add(panelAnimacion, 0, 0);
            tlAnimacion.Controls.Add(tlEstadoAnimacion, 0, 1);
            tlAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            tlAnimacion.Location = new System.Drawing.Point(4, 29);
            tlAnimacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tlAnimacion.Name = "tlAnimacion";
            tlAnimacion.RowCount = 2;
            tlAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            tlAnimacion.Size = new System.Drawing.Size(723, 739);
            tlAnimacion.TabIndex = 0;
            // 
            // panelAnimacion
            // 
            panelAnimacion.BackColor = System.Drawing.Color.FromArgb(250, 250, 252);
            panelAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            panelAnimacion.Location = new System.Drawing.Point(4, 5);
            panelAnimacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelAnimacion.Name = "panelAnimacion";
            panelAnimacion.Size = new System.Drawing.Size(715, 609);
            panelAnimacion.TabIndex = 0;
            panelAnimacion.Paint += panelAnimacion_Paint;
            // 
            // tlEstadoAnimacion
            // 
            tlEstadoAnimacion.ColumnCount = 2;
            tlEstadoAnimacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlEstadoAnimacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlEstadoAnimacion.Controls.Add(lblTiempoActual, 0, 0);
            tlEstadoAnimacion.Controls.Add(lblFuerzaActual, 1, 0);
            tlEstadoAnimacion.Controls.Add(lblY1Actual, 0, 1);
            tlEstadoAnimacion.Controls.Add(lblY2Actual, 1, 1);
            tlEstadoAnimacion.Controls.Add(lblY3Actual, 0, 2);
            tlEstadoAnimacion.Controls.Add(lblAvisoEscala, 1, 2);
            tlEstadoAnimacion.Dock = System.Windows.Forms.DockStyle.Fill;
            tlEstadoAnimacion.Location = new System.Drawing.Point(4, 624);
            tlEstadoAnimacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tlEstadoAnimacion.Name = "tlEstadoAnimacion";
            tlEstadoAnimacion.RowCount = 3;
            tlEstadoAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tlEstadoAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tlEstadoAnimacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tlEstadoAnimacion.Size = new System.Drawing.Size(715, 110);
            tlEstadoAnimacion.TabIndex = 1;
            // 
            // lblTiempoActual
            // 
            lblTiempoActual.AutoSize = true;
            lblTiempoActual.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTiempoActual.Location = new System.Drawing.Point(4, 0);
            lblTiempoActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTiempoActual.Name = "lblTiempoActual";
            lblTiempoActual.Size = new System.Drawing.Size(349, 40);
            lblTiempoActual.TabIndex = 0;
            lblTiempoActual.Text = "t = --";
            lblTiempoActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFuerzaActual
            // 
            lblFuerzaActual.AutoSize = true;
            lblFuerzaActual.Dock = System.Windows.Forms.DockStyle.Fill;
            lblFuerzaActual.Location = new System.Drawing.Point(361, 0);
            lblFuerzaActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFuerzaActual.Name = "lblFuerzaActual";
            lblFuerzaActual.Size = new System.Drawing.Size(350, 40);
            lblFuerzaActual.TabIndex = 1;
            lblFuerzaActual.Text = "F = --";
            lblFuerzaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblY1Actual
            // 
            lblY1Actual.AutoSize = true;
            lblY1Actual.Dock = System.Windows.Forms.DockStyle.Fill;
            lblY1Actual.Location = new System.Drawing.Point(4, 40);
            lblY1Actual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblY1Actual.Name = "lblY1Actual";
            lblY1Actual.Size = new System.Drawing.Size(349, 40);
            lblY1Actual.TabIndex = 2;
            lblY1Actual.Text = "y1 = --";
            lblY1Actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblY2Actual
            // 
            lblY2Actual.AutoSize = true;
            lblY2Actual.Dock = System.Windows.Forms.DockStyle.Fill;
            lblY2Actual.Location = new System.Drawing.Point(361, 40);
            lblY2Actual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblY2Actual.Name = "lblY2Actual";
            lblY2Actual.Size = new System.Drawing.Size(350, 40);
            lblY2Actual.TabIndex = 3;
            lblY2Actual.Text = "y2 = --";
            lblY2Actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblY3Actual
            // 
            lblY3Actual.AutoSize = true;
            lblY3Actual.Dock = System.Windows.Forms.DockStyle.Fill;
            lblY3Actual.Location = new System.Drawing.Point(4, 80);
            lblY3Actual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblY3Actual.Name = "lblY3Actual";
            lblY3Actual.Size = new System.Drawing.Size(349, 40);
            lblY3Actual.TabIndex = 4;
            lblY3Actual.Text = "y3 = --";
            lblY3Actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAvisoEscala
            // 
            lblAvisoEscala.AutoSize = true;
            lblAvisoEscala.Dock = System.Windows.Forms.DockStyle.Fill;
            lblAvisoEscala.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            lblAvisoEscala.Location = new System.Drawing.Point(361, 80);
            lblAvisoEscala.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAvisoEscala.Name = "lblAvisoEscala";
            lblAvisoEscala.Size = new System.Drawing.Size(350, 40);
            lblAvisoEscala.TabIndex = 5;
            lblAvisoEscala.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbMuestras
            // 
            gbMuestras.Controls.Add(dgvMuestras);
            gbMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            gbMuestras.Location = new System.Drawing.Point(4, 788);
            gbMuestras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbMuestras.Name = "gbMuestras";
            gbMuestras.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbMuestras.Size = new System.Drawing.Size(731, 632);
            gbMuestras.TabIndex = 2;
            gbMuestras.TabStop = false;
            gbMuestras.Text = "Muestras calculadas";
            // 
            // dgvMuestras
            // 
            dgvMuestras.AllowUserToAddRows = false;
            dgvMuestras.AllowUserToDeleteRows = false;
            dgvMuestras.AllowUserToResizeRows = false;
            dgvMuestras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMuestras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colIndice, colTiempo, colFuerza, colY1, colY2, colY3 });
            dgvMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMuestras.Location = new System.Drawing.Point(4, 29);
            dgvMuestras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dgvMuestras.Name = "dgvMuestras";
            dgvMuestras.ReadOnly = true;
            dgvMuestras.RowHeadersVisible = false;
            dgvMuestras.RowHeadersWidth = 62;
            dgvMuestras.Size = new System.Drawing.Size(723, 598);
            dgvMuestras.TabIndex = 0;
            dgvMuestras.VirtualMode = true;
            dgvMuestras.CellClick += dgvMuestras_CellClick;
            dgvMuestras.CellValueNeeded += dgvMuestras_CellValueNeeded;
            // 
            // colIndice
            // 
            dataGridViewCellStyle1.Format = "0";
            colIndice.DefaultCellStyle = dataGridViewCellStyle1;
            colIndice.FillWeight = 40F;
            colIndice.HeaderText = "i";
            colIndice.MinimumWidth = 8;
            colIndice.Name = "colIndice";
            colIndice.ReadOnly = true;
            colIndice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTiempo
            // 
            dataGridViewCellStyle2.Format = "F6";
            colTiempo.DefaultCellStyle = dataGridViewCellStyle2;
            colTiempo.FillWeight = 70F;
            colTiempo.HeaderText = "t (s)";
            colTiempo.MinimumWidth = 8;
            colTiempo.Name = "colTiempo";
            colTiempo.ReadOnly = true;
            colTiempo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFuerza
            // 
            dataGridViewCellStyle3.Format = "G6";
            colFuerza.DefaultCellStyle = dataGridViewCellStyle3;
            colFuerza.FillWeight = 70F;
            colFuerza.HeaderText = "F(t) (N)";
            colFuerza.MinimumWidth = 8;
            colFuerza.Name = "colFuerza";
            colFuerza.ReadOnly = true;
            colFuerza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colY1
            // 
            dataGridViewCellStyle4.Format = "G6";
            colY1.DefaultCellStyle = dataGridViewCellStyle4;
            colY1.FillWeight = 70F;
            colY1.HeaderText = "y1 (m)";
            colY1.MinimumWidth = 8;
            colY1.Name = "colY1";
            colY1.ReadOnly = true;
            colY1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colY2
            // 
            dataGridViewCellStyle5.Format = "G6";
            colY2.DefaultCellStyle = dataGridViewCellStyle5;
            colY2.FillWeight = 70F;
            colY2.HeaderText = "y2 (m)";
            colY2.MinimumWidth = 8;
            colY2.Name = "colY2";
            colY2.ReadOnly = true;
            colY2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colY3
            // 
            dataGridViewCellStyle6.Format = "G6";
            colY3.DefaultCellStyle = dataGridViewCellStyle6;
            colY3.FillWeight = 70F;
            colY3.HeaderText = "y3 (m)";
            colY3.MinimumWidth = 8;
            colY3.Name = "colY3";
            colY3.ReadOnly = true;
            colY3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gbAnalisis
            // 
            gbAnalisis.Controls.Add(dgvAnalisis);
            gbAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            gbAnalisis.Location = new System.Drawing.Point(743, 788);
            gbAnalisis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbAnalisis.Name = "gbAnalisis";
            gbAnalisis.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gbAnalisis.Size = new System.Drawing.Size(731, 632);
            gbAnalisis.TabIndex = 3;
            gbAnalisis.TabStop = false;
            gbAnalisis.Text = "Análisis de desplazamientos máximos";
            // 
            // dgvAnalisis
            // 
            dgvAnalisis.AllowUserToAddRows = false;
            dgvAnalisis.AllowUserToDeleteRows = false;
            dgvAnalisis.AllowUserToResizeRows = false;
            dgvAnalisis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalisis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colMasa, colMaximo, colTiempoMaximo, colMinimo, colTiempoMinimo, colMaximoAbsoluto, colTiempoMaximoAbsoluto });
            dgvAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAnalisis.Location = new System.Drawing.Point(4, 29);
            dgvAnalisis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dgvAnalisis.Name = "dgvAnalisis";
            dgvAnalisis.ReadOnly = true;
            dgvAnalisis.RowHeadersVisible = false;
            dgvAnalisis.RowHeadersWidth = 62;
            dgvAnalisis.Size = new System.Drawing.Size(723, 598);
            dgvAnalisis.TabIndex = 0;
            // 
            // colMasa
            // 
            colMasa.FillWeight = 50F;
            colMasa.HeaderText = "Masa";
            colMasa.MinimumWidth = 8;
            colMasa.Name = "colMasa";
            colMasa.ReadOnly = true;
            colMasa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMaximo
            // 
            dataGridViewCellStyle7.Format = "G6";
            colMaximo.DefaultCellStyle = dataGridViewCellStyle7;
            colMaximo.FillWeight = 60F;
            colMaximo.HeaderText = "Máximo (m)";
            colMaximo.MinimumWidth = 8;
            colMaximo.Name = "colMaximo";
            colMaximo.ReadOnly = true;
            colMaximo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTiempoMaximo
            // 
            dataGridViewCellStyle8.Format = "F4";
            colTiempoMaximo.DefaultCellStyle = dataGridViewCellStyle8;
            colTiempoMaximo.FillWeight = 45F;
            colTiempoMaximo.HeaderText = "t (s)";
            colTiempoMaximo.MinimumWidth = 8;
            colTiempoMaximo.Name = "colTiempoMaximo";
            colTiempoMaximo.ReadOnly = true;
            colTiempoMaximo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMinimo
            // 
            dataGridViewCellStyle9.Format = "G6";
            colMinimo.DefaultCellStyle = dataGridViewCellStyle9;
            colMinimo.FillWeight = 60F;
            colMinimo.HeaderText = "Mínimo (m)";
            colMinimo.MinimumWidth = 8;
            colMinimo.Name = "colMinimo";
            colMinimo.ReadOnly = true;
            colMinimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTiempoMinimo
            // 
            dataGridViewCellStyle10.Format = "F4";
            colTiempoMinimo.DefaultCellStyle = dataGridViewCellStyle10;
            colTiempoMinimo.FillWeight = 45F;
            colTiempoMinimo.HeaderText = "t (s)";
            colTiempoMinimo.MinimumWidth = 8;
            colTiempoMinimo.Name = "colTiempoMinimo";
            colTiempoMinimo.ReadOnly = true;
            colTiempoMinimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMaximoAbsoluto
            // 
            dataGridViewCellStyle11.Format = "G6";
            colMaximoAbsoluto.DefaultCellStyle = dataGridViewCellStyle11;
            colMaximoAbsoluto.FillWeight = 70F;
            colMaximoAbsoluto.HeaderText = "Máx. absoluto (m)";
            colMaximoAbsoluto.MinimumWidth = 8;
            colMaximoAbsoluto.Name = "colMaximoAbsoluto";
            colMaximoAbsoluto.ReadOnly = true;
            colMaximoAbsoluto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTiempoMaximoAbsoluto
            // 
            dataGridViewCellStyle12.Format = "F4";
            colTiempoMaximoAbsoluto.DefaultCellStyle = dataGridViewCellStyle12;
            colTiempoMaximoAbsoluto.FillWeight = 45F;
            colTiempoMaximoAbsoluto.HeaderText = "t (s)";
            colTiempoMaximoAbsoluto.MinimumWidth = 8;
            colTiempoMaximoAbsoluto.Name = "colTiempoMaximoAbsoluto";
            colTiempoMaximoAbsoluto.ReadOnly = true;
            colTiempoMaximoAbsoluto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // timerAnimacion
            // 
            timerAnimacion.Interval = 30;
            timerAnimacion.Tick += timerAnimacion_Tick;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            errorProvider.Icon = (System.Drawing.Icon)resources.GetObject("errorProvider.Icon")!;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2000, 1435);
            Controls.Add(tlRaiz);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MinimumSize = new System.Drawing.Size(1562, 1126);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Simulación de 3 masas, 4 resortes y 3 amortiguadores";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            tlRaiz.ResumeLayout(false);
            tlLateral.ResumeLayout(false);
            gbParametros.ResumeLayout(false);
            panelParametros.ResumeLayout(false);
            panelParametros.PerformLayout();
            tlParametros.ResumeLayout(false);
            tlParametros.PerformLayout();
            gbAcciones.ResumeLayout(false);
            tlAcciones.ResumeLayout(false);
            flBotones.ResumeLayout(false);
            flBotones.PerformLayout();
            tlContenido.ResumeLayout(false);
            gbGrafica.ResumeLayout(false);
            gbAnimacion.ResumeLayout(false);
            tlAnimacion.ResumeLayout(false);
            tlEstadoAnimacion.ResumeLayout(false);
            tlEstadoAnimacion.PerformLayout();
            gbMuestras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMuestras).EndInit();
            gbAnalisis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAnalisis).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);

        }

        #endregion
    }
}
