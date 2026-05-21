using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class FormMenu
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
            this.menuStrip = new MenuStrip();
            this.mnuInventario = new ToolStripMenuItem();
            this.mnuArticulos = new ToolStripMenuItem();
            this.mnuLotes = new ToolStripMenuItem();
            this.mnuPostoresMenu = new ToolStripMenuItem();
            this.mnuPostores = new ToolStripMenuItem();
            this.mnuSubastasMenu = new ToolStripMenuItem();
            this.mnuSubastas = new ToolStripMenuItem();
            this.mnuReportesMenu = new ToolStripMenuItem();
            this.mnuReportes = new ToolStripMenuItem();
            this.mnuVentana = new ToolStripMenuItem();
            this.mnuMosaico = new ToolStripMenuItem();
            this.mnuCascada = new ToolStripMenuItem();
            this.mnuCerrarTodas = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.lblEstadoConexion = new ToolStripStatusLabel();
            this.lblSeparador = new ToolStripStatusLabel();
            this.lblFechaHora = new ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            this.menuStrip.BackColor = Color.FromArgb(30, 20, 10);
            this.menuStrip.Font = new Font("Segoe UI", 10F);
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.mnuInventario, this.mnuPostoresMenu,
                this.mnuSubastasMenu, this.mnuReportesMenu, this.mnuVentana});
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new Padding(5, 3, 0, 3);
            this.menuStrip.Size = new Size(1200, 32);
            this.menuStrip.TabIndex = 0;

            this.mnuInventario.ForeColor = Color.FromArgb(192, 148, 48);
            this.mnuInventario.Name = "mnuInventario";
            this.mnuInventario.Text = "Inventario";
            this.mnuInventario.DropDownItems.AddRange(new ToolStripItem[] { this.mnuArticulos, this.mnuLotes });

            this.mnuArticulos.Name = "mnuArticulos";
            this.mnuArticulos.Text = "Artículos";
            this.mnuArticulos.Click += new System.EventHandler(this.mnuArticulos_Click);

            this.mnuLotes.Name = "mnuLotes";
            this.mnuLotes.Text = "Lotes";
            this.mnuLotes.Click += new System.EventHandler(this.mnuLotes_Click);

            this.mnuPostoresMenu.ForeColor = Color.FromArgb(192, 148, 48);
            this.mnuPostoresMenu.Name = "mnuPostoresMenu";
            this.mnuPostoresMenu.Text = "Postores";
            this.mnuPostoresMenu.DropDownItems.Add(this.mnuPostores);

            this.mnuPostores.Name = "mnuPostores";
            this.mnuPostores.Text = "Gestionar Postores";
            this.mnuPostores.Click += new System.EventHandler(this.mnuPostores_Click);

            this.mnuSubastasMenu.ForeColor = Color.FromArgb(192, 148, 48);
            this.mnuSubastasMenu.Name = "mnuSubastasMenu";
            this.mnuSubastasMenu.Text = "Subastas";
            this.mnuSubastasMenu.DropDownItems.Add(this.mnuSubastas);

            this.mnuSubastas.Name = "mnuSubastas";
            this.mnuSubastas.Text = "Gestionar Subastas";
            this.mnuSubastas.Click += new System.EventHandler(this.mnuSubastas_Click);

            this.mnuReportesMenu.ForeColor = Color.FromArgb(192, 148, 48);
            this.mnuReportesMenu.Name = "mnuReportesMenu";
            this.mnuReportesMenu.Text = "Reportes";
            this.mnuReportesMenu.DropDownItems.Add(this.mnuReportes);

            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Text = "Reporte de Jornada";
            this.mnuReportes.Click += new System.EventHandler(this.mnuReportes_Click);

            this.mnuVentana.ForeColor = Color.FromArgb(192, 148, 48);
            this.mnuVentana.Name = "mnuVentana";
            this.mnuVentana.Text = "Ventana";
            this.mnuVentana.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuMosaico, this.mnuCascada,
                new ToolStripSeparator(), this.mnuCerrarTodas });

            this.mnuMosaico.Name = "mnuMosaico";
            this.mnuMosaico.Text = "Mosaico";
            this.mnuMosaico.Click += new System.EventHandler(this.mnuMosaico_Click);

            this.mnuCascada.Name = "mnuCascada";
            this.mnuCascada.Text = "Cascada";
            this.mnuCascada.Click += new System.EventHandler(this.mnuCascada_Click);

            this.mnuCerrarTodas.Name = "mnuCerrarTodas";
            this.mnuCerrarTodas.Text = "Cerrar todas";
            this.mnuCerrarTodas.Click += new System.EventHandler(this.mnuCerrarTodas_Click);

            this.statusStrip.BackColor = Color.FromArgb(30, 20, 10);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblEstadoConexion, this.lblSeparador, this.lblFechaHora });
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1200, 24);
            this.statusStrip.TabIndex = 1;

            this.lblEstadoConexion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblEstadoConexion.ForeColor = Color.FromArgb(192, 148, 48);
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Text = "● Verificando...";

            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Spring = true;
            this.lblSeparador.Text = "";

            this.lblFechaHora.Font = new Font("Segoe UI", 9F);
            this.lblFechaHora.ForeColor = Color.FromArgb(245, 240, 228);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Text = "00/00/0000  00:00:00";

            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            this.timer.Start();

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(250, 245, 235);
            this.ClientSize = new Size(1200, 750);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new Font("Segoe UI", 9F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new Size(900, 600);
            this.Name = "FormMenu";
            this.Text = "La Almoneda Nacional  –  Sistema de Subastas";
            this.WindowState = FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuInventario;
        private ToolStripMenuItem mnuArticulos;
        private ToolStripMenuItem mnuLotes;
        private ToolStripMenuItem mnuPostoresMenu;
        private ToolStripMenuItem mnuPostores;
        private ToolStripMenuItem mnuSubastasMenu;
        private ToolStripMenuItem mnuSubastas;
        private ToolStripMenuItem mnuReportesMenu;
        private ToolStripMenuItem mnuReportes;
        private ToolStripMenuItem mnuVentana;
        private ToolStripMenuItem mnuMosaico;
        private ToolStripMenuItem mnuCascada;
        private ToolStripMenuItem mnuCerrarTodas;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblEstadoConexion;
        private ToolStripStatusLabel lblSeparador;
        private ToolStripStatusLabel lblFechaHora;
        private System.Windows.Forms.Timer timer;
    }
}
