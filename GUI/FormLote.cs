using BE;
using BLL;
using System;
using System.Drawing;
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
            CargarLotes();
            CargarComponentesDisponibles();
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
                cmbComponentes.DataSource = null;
                cmbComponentes.DataSource = _bll.ObtenerCatalogo();
                cmbComponentes.DisplayMember = "Nombre";
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
                { Tag = lote, ForeColor = Color.FromArgb(26, 58, 92) };
                foreach (var comp in lote.ObtenerComponentes())
                    nodo.Nodes.Add(CrearNodoArbol(comp));
                return nodo;
            }
            if (udv is Articulo art)
                return new TreeNode($"[Artículo] {art.Nombre}  (${art.PrecioBase:N2})")
                { Tag = art, ForeColor = Color.DarkGreen };
            return new TreeNode(udv.Nombre);
        }

        private void btnCrearLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreLote.Text))
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
            if (MessageBox.Show($"¿Eliminar el lote '{_loteSeleccionado.Nombre}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _bll.EliminarUnidad(_loteSeleccionado.Id);
                LimpiarFormulario();
                CargarLotes();
                CargarComponentesDisponibles();
                MostrarExito("Lote eliminado.");
            }
            catch (Exception ex) { MostrarError("Error al eliminar lote", ex); }
        }

        private void btnAgregarComp_Click(object sender, EventArgs e)
        {
            if (_loteSeleccionado == null)
            { MostrarAviso("Primero seleccione un lote de la lista."); return; }
            if (cmbComponentes.SelectedItem is UnidadDeVenta udv)
            {
                try
                {
                    _bll.AgregarComponente(_loteSeleccionado.Id, udv.Id);
                    RefrescarArbolLote(_loteSeleccionado.Id);
                    MostrarExito($"'{udv.Nombre}' agregado al lote.");
                }
                catch (Exception ex) { MostrarError("Error al agregar componente", ex); }
            }
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

        private void MostrarExito(string msg) => MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void MostrarAviso(string msg) => MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MostrarError(string ctx, Exception ex) =>
            MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
