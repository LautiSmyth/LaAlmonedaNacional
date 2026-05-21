using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormMenu : Form
    {
        private readonly SubastaBLL _subastaBLL = new SubastaBLL();

        public FormMenu()
        {
            InitializeComponent();
            VerificarConexion();
            CargarSubastasActivas();
        }

        private void VerificarConexion()
        {
            bool conectado = _subastaBLL.VerificarConexion();
            lblEstadoConexion.Text = conectado ? "● Conectado" : "● Sin conexión";
            lblEstadoConexion.ForeColor = conectado ? Color.LimeGreen : Color.OrangeRed;
            if (!conectado)
                MessageBox.Show(
                    "No se pudo conectar a la base de datos.\nVerifique la cadena de conexión en App.config.",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CargarSubastasActivas()
        {
            try { _subastaBLL.CargarSubastasActivas(); }
            catch { }
        }

        private void timer_Tick(object sender, EventArgs e)
            => lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");

        private void mnuArticulos_Click(object sender, EventArgs e) => AbrirFormHijo<FormArticulo>();

        private void mnuLotes_Click(object sender, EventArgs e) => AbrirFormHijo<FormLote>();

        private void mnuPostores_Click(object sender, EventArgs e) => AbrirFormHijo<FormPostor>();

        private void mnuSubastas_Click(object sender, EventArgs e) => AbrirFormHijo<FormSubasta>();

        private void mnuReportes_Click(object sender, EventArgs e) => AbrirFormHijo<FormReporte>();

        private void mnuCerrarTodas_Click(object sender, EventArgs e)
        {
            foreach (Form hijo in MdiChildren) hijo.Close();
        }

        private void mnuMosaico_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileHorizontal);

        private void mnuCascada_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);

        private void AbrirFormHijo<T>() where T : Form, new()
        {
            foreach (Form hijo in MdiChildren)
            {
                if (hijo is T) { hijo.Activate(); return; }
            }
            T formulario = new T();
            formulario.MdiParent = this;
            formulario.Show();
        }
    }
}