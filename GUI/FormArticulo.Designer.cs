using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FormArticulo
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
            this.pnlBusqueda = new Panel();
            this.txtBuscar = new TextBox();
            this.lblBuscar = new Label();
            this.pnlDetalle = new Panel();
            this.txtPrecio = new TextBox();
            this.lblPrecio = new Label();
            this.txtDescripcion = new TextBox();
            this.lblDescripcion = new Label();
            this.txtNombre = new TextBox();
            this.lblNombre = new Label();
            this.lblDetalleTitulo = new Label();
            this.pnlBotones = new Panel();
            this.btnEliminar = new Button();
            this.btnGuardar = new Button();
            this.btnNuevo = new Button();
            this.dgvArticulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(26, 58, 92);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(880, 50);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new Padding(10, 0, 0, 0);
            this.lblTitulo.Size = new Size(880, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Artículos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pnlBusqueda.BackColor = Color.FromArgb(240, 244, 248);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Dock = DockStyle.Top;
            this.pnlBusqueda.Location = new Point(0, 50);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new Size(880, 42);
            this.pnlBusqueda.TabIndex = 1;

            this.txtBuscar.Font = new Font("Segoe UI", 10F);
            this.txtBuscar.Location = new Point(80, 9);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new Size(280, 25);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new Font("Segoe UI", 9F);
            this.lblBuscar.Location = new Point(8, 12);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";

            this.pnlDetalle.BackColor = Color.White;
            this.pnlDetalle.Controls.Add(this.txtPrecio);
            this.pnlDetalle.Controls.Add(this.lblPrecio);
            this.pnlDetalle.Controls.Add(this.txtDescripcion);
            this.pnlDetalle.Controls.Add(this.lblDescripcion);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.lblNombre);
            this.pnlDetalle.Controls.Add(this.lblDetalleTitulo);
            this.pnlDetalle.Dock = DockStyle.Right;
            this.pnlDetalle.Location = new Point(560, 92);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Padding = new Padding(15);
            this.pnlDetalle.Size = new Size(320, 413);
            this.pnlDetalle.TabIndex = 2;

            this.txtPrecio.Font = new Font("Segoe UI", 10F);
            this.txtPrecio.Location = new Point(15, 240);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new Size(150, 25);
            this.txtPrecio.TabIndex = 5;

            this.lblPrecio.Font = new Font("Segoe UI", 9F);
            this.lblPrecio.Location = new Point(15, 220);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new Size(280, 18);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio Base ($) *";

            this.txtDescripcion.Font = new Font("Segoe UI", 10F);
            this.txtDescripcion.Location = new Point(15, 145);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(280, 65);
            this.txtDescripcion.TabIndex = 3;

            this.lblDescripcion.Font = new Font("Segoe UI", 9F);
            this.lblDescripcion.Location = new Point(15, 125);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(280, 18);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción";

            this.txtNombre.Font = new Font("Segoe UI", 10F);
            this.txtNombre.Location = new Point(15, 85);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(280, 25);
            this.txtNombre.TabIndex = 1;

            this.lblNombre.Font = new Font("Segoe UI", 9F);
            this.lblNombre.Location = new Point(15, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(280, 18);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre *";

            this.lblDetalleTitulo.Dock = DockStyle.Top;
            this.lblDetalleTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblDetalleTitulo.Location = new Point(15, 15);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new Size(290, 35);
            this.lblDetalleTitulo.TabIndex = 6;
            this.lblDetalleTitulo.Text = "Detalle del artículo";

            this.pnlBotones.BackColor = Color.FromArgb(240, 244, 248);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Dock = DockStyle.Bottom;
            this.pnlBotones.Location = new Point(0, 505);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new Padding(10);
            this.pnlBotones.Size = new Size(880, 55);
            this.pnlBotones.TabIndex = 3;

            this.btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = FlatStyle.Flat;
            this.btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnEliminar.ForeColor = Color.White;
            this.btnEliminar.Location = new Point(260, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(110, 35);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(130, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(120, 35);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnNuevo.BackColor = Color.FromArgb(26, 58, 92);
            this.btnNuevo.FlatStyle = FlatStyle.Flat;
            this.btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNuevo.ForeColor = Color.White;
            this.btnNuevo.Location = new Point(10, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(110, 35);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.BackgroundColor = Color.White;
            this.dgvArticulos.BorderStyle = BorderStyle.None;
            this.dgvArticulos.ColumnHeadersHeight = 32;
            this.dgvArticulos.Dock = DockStyle.Fill;
            this.dgvArticulos.Location = new Point(0, 92);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowHeadersVisible = false;
            this.dgvArticulos.RowTemplate.Height = 28;
            this.dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new Size(560, 413);
            this.dgvArticulos.TabIndex = 4;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(880, 560);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(700, 450);
            this.Name = "FormArticulo";
            this.Text = "Artículos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlBusqueda;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Panel pnlDetalle;
        private TextBox txtPrecio;
        private Label lblPrecio;
        private TextBox txtDescripcion;
        private Label lblDescripcion;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblDetalleTitulo;
        private Panel pnlBotones;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnNuevo;
        private DataGridView dgvArticulos;
    }
}
