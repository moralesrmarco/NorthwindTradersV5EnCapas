using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptClientesyProveedoresDirectorioxPais : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        ClienteBLL _clienteBLL;

        public FrmRptClientesyProveedoresDirectorioxPais()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _clienteBLL = new ClienteBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptClientesyProveedoresDirectorioxPais_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptClientesyProveedoresDirectorioxPais_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
        }

        void LlenarComboBox()
        {
            try
            {
                var datos = _clienteBLL.ObtenerPaisVwCliProvCbo();
                comboBox.DataSource = datos;
                comboBox.DisplayMember = "Key";
                comboBox.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox.SelectedIndex <= 0 | (!checkBoxClientes.Checked & !checkBoxProveedores.Checked))
                {
                    groupBox1.Text = "» Reporte directorio de clientes y proveedores por país «";
                    U.NotificacionWarning(Utils.errorCriterioSelec);
                    return;
                }
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                string titulo = string.Empty;
                if (comboBox.SelectedValue.ToString() == "aaaaa" & checkBoxClientes.Checked & checkBoxProveedores.Checked)
                    titulo = "» Reporte directorio de clientes y proveedores por país [ Todos los países ] «";
                else if (comboBox.SelectedValue.ToString() != "aaaaa" & checkBoxClientes.Checked & checkBoxProveedores.Checked)
                    titulo = $"» Reporte directorio de clientes y proveedores por país [ País: {comboBox.SelectedValue.ToString()} ] «";
                else if (comboBox.SelectedValue.ToString() == "aaaaa" & checkBoxClientes.Checked & !checkBoxProveedores.Checked)
                    titulo = "» Reporte directorio de clientes por país [ Todos los países ] «";
                else if (comboBox.SelectedValue.ToString() == "aaaaa" & !checkBoxClientes.Checked & checkBoxProveedores.Checked)
                    titulo = "» Reporte directorio de proveedores por país [ Todos los países ] «";
                else if (comboBox.SelectedValue.ToString() != "aaaaa" & checkBoxClientes.Checked & !checkBoxProveedores.Checked)
                    titulo = $"» Reporte directorio de clientes por país [ País: {comboBox.SelectedValue.ToString()} ] «";
                else if (comboBox.SelectedValue.ToString() != "aaaaa" & !checkBoxClientes.Checked & checkBoxProveedores.Checked)
                    titulo = $"» Reporte directorio de proveedores por país [ País: {comboBox.SelectedValue.ToString()} ] «";
                groupBox1.Text = titulo;
                string nombreDeFormulario = "FrmRptClientesyProveedoresDirectorioxPais";
                var clientesyProveedores = _clienteBLL.ObtenerClientesProveedores(nombreDeFormulario, comboBox.SelectedValue.ToString(), checkBoxClientes.Checked, checkBoxProveedores.Checked);
                // Conteos
                int totalClientes = clientesyProveedores.Count(cp => cp.Relation == "Cliente");
                int totalProveedores = clientesyProveedores.Count(cp => cp.Relation == "Proveedor");
                int total = totalClientes + totalProveedores;
                // Conteo de ciudades distintas
                int totalPaises = clientesyProveedores
                    .Select(cp => cp.Country) // ajusta al nombre real de la propiedad
                    .Where(c => !string.IsNullOrEmpty(c))
                    .Distinct()
                    .Count();
                string leyenda = string.Empty;
                if (totalClientes > 0)
                    leyenda = $"Se encontraron {totalClientes} cliente(s)";
                if (totalProveedores > 0)
                {
                    if (!string.IsNullOrEmpty(leyenda))
                        leyenda += $" y {totalProveedores} proveedor(es)";
                    else
                        leyenda = $"Se encontraron {totalProveedores} proveedor(es)";
                }
                if (totalClientes > 0 && totalProveedores > 0)
                    leyenda += $" (total: {total})";
                if (totalPaises > 0)
                {
                    if (!string.IsNullOrEmpty(leyenda))
                        leyenda += $", en {totalPaises} país(es)";
                    else
                        leyenda = $"Se encontraron registros en {totalPaises} país(es)";
                }
                if (string.IsNullOrEmpty(leyenda))
                    leyenda = "No se encontraron registros";
                MDIPrincipal.ActualizarBarraDeEstado(leyenda);
                reportViewer1.BackColor = Color.White;
                if (clientesyProveedores.Count > 0)
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", clientesyProveedores));
                    ReportParameter rp = new ReportParameter("titulo", titulo);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                    reportViewer1.RefreshReport();
                }
                else
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", new DataTable());
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer1.LocalReport.Refresh();
                    reportViewer1.RefreshReport();
                    U.NotificacionWarning(Utils.noDatos);
                }
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
