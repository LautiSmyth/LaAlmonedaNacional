using BE;
using BLL;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormLote : Form
    {
        private readonly UnidadDeVentaBLL _bll = new UnidadDeVentaBLL();
        private Lote _loteSeleccionado = null;

        public FormLote()
        {
            InitializeComponent();
            AplicarEstilo();
            ConfigurarLimitesEntrada();
            CargarLotes();
            CargarComponentesDisponibles();
        }

        private void AplicarEstilo()
        {
            trvLote.BackColor = Color.White;
            trvLote.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ConfigurarLimitesEntrada()
        {
            txtNombreLote.MaxLength = 200;
            txtDescLote.MaxLength = 500;
        }

        private void CargarLotes()
        {
            try
            {
                lstLotes.DataSource = null;
                lstLotes.DataSource = _bll.ObtenerLotes();
                lstLotes.DisplayMember = "Nombre";
            }
            catch (Exception ex) { MostrarError("Error al cargar lotes", ex); }
        }

        private void CargarComponentesDisponibles()
        {
            try
            {
                var catalogo = _bll.ObtenerCatalogo();
                cmbComponentes.DataSource = null;
                cmbComponentes.DataSource = catalogo;
                cmbComponentes.DisplayMember = "Nombre";
                cmbComponentes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbComponentes.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex) { MostrarError("Error al cargar catálogo", ex); }
        }

        private void lstLotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLotes.SelectedItem is Lote lote)
            {
                _loteSeleccionado = lote;
                txtNombreLote.Text = lote.Nombre;
                txtDescLote.Text = lote.Descripcion;
                btnActualizar.Enabled = true;
                btnEliminarLote.Enabled = true;
                RefrescarArbolLote(lote.Id);
            }
        }

        private void txtNombreLote_Enter(object sender, EventArgs e)
        {
            if (_loteSeleccionado == null && string.IsNullOrWhiteSpace(txtNombreLote.Text))
                txtNombreLote.Text = "[Lote] ";
        }

        private void RefrescarArbolLote(int loteId)
        {
            try
            {
                trvLote.Nodes.Clear();
                UnidadDeVenta udv = _bll.ObtenerPorId(loteId);
                if (udv is Lote loteCompleto)
                {
                    trvLote.Nodes.Add(CrearNodoArbol(loteCompleto));
                    trvLote.ExpandAll();
                    lblPrecioLote.Text = $"Precio acumulado: ${loteCompleto.ObtenerPrecio():N2}";
                }
            }
            catch (Exception ex) { MostrarError("Error al cargar árbol del lote", ex); }
        }

        private TreeNode CrearNodoArbol(UnidadDeVenta udv)
        {
            if (udv is Lote lote)
            {
                var nodo = new TreeNode($"[Lote] {lote.Nombre}  (${lote.ObtenerPrecio():N2})")
                { Tag = lote, ForeColor = Estilo.Header };
                foreach (var comp in lote.ObtenerComponentes())
                    nodo.Nodes.Add(CrearNodoArbol(comp));
                return nodo;
            }
            if (udv is Articulo art)
                return new TreeNode($"[Artículo] {art.Nombre}  (${art.PrecioBase:N2})")
                { Tag = art, ForeColor = Estilo.BtnSuccess };
            return new TreeNode(udv.Nombre);
        }

        private void btnCrearLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreLote.Text) || txtNombreLote.Text.Trim() == "[Lote]")
            { MostrarAviso("El nombre del lote es obligatorio."); txtNombreLote.Focus(); return; }
            try
            {
                Lote nuevo = _bll.CrearLote(txtNombreLote.Text.Trim(), txtDescLote.Text.Trim());
                MostrarExito($"Lote '{nuevo.Nombre}' creado (Id={nuevo.Id}).");
                LimpiarFormulario();
                CargarLotes();
                CargarComponentesDisponibles();
            }
            catch (Exception ex) { MostrarError("Error al crear lote", ex); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_loteSeleccionado == null) return;
            if (string.IsNullOrWhiteSpace(txtNombreLote.Text))
            { MostrarAviso("El nombre no puede estar vacío."); return; }
            try
            {
                _loteSeleccionado.Nombre = txtNombreLote.Text.Trim();
                _loteSeleccionado.Descripcion = txtDescLote.Text.Trim();
                _bll.ActualizarLote(_loteSeleccionado);
                MostrarExito("Lote actualizado.");
                CargarLotes();
            }
            catch (Exception ex) { MostrarError("Error al actualizar lote", ex); }
        }

        private void btnEliminarLote_Click(object sender, EventArgs e)
        {
            if (_loteSeleccionado == null) return;

            if (MessageBox.Show(
                    $"¿Eliminar el lote '{_loteSeleccionado.Nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                UnidadDeVenta udv = _bll.ObtenerPorId(_loteSeleccionado.Id);
                bool tieneHijos = udv is Lote lt && lt.ObtenerComponentes().Count > 0;

                if (tieneHijos)
                {
                    var loteContenido = (Lote)udv;
                    var sb = new StringBuilder();
                    foreach (var comp in loteContenido.ObtenerComponentes())
                        sb.AppendLine($"   • {comp.Nombre}  (${comp.ObtenerPrecio():N2})");

                    var decision = MessageBox.Show(
                        $"El lote contiene {loteContenido.ObtenerComponentes().Count} elemento(s):\n\n" +
                        sb +
                        "\n¿Desea ELIMINAR también todo el contenido?\n\n" +
                        "   Sí      → elimina el lote y todos sus elementos permanentemente\n" +
                        "   No      → elimina solo el lote; los elementos quedan libres en el inventario\n" +
                        "   Cancelar → no realiza ninguna acción",
                        "¿Qué hacer con el contenido?",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (decision == DialogResult.Cancel) return;

                    if (decision == DialogResult.Yes)
                        _bll.EliminarLoteConContenido(_loteSeleccionado.Id);
                    else
                        _bll.EliminarLoteSinContenido(_loteSeleccionado.Id);
                }
                else
                {
                    _bll.EliminarUnidad(_loteSeleccionado.Id);
                }

                LimpiarFormulario();
                CargarLotes();
                CargarComponentesDisponibles();
                MostrarExito("Lote eliminado correctamente.");
            }
            catch (Exception ex) { MostrarError("Error al eliminar lote", ex); }
        }

        private void btnAgregarComp_Click(object sender, EventArgs e)
        {
            if (_loteSeleccionado == null)
            { MostrarAviso("Primero seleccione un lote de la lista."); return; }
            if (!(cmbComponentes.SelectedItem is UnidadDeVenta udv)) return;
            if (udv.Id == _loteSeleccionado.Id)
            { MostrarAviso("Un lote no puede contenerse a sí mismo."); return; }
            try
            {
                int lotePadreActual = _bll.ObtenerLotePadreDeComponente(udv.Id);
                if (lotePadreActual == _loteSeleccionado.Id)
                { MostrarAviso($"'{udv.Nombre}' ya pertenece a este lote."); return; }

                if (lotePadreActual != 0)
                {
                    UnidadDeVenta loteActual = _bll.ObtenerPorId(lotePadreActual);
                    string nombreActual = loteActual?.Nombre ?? $"#{lotePadreActual}";
                    var respuesta = MessageBox.Show(
                        $"'{udv.Nombre}' ya pertenece al lote '{nombreActual}'.\n\n" +
                        $"¿Desea moverlo a '{_loteSeleccionado.Nombre}'?",
                        "Componente ya asignado",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta != DialogResult.Yes) return;
                    _bll.MoverComponente(lotePadreActual, _loteSeleccionado.Id, udv.Id);
                    RefrescarArbolLote(_loteSeleccionado.Id);
                    MostrarExito($"'{udv.Nombre}' movido correctamente a '{_loteSeleccionado.Nombre}'.");
                }
                else
                {
                    _bll.AgregarComponente(_loteSeleccionado.Id, udv.Id);
                    RefrescarArbolLote(_loteSeleccionado.Id);
                    MostrarExito($"'{udv.Nombre}' agregado al lote.");
                }
            }
            catch (Exception ex) { MostrarError("Error al agregar componente", ex); }
        }

        private void btnQuitarComp_Click(object sender, EventArgs e)
        {
            if (_loteSeleccionado == null || trvLote.SelectedNode == null) return;
            if (trvLote.SelectedNode.Tag is UnidadDeVenta comp && comp.Id != _loteSeleccionado.Id)
            {
                try
                {
                    _bll.QuitarComponente(_loteSeleccionado.Id, comp.Id);
                    RefrescarArbolLote(_loteSeleccionado.Id);
                }
                catch (Exception ex) { MostrarError("Error al quitar componente", ex); }
            }
        }

        private void LimpiarFormulario()
        {
            _loteSeleccionado = null;
            txtNombreLote.Clear();
            txtDescLote.Clear();
            trvLote.Nodes.Clear();
            lblPrecioLote.Text = "";
            btnActualizar.Enabled = false;
            btnEliminarLote.Enabled = false;
            lstLotes.ClearSelected();
        }

        private void MostrarExito(string msg) =>
            MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void MostrarAviso(string msg) =>
            MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarError(string ctx, Exception ex) =>
            MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}