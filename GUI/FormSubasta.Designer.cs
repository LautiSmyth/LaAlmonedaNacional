using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FormSubasta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.pnlCrear = new Panel();
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
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(26, 58, 92);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1100, 50);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new Padding(10, 0, 0, 0);
            this.lblTitulo.Size = new Size(1100, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Motor de Subastas  (Observer)";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pnlCrear.BackColor = Color.FromArgb(240, 244, 248);
            this.pnlCrear.Controls.Add(this.btnCrearSubasta);
            this.pnlCrear.Controls.Add(this.cmbItem);
            this.pnlCrear.Controls.Add(this.lblSelItem);
            this.pnlCrear.Controls.Add(this.lblCrearTitulo);
            this.pnlCrear.Dock = DockStyle.Top;
            this.pnlCrear.Location = new Point(0, 50);
            this.pnlCrear.Name = "pnlCrear";
            this.pnlCrear.Size = new Size(1100, 48);
            this.pnlCrear.TabIndex = 1;

            this.lblCrearTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCrearTitulo.Location = new Point(10, 14);
            this.lblCrearTitulo.Name = "lblCrearTitulo";
            this.lblCrearTitulo.Size = new Size(110, 20);
            this.lblCrearTitulo.TabIndex = 0;
            this.lblCrearTitulo.Text = "Nueva subasta:";

            this.lblSelItem.Font = new Font("Segoe UI", 9F);
            this.lblSelItem.Location = new Point(125, 14);
            this.lblSelItem.Name = "lblSelItem";
            this.lblSelItem.Size = new Size(35, 20);
            this.lblSelItem.TabIndex = 1;
            this.lblSelItem.Text = "Ítem:";

            this.cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbItem.Font = new Font("Segoe UI", 9F);
            this.cmbItem.Location = new Point(165, 10);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new Size(270, 25);
            this.cmbItem.TabIndex = 2;

            this.btnCrearSubasta.BackColor = Color.FromArgb(212, 175, 55);
            this.btnCrearSubasta.FlatStyle = FlatStyle.Flat;
            this.btnCrearSubasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCrearSubasta.ForeColor = Color.White;
            this.btnCrearSubasta.Location = new Point(445, 8);
            this.btnCrearSubasta.Name = "btnCrearSubasta";
            this.btnCrearSubasta.Size = new Size(140, 32);
            this.btnCrearSubasta.TabIndex = 3;
            this.btnCrearSubasta.Text = "Crear Subasta";
            this.btnCrearSubasta.UseVisualStyleBackColor = false;
            this.btnCrearSubasta.Click += new System.EventHandler(this.btnCrearSubasta_Click);

            this.splitV.Dock = DockStyle.Fill;
            this.splitV.Location = new Point(0, 98);
            this.splitV.Name = "splitV";
            this.splitV.Panel1MinSize = 200;
            this.splitV.Panel2MinSize = 400;
            this.splitV.Size = new Size(1100, 522);
            this.splitV.SplitterDistance = 250;
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
            this.lblListaSub.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblListaSub.Location = new Point(10, 10);
            this.lblListaSub.Name = "lblListaSub";
            this.lblListaSub.Size = new Size(220, 20);
            this.lblListaSub.TabIndex = 0;
            this.lblListaSub.Text = "Subastas activas:";

            this.lstSubastas.Font = new Font("Segoe UI", 10F);
            this.lstSubastas.Location = new Point(10, 32);
            this.lstSubastas.Name = "lstSubastas";
            this.lstSubastas.Size = new Size(220, 175);
            this.lstSubastas.TabIndex = 1;
            this.lstSubastas.SelectedIndexChanged += new System.EventHandler(this.lstSubastas_SelectedIndexChanged);

            this.lblItemSubasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblItemSubasta.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblItemSubasta.Location = new Point(10, 218);
            this.lblItemSubasta.Name = "lblItemSubasta";
            this.lblItemSubasta.Size = new Size(220, 20);
            this.lblItemSubasta.TabIndex = 2;
            this.lblItemSubasta.Text = "Ítem: —";

            this.lblFechaInicio.Font = new Font("Segoe UI", 8F);
            this.lblFechaInicio.ForeColor = Color.Gray;
            this.lblFechaInicio.Location = new Point(10, 240);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new Size(220, 18);
            this.lblFechaInicio.TabIndex = 3;

            this.lblPrecioLabel.Font = new Font("Segoe UI", 9F);
            this.lblPrecioLabel.Location = new Point(10, 265);
            this.lblPrecioLabel.Name = "lblPrecioLabel";
            this.lblPrecioLabel.Size = new Size(100, 18);
            this.lblPrecioLabel.TabIndex = 4;
            this.lblPrecioLabel.Text = "Precio actual:";

            this.lblPrecioActual.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblPrecioActual.ForeColor = Color.FromArgb(212, 175, 55);
            this.lblPrecioActual.Location = new Point(10, 280);
            this.lblPrecioActual.Name = "lblPrecioActual";
            this.lblPrecioActual.Size = new Size(220, 32);
            this.lblPrecioActual.TabIndex = 5;
            this.lblPrecioActual.Text = "—";

            this.lblGanadorLabel.Font = new Font("Segoe UI", 9F);
            this.lblGanadorLabel.Location = new Point(10, 318);
            this.lblGanadorLabel.Name = "lblGanadorLabel";
            this.lblGanadorLabel.Size = new Size(220, 18);
            this.lblGanadorLabel.TabIndex = 6;
            this.lblGanadorLabel.Text = "Ganador actual:";

            this.lblGanadorActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblGanadorActual.ForeColor = Color.DarkGreen;
            this.lblGanadorActual.Location = new Point(10, 338);
            this.lblGanadorActual.Name = "lblGanadorActual";
            this.lblGanadorActual.Size = new Size(220, 20);
            this.lblGanadorActual.TabIndex = 7;
            this.lblGanadorActual.Text = "—";

            this.btnCerrar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCerrar.Enabled = false;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Location = new Point(10, 370);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(220, 30);
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
            this.splitDer.Size = new Size(846, 522);
            this.splitDer.SplitterDistance = 380;
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
            this.lblSuscTitulo.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblSuscTitulo.Location = new Point(10, 10);
            this.lblSuscTitulo.Name = "lblSuscTitulo";
            this.lblSuscTitulo.Size = new Size(350, 20);
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
            this.dgvSuscriptores.Size = new Size(350, 360);
            this.dgvSuscriptores.TabIndex = 1;

            this.lblPostorSusc.Font = new Font("Segoe UI", 9F);
            this.lblPostorSusc.Location = new Point(10, 400);
            this.lblPostorSusc.Name = "lblPostorSusc";
            this.lblPostorSusc.Size = new Size(50, 20);
            this.lblPostorSusc.TabIndex = 2;
            this.lblPostorSusc.Text = "Postor:";

            this.cmbPostorSuscribir.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPostorSuscribir.Font = new Font("Segoe UI", 9F);
            this.cmbPostorSuscribir.Location = new Point(65, 397);
            this.cmbPostorSuscribir.Name = "cmbPostorSuscribir";
            this.cmbPostorSuscribir.Size = new Size(295, 25);
            this.cmbPostorSuscribir.TabIndex = 3;

            this.btnSuscribir.BackColor = Color.FromArgb(26, 58, 92);
            this.btnSuscribir.Enabled = false;
            this.btnSuscribir.FlatStyle = FlatStyle.Flat;
            this.btnSuscribir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSuscribir.ForeColor = Color.White;
            this.btnSuscribir.Location = new Point(10, 430);
            this.btnSuscribir.Name = "btnSuscribir";
            this.btnSuscribir.Size = new Size(165, 32);
            this.btnSuscribir.TabIndex = 4;
            this.btnSuscribir.Text = "Suscribir";
            this.btnSuscribir.UseVisualStyleBackColor = false;
            this.btnSuscribir.Click += new System.EventHandler(this.btnSuscribir_Click);

            this.btnDesuscribir.BackColor = Color.FromArgb(255, 133, 27);
            this.btnDesuscribir.Enabled = false;
            this.btnDesuscribir.FlatStyle = FlatStyle.Flat;
            this.btnDesuscribir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnDesuscribir.ForeColor = Color.White;
            this.btnDesuscribir.Location = new Point(185, 430);
            this.btnDesuscribir.Name = "btnDesuscribir";
            this.btnDesuscribir.Size = new Size(175, 32);
            this.btnDesuscribir.TabIndex = 5;
            this.btnDesuscribir.Text = "Desuscribir";
            this.btnDesuscribir.UseVisualStyleBackColor = false;
            this.btnDesuscribir.Click += new System.EventHandler(this.btnDesuscribir_Click);

            this.splitDer.Panel2.BackColor = Color.FromArgb(248, 250, 252);
            this.splitDer.Panel2.Controls.Add(this.rtbLog);
            this.splitDer.Panel2.Controls.Add(this.btnLimpiarLog);
            this.splitDer.Panel2.Controls.Add(this.btnOferta);
            this.splitDer.Panel2.Controls.Add(this.txtMontoPuja);
            this.splitDer.Panel2.Controls.Add(this.lblMonto);
            this.splitDer.Panel2.Controls.Add(this.cmbPostorPuja);
            this.splitDer.Panel2.Controls.Add(this.lblPostorPuja);
            this.splitDer.Panel2.Controls.Add(this.lblLogTitulo);
            this.splitDer.Panel2.Controls.Add(this.lblPujaTitulo);
            this.splitDer.Panel2.Padding = new Padding(10);

            this.lblPujaTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPujaTitulo.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblPujaTitulo.Location = new Point(10, 10);
            this.lblPujaTitulo.Name = "lblPujaTitulo";
            this.lblPujaTitulo.Size = new Size(440, 20);
            this.lblPujaTitulo.TabIndex = 0;
            this.lblPujaTitulo.Text = "Realizar Oferta:";

            this.lblPostorPuja.Font = new Font("Segoe UI", 9F);
            this.lblPostorPuja.Location = new Point(10, 38);
            this.lblPostorPuja.Name = "lblPostorPuja";
            this.lblPostorPuja.Size = new Size(55, 20);
            this.lblPostorPuja.TabIndex = 1;
            this.lblPostorPuja.Text = "Postor:";

            this.cmbPostorPuja.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPostorPuja.Font = new Font("Segoe UI", 9F);
            this.cmbPostorPuja.Location = new Point(70, 35);
            this.cmbPostorPuja.Name = "cmbPostorPuja";
            this.cmbPostorPuja.Size = new Size(380, 25);
            this.cmbPostorPuja.TabIndex = 2;

            this.lblMonto.Font = new Font("Segoe UI", 9F);
            this.lblMonto.Location = new Point(10, 72);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new Size(70, 20);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto ($):";

            this.txtMontoPuja.Font = new Font("Segoe UI", 11F);
            this.txtMontoPuja.Location = new Point(85, 69);
            this.txtMontoPuja.Name = "txtMontoPuja";
            this.txtMontoPuja.Size = new Size(200, 25);
            this.txtMontoPuja.TabIndex = 4;

            this.btnOferta.BackColor = Color.FromArgb(212, 175, 55);
            this.btnOferta.Enabled = false;
            this.btnOferta.FlatStyle = FlatStyle.Flat;
            this.btnOferta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnOferta.ForeColor = Color.White;
            this.btnOferta.Location = new Point(295, 65);
            this.btnOferta.Name = "btnOferta";
            this.btnOferta.Size = new Size(155, 32);
            this.btnOferta.TabIndex = 5;
            this.btnOferta.Text = "Pujar";
            this.btnOferta.UseVisualStyleBackColor = false;
            this.btnOferta.Click += new System.EventHandler(this.btnOferta_Click);

            this.lblLogTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblLogTitulo.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblLogTitulo.Location = new Point(10, 108);
            this.lblLogTitulo.Name = "lblLogTitulo";
            this.lblLogTitulo.Size = new Size(440, 20);
            this.lblLogTitulo.TabIndex = 6;
            this.lblLogTitulo.Text = "Notificaciones en tiempo real (Observer):";

            this.rtbLog.BackColor = Color.FromArgb(30, 30, 30);
            this.rtbLog.BorderStyle = BorderStyle.None;
            this.rtbLog.Font = new Font("Consolas", 9F);
            this.rtbLog.ForeColor = Color.LimeGreen;
            this.rtbLog.Location = new Point(10, 130);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new Size(440, 350);
            this.rtbLog.TabIndex = 7;

            this.btnLimpiarLog.BackColor = Color.FromArgb(60, 60, 60);
            this.btnLimpiarLog.FlatStyle = FlatStyle.Flat;
            this.btnLimpiarLog.Font = new Font("Segoe UI", 8F);
            this.btnLimpiarLog.ForeColor = Color.White;
            this.btnLimpiarLog.Location = new Point(10, 485);
            this.btnLimpiarLog.Name = "btnLimpiarLog";
            this.btnLimpiarLog.Size = new Size(440, 28);
            this.btnLimpiarLog.TabIndex = 8;
            this.btnLimpiarLog.Text = "Limpiar log";
            this.btnLimpiarLog.UseVisualStyleBackColor = false;
            this.btnLimpiarLog.Click += new System.EventHandler(this.btnLimpiarLog_Click);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1100, 620);
            this.Controls.Add(this.splitV);
            this.Controls.Add(this.pnlCrear);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(900, 550);
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
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlCrear;
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
        private Label lblLogTitulo;
        private RichTextBox rtbLog;
        private Button btnLimpiarLog;
    }
}
