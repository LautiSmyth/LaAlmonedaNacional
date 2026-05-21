using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormArticulo : Form
    {
        private readonly UnidadDeVentaBLL _bll = new UnidadDeVentaBLL();
        private Articulo _articuloSeleccionado = null;
        private bool _actualizando = false;

        public FormArticulo()
        {
            InitializeComponent();
            AplicarEstilo();
            CargarGrilla();
        }

        private void AplicarEstilo()
        {
            dgvArticulos.ColumnHeadersDefaultCellStyle.BackColor = Estilo.Header;
            dgvArticulos.ColumnHeadersDefaultCellStyle.ForeColor = Estilo.Gold;
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvArticulos.AlternatingRowsDefaultCellStyle.BackColor = Estilo.RowAlt;
            dgvArticulos.DefaultCellStyle.SelectionBackColor = Estilo.Gold;
            dgvArticulos.DefaultCellStyle.SelectionForeColor = Estilo.Header;
        }

        private void CargarGrilla()
        {
            try
            {
                _actualizando = true;
                dgvArticulos.DataSource = null;
                var lista = _bll.ObtenerArticulos();
                dgvArticulos.DataSource = lista;
                if (dgvArticulos.Columns.Count > 0)
                {
                    dgvArticulos.Columns["Id"].HeaderText = "ID";
                    dgvArticulos.Columns["Id"].Width = 50;
                    dgvArticulos.Columns["Nombre"].HeaderText = "Nombre";
                    dgvArticulos.Columns["Nombre"].Width = 180;
                    dgvArticulos.Columns["Descripcion"].HeaderText = "Descripción";
                    dgvArticulos.Columns["Descripcion"].Width = 220;
                    dgvArticulos.Columns["PrecioBase"].HeaderText = "Precio Base ($)";
                    dgvArticulos.Columns["PrecioBase"].Width = 120;
                    dgvArticulos.Columns["PrecioBase"].DefaultCellStyle.Format = "N2";
                    dgvArticulos.Columns["PrecioBase"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }
                dgvArticulos.ClearSelection();
            }
            catch (Exception ex) { MostrarError("Error al cargar artículos", ex); }
            finally { _actualizando = false; }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (_actualizando) return;
            if (dgvArticulos.CurrentRow?.DataBoundItem is Articulo art)
            {
                _articuloSeleccionado = art;
                txtNombre.Text = art.Nombre;
                txtDescripcion.Text = art.Descripcion;
                txtPrecio.Text = art.PrecioBase.ToString("N2");
                btnGuardar.Text = "Actualizar";
                btnEliminar.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                decimal precio = decimal.Parse(txtPrecio.Text.Trim());
                if (_articuloSeleccionado == null)
                {
                    _bll.CrearArticulo(nombre, descripcion, precio);
                    MostrarExito("Artículo creado correctamente.");
                }
                else
                {
                    _articuloSeleccionado.Nombre = nombre;
                    _articuloSeleccionado.Descripcion = descripcion;
                    _articuloSeleccionado.PrecioBase = precio;
                    _bll.ActualizarArticulo(_articuloSeleccionado);
                    MostrarExito("Artículo actualizado correctamente.");
                }
                LimpiarFormulario();
                CargarGrilla();
            }
            catch (Exception ex) { MostrarError("Error al guardar artículo", ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_articuloSeleccionado == null) return;
            if (MessageBox.Show(
                $"¿Eliminar el artículo '{_articuloSeleccionado.Nombre}'?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _bll.EliminarUnidad(_articuloSeleccionado.Id);
                LimpiarFormulario();
                CargarGrilla();
                MostrarExito("Artículo eliminado.");
            }
            catch (Exception ex) { MostrarError("Error al eliminar artículo", ex); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscar.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(filtro)) { CargarGrilla(); return; }
                _actualizando = true;
                var todos = _bll.ObtenerArticulos();
                dgvArticulos.DataSource = todos.FindAll(a =>
                    a.Nombre.ToLower().Contains(filtro) ||
                    a.Descripcion.ToLower().Contains(filtro));
                dgvArticulos.ClearSelection();
            }
            catch { }
            finally { _actualizando = false; }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MostrarAviso("El nombre es obligatorio."); txtNombre.Focus(); return false; }
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
            { MostrarAviso("Ingrese un precio base numérico válido (≥ 0)."); txtPrecio.Focus(); return false; }
            return true;
        }

        private void LimpiarFormulario()
        {
            _actualizando = true;
            _articuloSeleccionado = null;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            dgvArticulos.ClearSelection();
            _actualizando = false;
            txtNombre.Focus();
        }

        private void MostrarExito(string msg) =>
            MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void MostrarAviso(string msg) =>
            MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MostrarError(string ctx, Exception ex) =>
            MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
