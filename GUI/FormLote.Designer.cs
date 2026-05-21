using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FormLote
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
            this.splitMain = new SplitContainer();
            this.lblListaLotes = new Label();
            this.lstLotes = new ListBox();
            this.lblNombreLote = new Label();
            this.txtNombreLote = new TextBox();
            this.lblDescLote = new Label();
            this.txtDescLote = new TextBox();
            this.btnCrearLote = new Button();
            this.btnActualizar = new Button();
            this.btnEliminarLote = new Button();
            this.lblArbol = new Label();
            this.trvLote = new TreeView();
            this.lblPrecioLote = new Label();
            this.lblCompLabel = new Label();
            this.cmbComponentes = new ComboBox();
            this.btnAgregarComp = new Button();
            this.btnQuitarComp = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = Color.FromArgb(26, 58, 92);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(950, 50);
            this.pnlHeader.TabIndex = 0;

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new Padding(10, 0, 0, 0);
            this.lblTitulo.Size = new Size(950, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Lotes (Composite)";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.splitMain.Dock = DockStyle.Fill;
            this.splitMain.Location = new Point(0, 50);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1MinSize = 280;
            this.splitMain.Panel2MinSize = 300;
            this.splitMain.Size = new Size(950, 530);
            this.splitMain.SplitterDistance = 350;
            this.splitMain.TabIndex = 1;

            this.splitMain.Panel1.BackColor = Color.White;
            this.splitMain.Panel1.Controls.Add(this.btnEliminarLote);
            this.splitMain.Panel1.Controls.Add(this.btnActualizar);
            this.splitMain.Panel1.Controls.Add(this.btnCrearLote);
            this.splitMain.Panel1.Controls.Add(this.txtDescLote);
            this.splitMain.Panel1.Controls.Add(this.lblDescLote);
            this.splitMain.Panel1.Controls.Add(this.txtNombreLote);
            this.splitMain.Panel1.Controls.Add(this.lblNombreLote);
            this.splitMain.Panel1.Controls.Add(this.lstLotes);
            this.splitMain.Panel1.Controls.Add(this.lblListaLotes);
            this.splitMain.Panel1.Padding = new Padding(10);

            this.lblListaLotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblListaLotes.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblListaLotes.Location = new Point(10, 10);
            this.lblListaLotes.Name = "lblListaLotes";
            this.lblListaLotes.Size = new Size(320, 20);
            this.lblListaLotes.TabIndex = 0;
            this.lblListaLotes.Text = "Lotes creados:";

            this.lstLotes.Font = new Font("Segoe UI", 10F);
            this.lstLotes.Location = new Point(10, 32);
            this.lstLotes.Name = "lstLotes";
            this.lstLotes.Size = new Size(320, 155);
            this.lstLotes.TabIndex = 1;
            this.lstLotes.SelectedIndexChanged += new System.EventHandler(this.lstLotes_SelectedIndexChanged);

            this.lblNombreLote.Font = new Font("Segoe UI", 9F);
            this.lblNombreLote.Location = new Point(10, 198);
            this.lblNombreLote.Name = "lblNombreLote";
            this.lblNombreLote.Size = new Size(320, 18);
            this.lblNombreLote.TabIndex = 2;
            this.lblNombreLote.Text = "Nombre del lote *";

            this.txtNombreLote.Font = new Font("Segoe UI", 10F);
            this.txtNombreLote.Location = new Point(10, 218);
            this.txtNombreLote.Name = "txtNombreLote";
            this.txtNombreLote.Size = new Size(320, 25);
            this.txtNombreLote.TabIndex = 3;

            this.lblDescLote.Font = new Font("Segoe UI", 9F);
            this.lblDescLote.Location = new Point(10, 255);
            this.lblDescLote.Name = "lblDescLote";
            this.lblDescLote.Size = new Size(320, 18);
            this.lblDescLote.TabIndex = 4;
            this.lblDescLote.Text = "Descripción";

            this.txtDescLote.Font = new Font("Segoe UI", 10F);
            this.txtDescLote.Location = new Point(10, 275);
            this.txtDescLote.Multiline = true;
            this.txtDescLote.Name = "txtDescLote";
            this.txtDescLote.Size = new Size(320, 55);
            this.txtDescLote.TabIndex = 5;

            this.btnCrearLote.BackColor = Color.FromArgb(26, 58, 92);
            this.btnCrearLote.FlatStyle = FlatStyle.Flat;
            this.btnCrearLote.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCrearLote.ForeColor = Color.White;
            this.btnCrearLote.Location = new Point(10, 342);
            this.btnCrearLote.Name = "btnCrearLote";
            this.btnCrearLote.Size = new Size(120, 34);
            this.btnCrearLote.TabIndex = 6;
            this.btnCrearLote.Text = "Crear Lote";
            this.btnCrearLote.UseVisualStyleBackColor = false;
            this.btnCrearLote.Click += new System.EventHandler(this.btnCrearLote_Click);

            this.btnActualizar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnActualizar.Enabled = false;
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnActualizar.ForeColor = Color.White;
            this.btnActualizar.Location = new Point(140, 342);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(110, 34);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.btnEliminarLote.BackColor = Color.FromArgb(220, 53, 69);
            this.btnEliminarLote.Enabled = false;
            this.btnEliminarLote.FlatStyle = FlatStyle.Flat;
            this.btnEliminarLote.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnEliminarLote.ForeColor = Color.White;
            this.btnEliminarLote.Location = new Point(260, 342);
            this.btnEliminarLote.Name = "btnEliminarLote";
            this.btnEliminarLote.Size = new Size(100, 34);
            this.btnEliminarLote.TabIndex = 8;
            this.btnEliminarLote.Text = "Eliminar";
            this.btnEliminarLote.UseVisualStyleBackColor = false;
            this.btnEliminarLote.Click += new System.EventHandler(this.btnEliminarLote_Click);

            this.splitMain.Panel2.BackColor = Color.FromArgb(248, 250, 252);
            this.splitMain.Panel2.Controls.Add(this.btnQuitarComp);
            this.splitMain.Panel2.Controls.Add(this.btnAgregarComp);
            this.splitMain.Panel2.Controls.Add(this.cmbComponentes);
            this.splitMain.Panel2.Controls.Add(this.lblCompLabel);
            this.splitMain.Panel2.Controls.Add(this.lblPrecioLote);
            this.splitMain.Panel2.Controls.Add(this.trvLote);
            this.splitMain.Panel2.Controls.Add(this.lblArbol);
            this.splitMain.Panel2.Padding = new Padding(10);

            this.lblArbol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblArbol.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblArbol.Location = new Point(10, 10);
            this.lblArbol.Name = "lblArbol";
            this.lblArbol.Size = new Size(560, 20);
            this.lblArbol.TabIndex = 0;
            this.lblArbol.Text = "Estructura del Lote (árbol Composite):";

            this.trvLote.BackColor = Color.White;
            this.trvLote.BorderStyle = BorderStyle.FixedSingle;
            this.trvLote.Font = new Font("Segoe UI", 10F);
            this.trvLote.Location = new Point(10, 32);
            this.trvLote.Name = "trvLote";
            this.trvLote.Size = new Size(560, 260);
            this.trvLote.TabIndex = 1;

            this.lblPrecioLote.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPrecioLote.ForeColor = Color.FromArgb(212, 175, 55);
            this.lblPrecioLote.Location = new Point(10, 298);
            this.lblPrecioLote.Name = "lblPrecioLote";
            this.lblPrecioLote.Size = new Size(560, 24);
            this.lblPrecioLote.TabIndex = 2;

            this.lblCompLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCompLabel.ForeColor = Color.FromArgb(26, 58, 92);
            this.lblCompLabel.Location = new Point(10, 330);
            this.lblCompLabel.Name = "lblCompLabel";
            this.lblCompLabel.Size = new Size(560, 20);
            this.lblCompLabel.TabIndex = 3;
            this.lblCompLabel.Text = "Agregar componente al lote seleccionado:";

            this.cmbComponentes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbComponentes.Font = new Font("Segoe UI", 10F);
            this.cmbComponentes.Location = new Point(10, 355);
            this.cmbComponentes.Name = "cmbComponentes";
            this.cmbComponentes.Size = new Size(560, 25);
            this.cmbComponentes.TabIndex = 4;

            this.btnAgregarComp.BackColor = Color.FromArgb(26, 58, 92);
            this.btnAgregarComp.FlatStyle = FlatStyle.Flat;
            this.btnAgregarComp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAgregarComp.ForeColor = Color.White;
            this.btnAgregarComp.Location = new Point(10, 390);
            this.btnAgregarComp.Name = "btnAgregarComp";
            this.btnAgregarComp.Size = new Size(130, 34);
            this.btnAgregarComp.TabIndex = 5;
            this.btnAgregarComp.Text = "Agregar";
            this.btnAgregarComp.UseVisualStyleBackColor = false;
            this.btnAgregarComp.Click += new System.EventHandler(this.btnAgregarComp_Click);

            this.btnQuitarComp.BackColor = Color.FromArgb(255, 133, 27);
            this.btnQuitarComp.FlatStyle = FlatStyle.Flat;
            this.btnQuitarComp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnQuitarComp.ForeColor = Color.White;
            this.btnQuitarComp.Location = new Point(150, 390);
            this.btnQuitarComp.Name = "btnQuitarComp";
            this.btnQuitarComp.Size = new Size(180, 34);
            this.btnQuitarComp.TabIndex = 6;
            this.btnQuitarComp.Text = "Quitar seleccionado";
            this.btnQuitarComp.UseVisualStyleBackColor = false;
            this.btnQuitarComp.Click += new System.EventHandler(this.btnQuitarComp_Click);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(950, 580);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 9F);
            this.MinimumSize = new Size(750, 500);
            this.Name = "FormLote";
            this.Text = "Gestión de Lotes";
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private SplitContainer splitMain;
        private Label lblListaLotes;
        private ListBox lstLotes;
        private Label lblNombreLote;
        private TextBox txtNombreLote;
        private Label lblDescLote;
        private TextBox txtDescLote;
        private Button btnCrearLote;
        private Button btnActualizar;
        private Button btnEliminarLote;
        private Label lblArbol;
        private TreeView trvLote;
        private Label lblPrecioLote;
        private Label lblCompLabel;
        private ComboBox cmbComponentes;
        private Button btnAgregarComp;
        private Button btnQuitarComp;
    }
}
