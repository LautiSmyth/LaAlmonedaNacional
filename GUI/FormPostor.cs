using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPostor : Form
    {
        private readonly PostorBLL _bll = new PostorBLL();
        private Postor _postorSeleccionado = null;
        private bool _actualizando = false;

        public FormPostor()
        {
            InitializeComponent();
            AplicarEstilo();
            ConfigurarLimitesEntrada();
            CargarGrilla();
        }

        private void AplicarEstilo()
        {
            dgvPostores.ColumnHeadersDefaultCellStyle.BackColor = Estilo.Header;
            dgvPostores.ColumnHeadersDefaultCellStyle.ForeColor = Estilo.Gold;
            dgvPostores.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvPostores.AlternatingRowsDefaultCellStyle.BackColor = Estilo.RowAlt;
            dgvPostores.DefaultCellStyle.SelectionBackColor = Estilo.Gold;
            dgvPostores.DefaultCellStyle.SelectionForeColor = Estilo.Header;
        }

        private void ConfigurarLimitesEntrada()
        {
            txtNombre.MaxLength = 200;
            txtEmail.MaxLength = 200;
            txtTelefono.MaxLength = 50;

            txtEmail.KeyPress += txtEmail_KeyPress;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valido = char.IsDigit(e.KeyChar)
                       || e.KeyChar == '+'
                       || e.KeyChar == '-'
                       || e.KeyChar == '('
                       || e.KeyChar == ')'
                       || e.KeyChar == ' '
                       || e.KeyChar == (char)Keys.Back;
            if (!valido) e.Handled = true;
        }

        private void CargarGrilla()
        {
            try
            {
                _actualizando = true;
                dgvPostores.DataSource = null;
                dgvPostores.DataSource = _bll.ObtenerTodos();
                if (dgvPostores.Columns.Count > 0)
                {
                    dgvPostores.Columns["Id"].HeaderText = "ID";
                    dgvPostores.Columns["Id"].Width = 50;
                    dgvPostores.Columns["NombrePostor"].HeaderText = "Nombre";
                    dgvPostores.Columns["NombrePostor"].Width = 200;
                    dgvPostores.Columns["Email"].HeaderText = "Email";
                    dgvPostores.Columns["Email"].Width = 200;
                    dgvPostores.Columns["Telefono"].HeaderText = "Teléfono";
                    dgvPostores.Columns["Telefono"].Width = 130;
                    if (dgvPostores.Columns.Contains("OnNotificacion"))
                        dgvPostores.Columns["OnNotificacion"].Visible = false;
                }
                dgvPostores.ClearSelection();
            }
            catch (Exception ex) { MostrarError("Error al cargar postores", ex); }
            finally { _actualizando = false; }
        }

        private void dgvPostores_SelectionChanged(object sender, EventArgs e)
        {
            if (_actualizando) return;
            if (dgvPostores.CurrentRow?.DataBoundItem is Postor p)
            {
                _postorSeleccionado = p;
                txtNombre.Text = p.NombrePostor;
                txtEmail.Text = p.Email;
                txtTelefono.Text = p.Telefono;
                btnGuardar.Text = "Actualizar";
                btnEliminar.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                if (_postorSeleccionado == null)
                {
                    _bll.RegistrarPostor(txtNombre.Text.Trim(), txtEmail.Text.Trim(), txtTelefono.Text.Trim());
                    MostrarExito("Postor registrado correctamente.");
                }
                else
                {
                    _postorSeleccionado = new Postor(
                        _postorSeleccionado.Id,
                        txtNombre.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtTelefono.Text.Trim());
                    _bll.ActualizarPostor(_postorSeleccionado);
                    MostrarExito("Postor actualizado correctamente.");
                }
                LimpiarFormulario();
                CargarGrilla();
            }
            catch (Exception ex) { MostrarError("Error al guardar postor", ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_postorSeleccionado == null) return;
            if (MessageBox.Show($"¿Eliminar al postor '{_postorSeleccionado.NombrePostor}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _bll.EliminarPostor(_postorSeleccionado.Id);
                LimpiarFormulario();
                CargarGrilla();
                MostrarExito("Postor eliminado.");
            }
            catch (Exception ex) { MostrarError("Error al eliminar postor", ex); }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MostrarAviso("El nombre es obligatorio."); txtNombre.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            { MostrarAviso("El email es obligatorio."); txtEmail.Focus(); return false; }
            return true;
        }

        private void LimpiarFormulario()
        {
            _actualizando = true;
            _postorSeleccionado = null;
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            dgvPostores.ClearSelection();
            _actualizando = false;
        }

        private void MostrarExito(string msg) =>
            MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void MostrarAviso(string msg) =>
            MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarError(string ctx, Exception ex) =>
            MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}