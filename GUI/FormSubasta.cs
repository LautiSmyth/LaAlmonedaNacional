using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormSubasta : Form
    {
        private readonly SubastaBLL _subastaBLL = new SubastaBLL();
        private readonly PostorBLL _postorBLL = new PostorBLL();
        private readonly UnidadDeVentaBLL _udvBLL = new UnidadDeVentaBLL();

        private Subasta _subastaActual = null;

        public FormSubasta()
        {
            InitializeComponent();
            CargarSubastasActivas();
            CargarCatalogo();
            CargarPostores();
        }

        private void CargarSubastasActivas()
        {
            try
            {
                DataTable tabla = _subastaBLL.ObtenerSubastasActivas();
                lstSubastas.DataSource = null;
                lstSubastas.DataSource = tabla;
                lstSubastas.DisplayMember = "NombreItem";
                lstSubastas.ValueMember = "Id";
            }
            catch (Exception ex) { MostrarError("Error al cargar subastas", ex); }
        }

        private void CargarCatalogo()
        {
            try
            {
                var catalogo = _udvBLL.ObtenerCatalogo();
                cmbItem.DataSource = null;
                cmbItem.DataSource = catalogo;
                cmbItem.DisplayMember = "Nombre";
            }
            catch (Exception ex) { MostrarError("Error al cargar catálogo", ex); }
        }

        private void CargarPostores()
        {
            try
            {
                var postores = _postorBLL.ObtenerTodos();
                cmbPostorSuscribir.DataSource = null;
                cmbPostorSuscribir.DataSource = new List<Postor>(postores);
                cmbPostorSuscribir.DisplayMember = "NombrePostor";
                cmbPostorPuja.DataSource = null;
                cmbPostorPuja.DataSource = new List<Postor>(postores);
                cmbPostorPuja.DisplayMember = "NombrePostor";
            }
            catch (Exception ex) { MostrarError("Error al cargar postores", ex); }
        }

        private void lstSubastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(lstSubastas.SelectedItem is DataRowView row)) return;
            try
            {
                int subastaId = Convert.ToInt32(row["Id"]);
                _subastaActual = _subastaBLL.ObtenerSubastaEnMemoria(subastaId);
                if (_subastaActual == null)
                {
                    _subastaBLL.CargarSubastasActivas();
                    _subastaActual = _subastaBLL.ObtenerSubastaEnMemoria(subastaId);
                }
                if (_subastaActual == null)
                {
                    AgregarLog("Subasta no encontrada en memoria. Recargue la lista.");
                    return;
                }
                _subastaActual.OnNotificacion -= AgregarLog;
                _subastaActual.OnNotificacion += AgregarLog;
                ActualizarPanelSubasta();
                CargarSuscriptores(subastaId);
                btnCerrar.Enabled = true;
                btnOferta.Enabled = true;
                btnSuscribir.Enabled = true;
                btnDesuscribir.Enabled = true;
            }
            catch (Exception ex) { MostrarError("Error al seleccionar subasta", ex); }
        }

        private void ActualizarPanelSubasta()
        {
            if (_subastaActual == null) return;
            lblItemSubasta.Text = $"Ítem: {_subastaActual.ItemSubastado.Nombre}";
            lblPrecioActual.Text = $"${_subastaActual.OfertaActual:N2}";
            lblGanadorActual.Text = _subastaActual.PostorGanador?.NombrePostor ?? "Sin ofertas";
            lblFechaInicio.Text = $"Inicio: {_subastaActual.FechaInicio:dd/MM/yyyy HH:mm}";
        }

        private void CargarSuscriptores(int subastaId)
        {
            try
            {
                var suscriptores = _postorBLL.ObtenerSuscriptores(subastaId);
                dgvSuscriptores.DataSource = null;
                dgvSuscriptores.DataSource = suscriptores;
                if (dgvSuscriptores.Columns.Count > 0)
                {
                    dgvSuscriptores.Columns["Id"].Visible = false;
                    dgvSuscriptores.Columns["NombrePostor"].HeaderText = "Nombre";
                    dgvSuscriptores.Columns["NombrePostor"].Width = 160;
                    dgvSuscriptores.Columns["Email"].HeaderText = "Email";
                    dgvSuscriptores.Columns["Email"].Width = 180;
                    if (dgvSuscriptores.Columns.Contains("Telefono"))
                        dgvSuscriptores.Columns["Telefono"].Visible = false;
                    if (dgvSuscriptores.Columns.Contains("OnNotificacion"))
                        dgvSuscriptores.Columns["OnNotificacion"].Visible = false;
                }
            }
            catch (Exception ex) { AgregarLog($"Error al cargar suscriptores: {ex.Message}"); }
        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            if (cmbItem.SelectedItem is UnidadDeVenta item)
            {
                try
                {
                    Subasta nueva = _subastaBLL.CrearSubasta(item.Id);
                    AgregarLog($"Subasta #{nueva.Id} creada para '{item.Nombre}' | Base: ${item.ObtenerPrecio():N2}");
                    CargarSubastasActivas();
                }
                catch (Exception ex) { MostrarError("Error al crear subasta", ex); }
            }
        }

        private void btnSuscribir_Click(object sender, EventArgs e)
        {
            if (_subastaActual == null) { MostrarAviso("Seleccione una subasta primero."); return; }
            if (!(cmbPostorSuscribir.SelectedItem is Postor postor)) return;
            try
            {
                postor.OnNotificacion = AgregarLog;
                _subastaBLL.Suscribir(_subastaActual.Id, postor.Id);
                CargarSuscriptores(_subastaActual.Id);
                AgregarLog($"{postor.NombrePostor} suscripto a la subasta.");
            }
            catch (Exception ex) { MostrarError("Error al suscribir", ex); }
        }

        private void btnDesuscribir_Click(object sender, EventArgs e)
        {
            if (_subastaActual == null) return;
            if (dgvSuscriptores.CurrentRow?.DataBoundItem is Postor postor)
            {
                try
                {
                    _subastaBLL.Desuscribir(_subastaActual.Id, postor.Id);
                    CargarSuscriptores(_subastaActual.Id);
                    AgregarLog($"{postor.NombrePostor} desuscripto de la subasta.");
                }
                catch (Exception ex) { MostrarError("Error al desuscribir", ex); }
            }
            else MostrarAviso("Seleccione un postor de la lista de suscriptores.");
        }

        private void btnOferta_Click(object sender, EventArgs e)
        {
            if (_subastaActual == null) { MostrarAviso("Seleccione una subasta."); return; }
            if (!(cmbPostorPuja.SelectedItem is Postor postor))
            { MostrarAviso("Seleccione un postor."); return; }
            if (!decimal.TryParse(txtMontoPuja.Text.Trim(), out decimal monto) || monto <= 0)
            { MostrarAviso("Ingrese un monto válido mayor a cero."); txtMontoPuja.Focus(); return; }
            try
            {
                _subastaBLL.RealizarOferta(_subastaActual.Id, postor.Id, monto, AgregarLog);
                ActualizarPanelSubasta();
                txtMontoPuja.Clear();
            }
            catch (Exception ex) { MostrarError("Oferta rechazada", ex); }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (_subastaActual == null) return;
            if (MessageBox.Show("¿Cerrar la subasta y adjudicar al ganador actual?",
                "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _subastaBLL.CerrarSubasta(_subastaActual.Id);
                btnCerrar.Enabled = false;
                btnOferta.Enabled = false;
                btnSuscribir.Enabled = false;
                btnDesuscribir.Enabled = false;
                _subastaActual = null;
                CargarSubastasActivas();
            }
            catch (Exception ex) { MostrarError("Error al cerrar subasta", ex); }
        }

        private void AgregarLog(string mensaje)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action<string>(AgregarLog), mensaje);
                return;
            }
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}]  {mensaje}{Environment.NewLine}");
            rtbLog.ScrollToCaret();
        }

        private void btnLimpiarLog_Click(object sender, EventArgs e) => rtbLog.Clear();

        private void MostrarAviso(string msg) => MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MostrarError(string ctx, Exception ex) =>
            MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
