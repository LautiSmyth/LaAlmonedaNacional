using BE;
using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormReporte : Form
    {
        private readonly SubastaBLL _subastaBLL = new SubastaBLL();
        private readonly UnidadDeVentaBLL _udvBLL = new UnidadDeVentaBLL();

        public FormReporte()
        {
            InitializeComponent();
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                trvCatalogo.Nodes.Clear();
                var catalogo = _udvBLL.ObtenerCatalogo();
                foreach (var udv in catalogo)
                {
                    if (udv is Lote lote)
                        trvCatalogo.Nodes.Add(CrearNodoLote(lote));
                    else if (udv is Articulo art)
                        trvCatalogo.Nodes.Add(new TreeNode($"[Artículo] {art.Nombre}  (${art.PrecioBase:N2})")
                        { ForeColor = Color.DarkGreen });
                }
                trvCatalogo.ExpandAll();

                DataTable historial = _subastaBLL.ObtenerHistorial();
                dgvHistorial.DataSource = null;
                dgvHistorial.DataSource = historial;

                if (dgvHistorial.Columns.Count > 0)
                {
                    dgvHistorial.Columns["Id"].HeaderText = "ID";
                    dgvHistorial.Columns["Id"].Width = 45;
                    dgvHistorial.Columns["NombreItem"].HeaderText = "Ítem subastado";
                    dgvHistorial.Columns["NombreItem"].Width = 200;
                    dgvHistorial.Columns["PrecioFinal"].HeaderText = "Precio Final ($)";
                    dgvHistorial.Columns["PrecioFinal"].Width = 130;
                    dgvHistorial.Columns["PrecioFinal"].DefaultCellStyle.Format = "N2";
                    dgvHistorial.Columns["PrecioFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvHistorial.Columns["NombreGanador"].HeaderText = "Ganador";
                    dgvHistorial.Columns["NombreGanador"].Width = 160;
                    dgvHistorial.Columns["EmailGanador"].HeaderText = "Email";
                    dgvHistorial.Columns["EmailGanador"].Width = 170;
                    dgvHistorial.Columns["FechaHora"].HeaderText = "Fecha / Hora";
                    dgvHistorial.Columns["FechaHora"].Width = 130;
                    dgvHistorial.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                decimal total = 0;
                foreach (DataRow fila in historial.Rows)
                    total += Convert.ToDecimal(fila["PrecioFinal"]);
                lblTotalJornada.Text = $"Total recaudado en la jornada:  ${total:N2}";
            }
            catch (Exception ex) { MostrarError("Error al cargar reporte", ex); }
        }

        private TreeNode CrearNodoLote(Lote lote)
        {
            var nodo = new TreeNode($"[Lote] {lote.Nombre}  (${lote.ObtenerPrecio():N2})")
            { ForeColor = Color.FromArgb(26, 58, 92) };
            foreach (var comp in lote.ObtenerComponentes())
            {
                if (comp is Lote sub)
                    nodo.Nodes.Add(CrearNodoLote(sub));
                else if (comp is Articulo art)
                    nodo.Nodes.Add(new TreeNode($"[Artículo] {art.Nombre}  (${art.PrecioBase:N2})")
                    { ForeColor = Color.DarkGreen });
            }
            return nodo;
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CargarReporte();

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("LA ALMONEDA NACIONAL – REPORTE DE JORNADA");
                sb.AppendLine($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine(new string('=', 60));
                sb.AppendLine();
                sb.AppendLine("CATÁLOGO COMPLETO:");
                foreach (var udv in _udvBLL.ObtenerCatalogo())
                    sb.AppendLine(udv.ObtenerDetalles());
                sb.AppendLine();
                sb.AppendLine("HISTORIAL DE SUBASTAS:");
                DataTable historial = _subastaBLL.ObtenerHistorial();
                foreach (DataRow fila in historial.Rows)
                    sb.AppendLine($"  {fila["NombreItem"]} → ${fila["PrecioFinal"]:N2} | " +
                                  $"Ganador: {fila["NombreGanador"]} | {fila["FechaHora"]}");
                sb.AppendLine();
                sb.AppendLine(lblTotalJornada.Text);

                string ruta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Reporte_Almoneda_{DateTime.Now:yyyyMMdd_HHmm}.txt");
                File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
                MessageBox.Show($"Reporte exportado a:\n{ruta}", "Exportación exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MostrarError("Error al exportar", ex); }
        }

        private void MostrarError(string ctx, Exception ex) =>
            MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}