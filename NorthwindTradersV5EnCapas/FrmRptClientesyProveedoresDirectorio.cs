using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptClientesyProveedoresDirectorio : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        ClienteBLL _clienteBLL;

        public FrmRptClientesyProveedoresDirectorio()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _clienteBLL = new ClienteBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptClientesyProveedoresDirectorio_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBoxClientes.Checked & !checkBoxProveedores.Checked)
                {
                    groupBox1.Text = "» Reporte directorio de clientes y proveedores «";
                    U.NotificacionWarning(Utils.errorCriterioSelec);
                    return;
                }
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                string titulo = string.Empty;
                if (checkBoxClientes.Checked & checkBoxProveedores.Checked)
                {
                    titulo = "» Reporte directorio de clientes y proveedores «";
                }
                else if (checkBoxClientes.Checked & !checkBoxProveedores.Checked)
                {
                    titulo = "» Reporte directorio de clientes «";
                }
                else if (!checkBoxClientes.Checked & checkBoxProveedores.Checked)
                {
                    titulo = "» Reporte directorio de proveedores «";
                }
                groupBox1.Text = titulo;
                string nombreDeFormulario = "FrmRptClientesyProveedoresDirectorio";
                var clientesyProveedores = _clienteBLL.ObtenerClientesProveedores(nombreDeFormulario, string.Empty, checkBoxClientes.Checked, checkBoxProveedores.Checked);
                MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {clientesyProveedores.Count} registros");
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", clientesyProveedores));
                ReportParameter rp = new ReportParameter("titulo", titulo);
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
