using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FormReporte
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
            this.pnlBotones = new Panel();
            this.btnExportar = new Button();
            this.btnActualizar = new Button();
            this.lblTotalJornada = new Label();
            this.splitMain = new SplitContainer();
            this.lblCatalogo = new Label();
            this.trvCatalogo = new TreeView();
            this.lblHistorial = new Label();
            this.dgvHistorial = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(30, 20, 10);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1000, 50);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(192, 148, 48);
            this.lblTitulo.Location = new Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new Padding(12, 0, 0, 0);
            this.lblTitulo.Size = new Size(1000, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reporte de Jornada";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pnlBotones.BackColor = Color.FromArgb(250, 245, 235);
            this.pnlBotones.Controls.Add(this.btnExportar);
            this.pnlBotones.Controls.Add(this.btnActualizar);
            this.pnlBotones.Controls.Add(this.lblTotalJornada);
            this.pnlBotones.Dock = DockStyle.Bottom;
            this.pnlBotones.Location = new Point(0, 530);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new Padding(10);
            this.pnlBotones.Size = new Size(1000, 55);
            this.pnlBotones.TabIndex = 1;

            this.lblTotalJornada.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotalJornada.ForeColor = Color.FromArgb(192, 148, 48);
            this.lblTotalJornada.Location = new Point(10, 15);
            this.lblTotalJornada.Name = "lblTotalJornada";
            this.lblTotalJornada.Size = new Size(380, 26);
            this.lblTotalJornada.TabIndex = 0;
            this.lblTotalJornada.Text = "Total recaudado: —";

            this.btnActualizar.BackColor = Color.FromArgb(30, 20, 10);
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnActualizar.ForeColor = Color.FromArgb(192, 148, 48);
            this.btnActualizar.Location = new Point(400, 10);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(130, 35);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.btnExportar.BackColor = Color.FromArgb(38, 100, 55);
            this.btnExportar.FlatStyle = FlatStyle.Flat;
            this.btnExportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExportar.ForeColor = Color.White;
            this.btnExportar.Location = new Point(540, 10);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new Size(140, 35);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar TXT";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);

            this.splitMain.Dock = DockStyle.Fill;
            this.splitMain.Location = new Point(0, 50);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1MinSize = 260;
            this.splitMain.Panel2MinSize = 300;
            this.splitMain.Size = new Size(1000, 480);
            this.splitMain.SplitterDistance = 340;
            this.splitMain.TabIndex = 2;

            this.splitMain.Panel1.BackColor = Color.White;
            this.splitMain.Panel1.Controls.Add(this.trvCatalogo);
            this.splitMain.Panel1.Controls.Add(this.lblCatalogo);
            this.splitMain.Panel1.Padding = new Padding(8);

            this.lblCatalogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCatalogo.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblCatalogo.Location = new Point(8, 8);
            this.lblCatalogo.Name = "lblCatalogo";
            this.lblCatalogo.Size = new Size(316, 20);
            this.lblCatalogo.TabIndex = 0;
            this.lblCatalogo.Text = "Catálogo completo (Composite):";

            this.trvCatalogo.BackColor = Color.White;
            this.trvCatalogo.BorderStyle = BorderStyle.None;
            this.trvCatalogo.Font = new Font("Segoe UI", 9F);
            this.trvCatalogo.Location = new Point(8, 30);
            this.trvCatalogo.Name = "trvCatalogo";
            this.trvCatalogo.Size = new Size(316, 435);
            this.trvCatalogo.TabIndex = 1;

            this.splitMain.Panel2.BackColor = Color.FromArgb(250, 245, 235);
            this.splitMain.Panel2.Controls.Add(this.dgvHistorial);
            this.splitMain.Panel2.Controls.Add(this.lblHistorial);
            this.splitMain.Panel2.Padding = new Padding(8);

            this.lblHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblHistorial.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblHistorial.Location = new Point(8, 8);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new Size(640, 20);
            this.lblHistorial.TabIndex = 0;
            this.lblHistorial.Text = "Historial de subastas cerradas:";

            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.BackgroundColor = Color.White;
            this.dgvHistorial.BorderStyle = BorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeight = 32;
            this.dgvHistorial.Location = new Point(8, 30);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowTemplate.Height = 28;
            this.dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new Size(640, 435);
            this.dgvHistorial.TabIndex = 1;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(250, 245, 235);
            this.ClientSize = new Size(1000, 585);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "FormReporte";
            this.Text = "Reporte de Jornada";
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlBotones;
        private Button btnExportar;
        private Button btnActualizar;
        private Label lblTotalJornada;
        private SplitContainer splitMain;
        private Label lblCatalogo;
        private TreeView trvCatalogo;
        private Label lblHistorial;
        private DataGridView dgvHistorial;
    }
}
