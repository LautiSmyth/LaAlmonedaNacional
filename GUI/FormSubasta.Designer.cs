using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FormSubasta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.pnlCrear = new Panel();
            this.rbSoloLotes = new RadioButton();
            this.rbSoloArticulos = new RadioButton();
            this.rbTodos = new RadioButton();
            this.btnCrearSubasta = new Button();
            this.cmbItem = new ComboBox();
            this.lblSelItem = new Label();
            this.lblCrearTitulo = new Label();
            this.splitV = new SplitContainer();
            this.lstSubastas = new ListBox();
            this.lblListaSub = new Label();
            this.lblItemSubasta = new Label();
            this.lblFechaInicio = new Label();
            this.lblPrecioLabel = new Label();
            this.lblPrecioActual = new Label();
            this.lblGanadorLabel = new Label();
            this.lblGanadorActual = new Label();
            this.btnCerrar = new Button();
            this.splitDer = new SplitContainer();
            this.lblSuscTitulo = new Label();
            this.dgvSuscriptores = new DataGridView();
            this.lblPostorSusc = new Label();
            this.cmbPostorSuscribir = new ComboBox();
            this.btnSuscribir = new Button();
            this.btnDesuscribir = new Button();
            this.lblPujaTitulo = new Label();
            this.lblPostorPuja = new Label();
            this.cmbPostorPuja = new ComboBox();
            this.lblMonto = new Label();
            this.txtMontoPuja = new TextBox();
            this.btnOferta = new Button();
            this.pnlFiltroLog = new Panel();
            this.cmbFiltroSubasta = new ComboBox();
            this.lblFiltroSubasta = new Label();
            this.cmbFiltroPostor = new ComboBox();
            this.lblFiltroPostor = new Label();
            this.lblLogTitulo = new Label();
            this.rtbLog = new RichTextBox();
            this.btnLimpiarLog = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitV)).BeginInit();
            this.splitV.Panel1.SuspendLayout();
            this.splitV.Panel2.SuspendLayout();
            this.splitV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDer)).BeginInit();
            this.splitDer.Panel1.SuspendLayout();
            this.splitDer.Panel2.SuspendLayout();
            this.splitDer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuscriptores)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlCrear.SuspendLayout();
            this.pnlFiltroLog.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(30, 20, 10);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1150, 50);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(192, 148, 48);
            this.lblTitulo.Location = new Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new Padding(12, 0, 0, 0);
            this.lblTitulo.Size = new Size(1150, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Motor de Subastas  (Observer)";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pnlCrear.BackColor = Color.FromArgb(250, 245, 235);
            this.pnlCrear.Controls.Add(this.rbSoloLotes);
            this.pnlCrear.Controls.Add(this.rbSoloArticulos);
            this.pnlCrear.Controls.Add(this.rbTodos);
            this.pnlCrear.Controls.Add(this.btnCrearSubasta);
            this.pnlCrear.Controls.Add(this.cmbItem);
            this.pnlCrear.Controls.Add(this.lblSelItem);
            this.pnlCrear.Controls.Add(this.lblCrearTitulo);
            this.pnlCrear.Dock = DockStyle.Top;
            this.pnlCrear.Location = new Point(0, 50);
            this.pnlCrear.Name = "pnlCrear";
            this.pnlCrear.Size = new Size(1150, 52);
            this.pnlCrear.TabIndex = 1;

            this.lblCrearTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCrearTitulo.Location = new Point(10, 16);
            this.lblCrearTitulo.Name = "lblCrearTitulo";
            this.lblCrearTitulo.Size = new Size(105, 20);
            this.lblCrearTitulo.TabIndex = 0;
            this.lblCrearTitulo.Text = "Nueva subasta:";

            this.lblSelItem.Font = new Font("Segoe UI", 9F);
            this.lblSelItem.Location = new Point(120, 16);
            this.lblSelItem.Name = "lblSelItem";
            this.lblSelItem.Size = new Size(35, 20);
            this.lblSelItem.TabIndex = 1;
            this.lblSelItem.Text = "Ítem:";

            this.cmbItem.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbItem.Font = new Font("Segoe UI", 9F);
            this.cmbItem.Location = new Point(158, 13);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new Size(250, 25);
            this.cmbItem.TabIndex = 2;

            this.rbTodos.Text = "Todos";
            this.rbTodos.Location = new Point(415, 14);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new Size(70, 20);
            this.rbTodos.Checked = true;
            this.rbTodos.Font = new Font("Segoe UI", 9F);
            this.rbTodos.TabIndex = 3;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);

            this.rbSoloArticulos.Text = "Artículos";
            this.rbSoloArticulos.Location = new Point(490, 14);
            this.rbSoloArticulos.Name = "rbSoloArticulos";
            this.rbSoloArticulos.Size = new Size(80, 20);
            this.rbSoloArticulos.Font = new Font("Segoe UI", 9F);
            this.rbSoloArticulos.TabIndex = 4;
            this.rbSoloArticulos.CheckedChanged += new System.EventHandler(this.rbSoloArticulos_CheckedChanged);

            this.rbSoloLotes.Text = "Lotes";
            this.rbSoloLotes.Location = new Point(575, 14);
            this.rbSoloLotes.Name = "rbSoloLotes";
            this.rbSoloLotes.Size = new Size(65, 20);
            this.rbSoloLotes.Font = new Font("Segoe UI", 9F);
            this.rbSoloLotes.TabIndex = 5;
            this.rbSoloLotes.CheckedChanged += new System.EventHandler(this.rbSoloLotes_CheckedChanged);

            this.btnCrearSubasta.BackColor = Color.FromArgb(160, 120, 35);
            this.btnCrearSubasta.FlatStyle = FlatStyle.Flat;
            this.btnCrearSubasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCrearSubasta.ForeColor = Color.White;
            this.btnCrearSubasta.Location = new Point(648, 11);
            this.btnCrearSubasta.Name = "btnCrearSubasta";
            this.btnCrearSubasta.Size = new Size(140, 30);
            this.btnCrearSubasta.TabIndex = 6;
            this.btnCrearSubasta.Text = "Crear Subasta";
            this.btnCrearSubasta.UseVisualStyleBackColor = false;
            this.btnCrearSubasta.Click += new System.EventHandler(this.btnCrearSubasta_Click);

            this.splitV.Dock = DockStyle.Fill;
            this.splitV.Location = new Point(0, 102);
            this.splitV.Name = "splitV";
            this.splitV.Panel1MinSize = 200;
            this.splitV.Panel2MinSize = 400;
            this.splitV.Size = new Size(1150, 548);
            this.splitV.SplitterDistance = 255;
            this.splitV.TabIndex = 2;

            this.splitV.Panel1.BackColor = Color.White;
            this.splitV.Panel1.Controls.Add(this.btnCerrar);
            this.splitV.Panel1.Controls.Add(this.lblGanadorActual);
            this.splitV.Panel1.Controls.Add(this.lblGanadorLabel);
            this.splitV.Panel1.Controls.Add(this.lblPrecioActual);
            this.splitV.Panel1.Controls.Add(this.lblPrecioLabel);
            this.splitV.Panel1.Controls.Add(this.lblFechaInicio);
            this.splitV.Panel1.Controls.Add(this.lblItemSubasta);
            this.splitV.Panel1.Controls.Add(this.lstSubastas);
            this.splitV.Panel1.Controls.Add(this.lblListaSub);
            this.splitV.Panel1.Padding = new Padding(10);

            this.lblListaSub.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblListaSub.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblListaSub.Location = new Point(10, 10);
            this.lblListaSub.Name = "lblListaSub";
            this.lblListaSub.Size = new Size(225, 20);
            this.lblListaSub.TabIndex = 0;
            this.lblListaSub.Text = "Subastas activas:";

            this.lstSubastas.Font = new Font("Segoe UI", 10F);
            this.lstSubastas.Location = new Point(10, 32);
            this.lstSubastas.Name = "lstSubastas";
            this.lstSubastas.Size = new Size(225, 180);
            this.lstSubastas.TabIndex = 1;
            this.lstSubastas.SelectedIndexChanged += new System.EventHandler(this.lstSubastas_SelectedIndexChanged);

            this.lblItemSubasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblItemSubasta.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblItemSubasta.Location = new Point(10, 222);
            this.lblItemSubasta.Name = "lblItemSubasta";
            this.lblItemSubasta.Size = new Size(225, 20);
            this.lblItemSubasta.TabIndex = 2;
            this.lblItemSubasta.Text = "Ítem: —";

            this.lblFechaInicio.Font = new Font("Segoe UI", 8F);
            this.lblFechaInicio.ForeColor = Color.Gray;
            this.lblFechaInicio.Location = new Point(10, 244);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new Size(225, 18);
            this.lblFechaInicio.TabIndex = 3;

            this.lblPrecioLabel.Font = new Font("Segoe UI", 9F);
            this.lblPrecioLabel.Location = new Point(10, 268);
            this.lblPrecioLabel.Name = "lblPrecioLabel";
            this.lblPrecioLabel.Size = new Size(100, 18);
            this.lblPrecioLabel.TabIndex = 4;
            this.lblPrecioLabel.Text = "Precio actual:";

            this.lblPrecioActual.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblPrecioActual.ForeColor = Color.FromArgb(192, 148, 48);
            this.lblPrecioActual.Location = new Point(10, 284);
            this.lblPrecioActual.Name = "lblPrecioActual";
            this.lblPrecioActual.Size = new Size(225, 32);
            this.lblPrecioActual.TabIndex = 5;
            this.lblPrecioActual.Text = "—";

            this.lblGanadorLabel.Font = new Font("Segoe UI", 9F);
            this.lblGanadorLabel.Location = new Point(10, 322);
            this.lblGanadorLabel.Name = "lblGanadorLabel";
            this.lblGanadorLabel.Size = new Size(225, 18);
            this.lblGanadorLabel.TabIndex = 6;
            this.lblGanadorLabel.Text = "Ganador actual:";

            this.lblGanadorActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblGanadorActual.ForeColor = Color.FromArgb(38, 100, 55);
            this.lblGanadorActual.Location = new Point(10, 342);
            this.lblGanadorActual.Name = "lblGanadorActual";
            this.lblGanadorActual.Size = new Size(225, 20);
            this.lblGanadorActual.TabIndex = 7;
            this.lblGanadorActual.Text = "—";

            this.btnCerrar.BackColor = Color.FromArgb(158, 38, 38);
            this.btnCerrar.Enabled = false;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Location = new Point(10, 375);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(225, 30);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar Subasta";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.splitV.Panel2.Controls.Add(this.splitDer);

            this.splitDer.Dock = DockStyle.Fill;
            this.splitDer.Location = new Point(0, 0);
            this.splitDer.Name = "splitDer";
            this.splitDer.Panel1MinSize = 260;
            this.splitDer.Panel2MinSize = 260;
            this.splitDer.Size = new Size(891, 548);
            this.splitDer.SplitterDistance = 390;
            this.splitDer.TabIndex = 0;

            this.splitDer.Panel1.BackColor = Color.White;
            this.splitDer.Panel1.Controls.Add(this.dgvSuscriptores);
            this.splitDer.Panel1.Controls.Add(this.btnDesuscribir);
            this.splitDer.Panel1.Controls.Add(this.btnSuscribir);
            this.splitDer.Panel1.Controls.Add(this.cmbPostorSuscribir);
            this.splitDer.Panel1.Controls.Add(this.lblPostorSusc);
            this.splitDer.Panel1.Controls.Add(this.lblSuscTitulo);
            this.splitDer.Panel1.Padding = new Padding(10);

            this.lblSuscTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSuscTitulo.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblSuscTitulo.Location = new Point(10, 10);
            this.lblSuscTitulo.Name = "lblSuscTitulo";
            this.lblSuscTitulo.Size = new Size(360, 20);
            this.lblSuscTitulo.TabIndex = 0;
            this.lblSuscTitulo.Text = "Suscriptores (Observadores):";

            this.dgvSuscriptores.AllowUserToAddRows = false;
            this.dgvSuscriptores.AllowUserToDeleteRows = false;
            this.dgvSuscriptores.BackgroundColor = Color.White;
            this.dgvSuscriptores.BorderStyle = BorderStyle.None;
            this.dgvSuscriptores.ColumnHeadersHeight = 28;
            this.dgvSuscriptores.Location = new Point(10, 32);
            this.dgvSuscriptores.MultiSelect = false;
            this.dgvSuscriptores.Name = "dgvSuscriptores";
            this.dgvSuscriptores.ReadOnly = true;
            this.dgvSuscriptores.RowHeadersVisible = false;
            this.dgvSuscriptores.RowTemplate.Height = 26;
            this.dgvSuscriptores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuscriptores.Size = new Size(360, 360);
            this.dgvSuscriptores.TabIndex = 1;

            this.lblPostorSusc.Font = new Font("Segoe UI", 9F);
            this.lblPostorSusc.Location = new Point(10, 400);
            this.lblPostorSusc.Name = "lblPostorSusc";
            this.lblPostorSusc.Size = new Size(50, 20);
            this.lblPostorSusc.TabIndex = 2;
            this.lblPostorSusc.Text = "Postor:";

            this.cmbPostorSuscribir.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbPostorSuscribir.Font = new Font("Segoe UI", 9F);
            this.cmbPostorSuscribir.Location = new Point(65, 397);
            this.cmbPostorSuscribir.Name = "cmbPostorSuscribir";
            this.cmbPostorSuscribir.Size = new Size(305, 25);
            this.cmbPostorSuscribir.TabIndex = 3;

            this.btnSuscribir.BackColor = Color.FromArgb(30, 20, 10);
            this.btnSuscribir.Enabled = false;
            this.btnSuscribir.FlatStyle = FlatStyle.Flat;
            this.btnSuscribir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSuscribir.ForeColor = Color.FromArgb(192, 148, 48);
            this.btnSuscribir.Location = new Point(10, 430);
            this.btnSuscribir.Name = "btnSuscribir";
            this.btnSuscribir.Size = new Size(165, 32);
            this.btnSuscribir.TabIndex = 4;
            this.btnSuscribir.Text = "Suscribir";
            this.btnSuscribir.UseVisualStyleBackColor = false;
            this.btnSuscribir.Click += new System.EventHandler(this.btnSuscribir_Click);

            this.btnDesuscribir.BackColor = Color.FromArgb(175, 98, 28);
            this.btnDesuscribir.Enabled = false;
            this.btnDesuscribir.FlatStyle = FlatStyle.Flat;
            this.btnDesuscribir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnDesuscribir.ForeColor = Color.White;
            this.btnDesuscribir.Location = new Point(185, 430);
            this.btnDesuscribir.Name = "btnDesuscribir";
            this.btnDesuscribir.Size = new Size(185, 32);
            this.btnDesuscribir.TabIndex = 5;
            this.btnDesuscribir.Text = "Desuscribir";
            this.btnDesuscribir.UseVisualStyleBackColor = false;
            this.btnDesuscribir.Click += new System.EventHandler(this.btnDesuscribir_Click);

            this.splitDer.Panel2.BackColor = Color.FromArgb(250, 245, 235);
            this.splitDer.Panel2.Controls.Add(this.rtbLog);
            this.splitDer.Panel2.Controls.Add(this.btnLimpiarLog);
            this.splitDer.Panel2.Controls.Add(this.pnlFiltroLog);
            this.splitDer.Panel2.Controls.Add(this.btnOferta);
            this.splitDer.Panel2.Controls.Add(this.txtMontoPuja);
            this.splitDer.Panel2.Controls.Add(this.lblMonto);
            this.splitDer.Panel2.Controls.Add(this.cmbPostorPuja);
            this.splitDer.Panel2.Controls.Add(this.lblPostorPuja);
            this.splitDer.Panel2.Controls.Add(this.lblLogTitulo);
            this.splitDer.Panel2.Controls.Add(this.lblPujaTitulo);
            this.splitDer.Panel2.Padding = new Padding(10);

            this.lblPujaTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPujaTitulo.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblPujaTitulo.Location = new Point(10, 10);
            this.lblPujaTitulo.Name = "lblPujaTitulo";
            this.lblPujaTitulo.Size = new Size(460, 20);
            this.lblPujaTitulo.TabIndex = 0;
            this.lblPujaTitulo.Text = "Realizar Oferta:";

            this.lblPostorPuja.Font = new Font("Segoe UI", 9F);
            this.lblPostorPuja.Location = new Point(10, 36);
            this.lblPostorPuja.Name = "lblPostorPuja";
            this.lblPostorPuja.Size = new Size(55, 20);
            this.lblPostorPuja.TabIndex = 1;
            this.lblPostorPuja.Text = "Postor:";

            this.cmbPostorPuja.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbPostorPuja.Font = new Font("Segoe UI", 9F);
            this.cmbPostorPuja.Location = new Point(70, 33);
            this.cmbPostorPuja.Name = "cmbPostorPuja";
            this.cmbPostorPuja.Size = new Size(400, 25);
            this.cmbPostorPuja.TabIndex = 2;

            this.lblMonto.Font = new Font("Segoe UI", 9F);
            this.lblMonto.Location = new Point(10, 68);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new Size(70, 20);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto ($):";

            this.txtMontoPuja.Font = new Font("Segoe UI", 11F);
            this.txtMontoPuja.Location = new Point(85, 65);
            this.txtMontoPuja.Name = "txtMontoPuja";
            this.txtMontoPuja.Size = new Size(200, 25);
            this.txtMontoPuja.TabIndex = 4;

            this.btnOferta.BackColor = Color.FromArgb(160, 120, 35);
            this.btnOferta.Enabled = false;
            this.btnOferta.FlatStyle = FlatStyle.Flat;
            this.btnOferta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnOferta.ForeColor = Color.White;
            this.btnOferta.Location = new Point(295, 61);
            this.btnOferta.Name = "btnOferta";
            this.btnOferta.Size = new Size(175, 32);
            this.btnOferta.TabIndex = 5;
            this.btnOferta.Text = "Pujar";
            this.btnOferta.UseVisualStyleBackColor = false;
            this.btnOferta.Click += new System.EventHandler(this.btnOferta_Click);

            this.lblLogTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblLogTitulo.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblLogTitulo.Location = new Point(10, 102);
            this.lblLogTitulo.Name = "lblLogTitulo";
            this.lblLogTitulo.Size = new Size(460, 20);
            this.lblLogTitulo.TabIndex = 6;
            this.lblLogTitulo.Text = "Notificaciones en tiempo real (Observer):";

            this.pnlFiltroLog.BackColor = Color.FromArgb(250, 245, 235);
            this.pnlFiltroLog.Controls.Add(this.cmbFiltroSubasta);
            this.pnlFiltroLog.Controls.Add(this.lblFiltroSubasta);
            this.pnlFiltroLog.Controls.Add(this.cmbFiltroPostor);
            this.pnlFiltroLog.Controls.Add(this.lblFiltroPostor);
            this.pnlFiltroLog.Location = new Point(10, 124);
            this.pnlFiltroLog.Name = "pnlFiltroLog";
            this.pnlFiltroLog.Size = new Size(460, 30);
            this.pnlFiltroLog.TabIndex = 7;

            this.lblFiltroPostor.Font = new Font("Segoe UI", 8F);
            this.lblFiltroPostor.Location = new Point(0, 7);
            this.lblFiltroPostor.Name = "lblFiltroPostor";
            this.lblFiltroPostor.Size = new Size(45, 16);
            this.lblFiltroPostor.TabIndex = 0;
            this.lblFiltroPostor.Text = "Postor:";

            this.cmbFiltroPostor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFiltroPostor.Font = new Font("Segoe UI", 8F);
            this.cmbFiltroPostor.Location = new Point(48, 4);
            this.cmbFiltroPostor.Name = "cmbFiltroPostor";
            this.cmbFiltroPostor.Size = new Size(190, 22);
            this.cmbFiltroPostor.TabIndex = 1;
            this.cmbFiltroPostor.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroPostor_SelectedIndexChanged);

            this.lblFiltroSubasta.Font = new Font("Segoe UI", 8F);
            this.lblFiltroSubasta.Location = new Point(244, 7);
            this.lblFiltroSubasta.Name = "lblFiltroSubasta";
            this.lblFiltroSubasta.Size = new Size(52, 16);
            this.lblFiltroSubasta.TabIndex = 2;
            this.lblFiltroSubasta.Text = "Subasta:";

            this.cmbFiltroSubasta.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFiltroSubasta.Font = new Font("Segoe UI", 8F);
            this.cmbFiltroSubasta.Location = new Point(300, 4);
            this.cmbFiltroSubasta.Name = "cmbFiltroSubasta";
            this.cmbFiltroSubasta.Size = new Size(160, 22);
            this.cmbFiltroSubasta.TabIndex = 3;
            this.cmbFiltroSubasta.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroSubasta_SelectedIndexChanged);

            this.rtbLog.BackColor = Color.FromArgb(28, 22, 12);
            this.rtbLog.BorderStyle = BorderStyle.None;
            this.rtbLog.Font = new Font("Consolas", 9F);
            this.rtbLog.ForeColor = Color.FromArgb(192, 148, 48);
            this.rtbLog.Location = new Point(10, 158);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new Size(460, 355);
            this.rtbLog.TabIndex = 8;

            this.btnLimpiarLog.BackColor = Color.FromArgb(50, 40, 25);
            this.btnLimpiarLog.FlatStyle = FlatStyle.Flat;
            this.btnLimpiarLog.Font = new Font("Segoe UI", 8F);
            this.btnLimpiarLog.ForeColor = Color.FromArgb(192, 148, 48);
            this.btnLimpiarLog.Location = new Point(10, 518);
            this.btnLimpiarLog.Name = "btnLimpiarLog";
            this.btnLimpiarLog.Size = new Size(460, 24);
            this.btnLimpiarLog.TabIndex = 9;
            this.btnLimpiarLog.Text = "Limpiar log";
            this.btnLimpiarLog.UseVisualStyleBackColor = false;
            this.btnLimpiarLog.Click += new System.EventHandler(this.btnLimpiarLog_Click);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(250, 245, 235);
            this.ClientSize = new Size(1150, 650);
            this.Controls.Add(this.splitV);
            this.Controls.Add(this.pnlCrear);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(950, 580);
            this.Name = "FormSubasta";
            this.Text = "Gestión de Subastas";
            this.splitV.Panel1.ResumeLayout(false);
            this.splitV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitV)).EndInit();
            this.splitV.ResumeLayout(false);
            this.splitDer.Panel1.ResumeLayout(false);
            this.splitDer.Panel2.ResumeLayout(false);
            this.splitDer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDer)).EndInit();
            this.splitDer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuscriptores)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlCrear.ResumeLayout(false);
            this.pnlFiltroLog.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlCrear;
        private RadioButton rbSoloLotes;
        private RadioButton rbSoloArticulos;
        private RadioButton rbTodos;
        private Button btnCrearSubasta;
        private ComboBox cmbItem;
        private Label lblSelItem;
        private Label lblCrearTitulo;
        private SplitContainer splitV;
        private ListBox lstSubastas;
        private Label lblListaSub;
        private Label lblItemSubasta;
        private Label lblFechaInicio;
        private Label lblPrecioLabel;
        private Label lblPrecioActual;
        private Label lblGanadorLabel;
        private Label lblGanadorActual;
        private Button btnCerrar;
        private SplitContainer splitDer;
        private Label lblSuscTitulo;
        private DataGridView dgvSuscriptores;
        private Label lblPostorSusc;
        private ComboBox cmbPostorSuscribir;
        private Button btnSuscribir;
        private Button btnDesuscribir;
        private Label lblPujaTitulo;
        private Label lblPostorPuja;
        private ComboBox cmbPostorPuja;
        private Label lblMonto;
        private TextBox txtMontoPuja;
        private Button btnOferta;
        private Panel pnlFiltroLog;
        private ComboBox cmbFiltroSubasta;
        private Label lblFiltroSubasta;
        private ComboBox cmbFiltroPostor;
        private Label lblFiltroPostor;
        private Label lblLogTitulo;
        private RichTextBox rtbLog;
        private Button btnLimpiarLog;
    }
}
