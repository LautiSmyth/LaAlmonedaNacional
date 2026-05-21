using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FormPostor
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
            this.pnlDetalle = new Panel();
            this.txtTelefono = new TextBox();
            this.lblTelefono = new Label();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.txtNombre = new TextBox();
            this.lblNombre = new Label();
            this.lblDetalleTitulo = new Label();
            this.pnlBotones = new Panel();
            this.btnEliminar = new Button();
            this.btnGuardar = new Button();
            this.btnLimpiar = new Button();
            this.btnNuevo = new Button();
            this.dgvPostores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostores)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(30, 20, 10);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(860, 50);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(192, 148, 48);
            this.lblTitulo.Location = new Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new Padding(12, 0, 0, 0);
            this.lblTitulo.Size = new Size(860, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Postores";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pnlDetalle.BackColor = Color.White;
            this.pnlDetalle.Controls.Add(this.txtTelefono);
            this.pnlDetalle.Controls.Add(this.lblTelefono);
            this.pnlDetalle.Controls.Add(this.txtEmail);
            this.pnlDetalle.Controls.Add(this.lblEmail);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.lblNombre);
            this.pnlDetalle.Controls.Add(this.lblDetalleTitulo);
            this.pnlDetalle.Dock = DockStyle.Right;
            this.pnlDetalle.Location = new Point(560, 50);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Padding = new Padding(15);
            this.pnlDetalle.Size = new Size(300, 420);
            this.pnlDetalle.TabIndex = 1;

            this.lblDetalleTitulo.Dock = DockStyle.Top;
            this.lblDetalleTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = Color.FromArgb(30, 20, 10);
            this.lblDetalleTitulo.Location = new Point(15, 15);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new Size(270, 35);
            this.lblDetalleTitulo.TabIndex = 6;
            this.lblDetalleTitulo.Text = "Datos del postor";

            this.lblNombre.Font = new Font("Segoe UI", 9F);
            this.lblNombre.Location = new Point(15, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(260, 18);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre completo *";

            this.txtNombre.Font = new Font("Segoe UI", 10F);
            this.txtNombre.Location = new Point(15, 85);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(260, 25);
            this.txtNombre.TabIndex = 1;

            this.lblEmail.Font = new Font("Segoe UI", 9F);
            this.lblEmail.Location = new Point(15, 122);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(260, 18);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email *";

            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.Location = new Point(15, 142);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(260, 25);
            this.txtEmail.TabIndex = 3;

            this.lblTelefono.Font = new Font("Segoe UI", 9F);
            this.lblTelefono.Location = new Point(15, 180);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(260, 18);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono";

            this.txtTelefono.Font = new Font("Segoe UI", 10F);
            this.txtTelefono.Location = new Point(15, 200);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(260, 25);
            this.txtTelefono.TabIndex = 5;

            this.pnlBotones.BackColor = Color.FromArgb(250, 245, 235);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnLimpiar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Dock = DockStyle.Bottom;
            this.pnlBotones.Location = new Point(0, 470);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new Padding(10);
            this.pnlBotones.Size = new Size(860, 55);
            this.pnlBotones.TabIndex = 2;

            this.btnNuevo.BackColor = Color.FromArgb(30, 20, 10);
            this.btnNuevo.FlatStyle = FlatStyle.Flat;
            this.btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNuevo.ForeColor = Color.FromArgb(192, 148, 48);
            this.btnNuevo.Location = new Point(10, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(100, 35);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnLimpiar.BackColor = Color.FromArgb(175, 98, 28);
            this.btnLimpiar.FlatStyle = FlatStyle.Flat;
            this.btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnLimpiar.ForeColor = Color.White;
            this.btnLimpiar.Location = new Point(120, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 35);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnGuardar.BackColor = Color.FromArgb(38, 100, 55);
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(230, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(110, 35);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.BackColor = Color.FromArgb(158, 38, 38);
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = FlatStyle.Flat;
            this.btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnEliminar.ForeColor = Color.White;
            this.btnEliminar.Location = new Point(350, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(100, 35);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.dgvPostores.AllowUserToAddRows = false;
            this.dgvPostores.AllowUserToDeleteRows = false;
            this.dgvPostores.BackgroundColor = Color.White;
            this.dgvPostores.BorderStyle = BorderStyle.None;
            this.dgvPostores.ColumnHeadersHeight = 32;
            this.dgvPostores.Dock = DockStyle.Fill;
            this.dgvPostores.Location = new Point(0, 50);
            this.dgvPostores.MultiSelect = false;
            this.dgvPostores.Name = "dgvPostores";
            this.dgvPostores.ReadOnly = true;
            this.dgvPostores.RowHeadersVisible = false;
            this.dgvPostores.RowTemplate.Height = 28;
            this.dgvPostores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPostores.Size = new Size(560, 420);
            this.dgvPostores.TabIndex = 3;
            this.dgvPostores.SelectionChanged += new System.EventHandler(this.dgvPostores_SelectionChanged);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(250, 245, 235);
            this.ClientSize = new Size(860, 525);
            this.Controls.Add(this.dgvPostores);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "FormPostor";
            this.Text = "Postores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostores)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlDetalle;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblDetalleTitulo;
        private Panel pnlBotones;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnNuevo;
        private DataGridView dgvPostores;
    }
}
