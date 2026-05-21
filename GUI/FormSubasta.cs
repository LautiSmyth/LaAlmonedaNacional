using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormSubasta : Form
    {
        private readonly SubastaBLL       _subastaBLL = new SubastaBLL();
        private readonly PostorBLL        _postorBLL  = new PostorBLL();
        private readonly UnidadDeVentaBLL _udvBLL     = new UnidadDeVentaBLL();

        private Subasta              _subastaActual  = null;
        private List<UnidadDeVenta>  _catalogoCompleto = new List<UnidadDeVenta>();
        private List<Postor>         _postoresCache  = new List<Postor>();

        private class EntradaLog
        {
            public string Tiempo;
            public string SubastaNombre;
            public int    SubastaId;
            public string PostorNombre;
            public string Mensaje;
        }
        private readonly List<EntradaLog> _log = new List<EntradaLog>();

        public FormSubasta()
        {
            InitializeComponent();
            AplicarEstilo();
            ConfigurarLimitesEntrada();
            CargarSubastasActivas();
            CargarCatalogo();
            CargarPostores();
        }

        private void AplicarEstilo()
        {
            dgvSuscriptores.ColumnHeadersDefaultCellStyle.BackColor = Estilo.Header;
            dgvSuscriptores.ColumnHeadersDefaultCellStyle.ForeColor = Estilo.Gold;
            dgvSuscriptores.ColumnHeadersDefaultCellStyle.Font      =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvSuscriptores.AlternatingRowsDefaultCellStyle.BackColor = Estilo.RowAlt;
            dgvSuscriptores.DefaultCellStyle.SelectionBackColor = Estilo.Gold;
            dgvSuscriptores.DefaultCellStyle.SelectionForeColor = Estilo.Header;
        }

        private void ConfigurarLimitesEntrada()
        {
            txtMontoPuja.MaxLength  = 21;
            txtMontoPuja.KeyPress  += txtDecimal_KeyPress;
        }

        private void txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            bool esSeparador = e.KeyChar == ',' || e.KeyChar == '.';
            bool esDigito    = char.IsDigit(e.KeyChar);
            bool esBackspace = e.KeyChar == (char)Keys.Back;

            if (!esDigito && !esSeparador && !esBackspace)
            { e.Handled = true; return; }

            if (esSeparador && (tb.Text.Contains(",") || tb.Text.Contains(".")))
                e.Handled = true;
        }

        private void CargarSubastasActivas()
        {
            try
            {
                DataTable tabla = _subastaBLL.ObtenerSubastasActivas();
                lstSubastas.DataSource    = null;
                lstSubastas.DataSource    = tabla;
                lstSubastas.DisplayMember = "NombreItem";
                lstSubastas.ValueMember   = "Id";
                ActualizarFiltroSubastaLog(tabla);
            }
            catch (Exception ex) { MostrarError("Error al cargar subastas", ex); }
        }

        private void ActualizarFiltroSubastaLog(DataTable tabla)
        {
            string seleccionActual = cmbFiltroSubasta.SelectedItem?.ToString();
            cmbFiltroSubasta.Items.Clear();
            cmbFiltroSubasta.Items.Add("Todas las subastas");
            foreach (DataRow fila in tabla.Rows)
                cmbFiltroSubasta.Items.Add(fila["NombreItem"].ToString());
            cmbFiltroSubasta.SelectedIndex = 0;
            if (seleccionActual != null)
            {
                int idx = cmbFiltroSubasta.Items.IndexOf(seleccionActual);
                if (idx >= 0) cmbFiltroSubasta.SelectedIndex = idx;
            }
        }

        private void CargarCatalogo()
        {
            try
            {
                _catalogoCompleto = _udvBLL.ObtenerCatalogo();
                AplicarFiltroTipoItem();
            }
            catch (Exception ex) { MostrarError("Error al cargar catálogo", ex); }
        }

        private void AplicarFiltroTipoItem()
        {
            List<UnidadDeVenta> filtrado;
            if (rbSoloArticulos.Checked)
                filtrado = _catalogoCompleto.FindAll(u => u is Articulo);
            else if (rbSoloLotes.Checked)
                filtrado = _catalogoCompleto.FindAll(u => u is Lote);
            else
                filtrado = _catalogoCompleto;

            cmbItem.DataSource         = null;
            cmbItem.DataSource         = new List<UnidadDeVenta>(filtrado);
            cmbItem.DisplayMember      = "Nombre";
            cmbItem.AutoCompleteMode   = AutoCompleteMode.SuggestAppend;
            cmbItem.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarPostores()
        {
            try
            {
                _postoresCache = _postorBLL.ObtenerTodos();

                cmbPostorSuscribir.DataSource         = null;
                cmbPostorSuscribir.DataSource         = new List<Postor>(_postoresCache);
                cmbPostorSuscribir.DisplayMember      = "NombrePostor";
                cmbPostorSuscribir.AutoCompleteMode   = AutoCompleteMode.SuggestAppend;
                cmbPostorSuscribir.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbPostorPuja.DataSource         = null;
                cmbPostorPuja.DataSource         = new List<Postor>(_postoresCache);
                cmbPostorPuja.DisplayMember      = "NombrePostor";
                cmbPostorPuja.AutoCompleteMode   = AutoCompleteMode.SuggestAppend;
                cmbPostorPuja.AutoCompleteSource = AutoCompleteSource.ListItems;

                ActualizarFiltroPostorLog();
            }
            catch (Exception ex) { MostrarError("Error al cargar postores", ex); }
        }

        private void ActualizarFiltroPostorLog()
        {
            string seleccionActual = cmbFiltroPostor.SelectedItem?.ToString();
            cmbFiltroPostor.Items.Clear();
            cmbFiltroPostor.Items.Add("Todos los postores");
            foreach (var p in _postoresCache)
                cmbFiltroPostor.Items.Add(p.NombrePostor);
            cmbFiltroPostor.SelectedIndex = 0;
            if (seleccionActual != null)
            {
                int idx = cmbFiltroPostor.Items.IndexOf(seleccionActual);
                if (idx >= 0) cmbFiltroPostor.SelectedIndex = idx;
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)        => AplicarFiltroTipoItem();
        private void rbSoloArticulos_CheckedChanged(object sender, EventArgs e) => AplicarFiltroTipoItem();
        private void rbSoloLotes_CheckedChanged(object sender, EventArgs e)     => AplicarFiltroTipoItem();

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
                    AgregarLog("Subasta no encontrada en memoria. Recargue la lista.", null, null);
                    return;
                }
                _subastaActual.OnNotificacionSuscriptor -= OnNotificacionSuscriptorSubasta;
                _subastaActual.OnNotificacionSuscriptor += OnNotificacionSuscriptorSubasta;
                ActualizarPanelSubasta();
                CargarSuscriptores(subastaId);
                btnCerrar.Enabled      = true;
                btnOferta.Enabled      = true;
                btnSuscribir.Enabled   = true;
                btnDesuscribir.Enabled = true;
            }
            catch (Exception ex) { MostrarError("Error al seleccionar subasta", ex); }
        }

        private void OnNotificacionSuscriptorSubasta(IObserver suscriptor, string mensaje)
        {
            AgregarLog($"[{suscriptor.NombrePostor}] {mensaje}",
                suscriptor.NombrePostor, _subastaActual?.ItemSubastado?.Nombre);
        }

        private void ActualizarPanelSubasta()
        {
            if (_subastaActual == null) return;
            lblItemSubasta.Text   = $"Ítem: {_subastaActual.ItemSubastado.Nombre}";
            lblPrecioActual.Text  = $"${_subastaActual.OfertaActual:N2}";
            lblGanadorActual.Text = _subastaActual.PostorGanador?.NombrePostor ?? "Sin ofertas";
            lblFechaInicio.Text   = $"Inicio: {_subastaActual.FechaInicio:dd/MM/yyyy HH:mm}";
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
                    dgvSuscriptores.Columns["Id"].Visible              = false;
                    dgvSuscriptores.Columns["NombrePostor"].HeaderText = "Nombre";
                    dgvSuscriptores.Columns["NombrePostor"].Width      = 160;
                    dgvSuscriptores.Columns["Email"].HeaderText        = "Email";
                    dgvSuscriptores.Columns["Email"].Width             = 180;
                    if (dgvSuscriptores.Columns.Contains("Telefono"))
                        dgvSuscriptores.Columns["Telefono"].Visible = false;
                    if (dgvSuscriptores.Columns.Contains("OnNotificacion"))
                        dgvSuscriptores.Columns["OnNotificacion"].Visible = false;
                }
            }
            catch (Exception ex) { AgregarLog($"Error al cargar suscriptores: {ex.Message}", null, null); }
        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            if (!(cmbItem.SelectedItem is UnidadDeVenta item)) return;
            try
            {
                Subasta nueva = _subastaBLL.CrearSubasta(item.Id);
                nueva.OnNotificacionSuscriptor += OnNotificacionSuscriptorSubasta;
                AgregarLog($"Subasta #{nueva.Id} creada para '{item.Nombre}' | Base: ${item.ObtenerPrecio():N2}",
                    null, item.Nombre);
                CargarSubastasActivas();
            }
            catch (Exception ex) { MostrarError("Error al crear subasta", ex); }
        }

        private void btnSuscribir_Click(object sender, EventArgs e)
        {
            if (_subastaActual == null) { MostrarAviso("Seleccione una subasta primero."); return; }
            if (!(cmbPostorSuscribir.SelectedItem is Postor postor)) return;
            try
            {
                _subastaBLL.Suscribir(_subastaActual.Id, postor.Id);
                CargarSuscriptores(_subastaActual.Id);
                AgregarLog($"{postor.NombrePostor} suscripto a la subasta.",
                    postor.NombrePostor, _subastaActual.ItemSubastado.Nombre);
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
                    AgregarLog($"{postor.NombrePostor} desuscripto de la subasta.",
                        postor.NombrePostor, _subastaActual.ItemSubastado.Nombre);
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

            string textoMonto = txtMontoPuja.Text.Trim().Replace(",", ".");
            if (!decimal.TryParse(textoMonto, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
            { MostrarAviso("Ingrese un monto numérico válido mayor a cero."); txtMontoPuja.Focus(); return; }

            try
            {
                string subastaNombre = _subastaActual.ItemSubastado.Nombre;
                _subastaBLL.RealizarOferta(_subastaActual.Id, postor.Id, monto,
                    (msg) => AgregarLog(msg, postor.NombrePostor, subastaNombre));
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
                btnCerrar.Enabled      = false;
                btnOferta.Enabled      = false;
                btnSuscribir.Enabled   = false;
                btnDesuscribir.Enabled = false;
                _subastaActual         = null;
                CargarSubastasActivas();
            }
            catch (Exception ex) { MostrarError("Error al cerrar subasta", ex); }
        }

        private void AgregarLog(string mensaje, string postorNombre, string subastaNombre)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action<string, string, string>(AgregarLog), mensaje, postorNombre, subastaNombre);
                return;
            }
            _log.Add(new EntradaLog
            {
                Tiempo        = DateTime.Now.ToString("HH:mm:ss"),
                Mensaje       = mensaje,
                PostorNombre  = postorNombre,
                SubastaNombre = subastaNombre,
                SubastaId     = _subastaActual?.Id ?? 0
            });
            RenderizarLog();
        }

        private void RenderizarLog()
        {
            string filtroPostor  = cmbFiltroPostor.SelectedIndex  <= 0 ? null : cmbFiltroPostor.SelectedItem?.ToString();
            string filtroSubasta = cmbFiltroSubasta.SelectedIndex <= 0 ? null : cmbFiltroSubasta.SelectedItem?.ToString();

            rtbLog.Clear();
            foreach (var entrada in _log)
            {
                if (filtroPostor  != null && entrada.PostorNombre  != filtroPostor)  continue;
                if (filtroSubasta != null && entrada.SubastaNombre != filtroSubasta) continue;
                rtbLog.AppendText($"[{entrada.Tiempo}]  {entrada.Mensaje}{Environment.NewLine}");
            }
            rtbLog.ScrollToCaret();
        }

        private void cmbFiltroPostor_SelectedIndexChanged(object sender, EventArgs e)  => RenderizarLog();
        private void cmbFiltroSubasta_SelectedIndexChanged(object sender, EventArgs e) => RenderizarLog();

        private void btnLimpiarLog_Click(object sender, EventArgs e)
        {
            _log.Clear();
            rtbLog.Clear();
        }

        private void MostrarAviso(string msg) =>
            MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MostrarError(string ctx, Exception ex) =>
            MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
