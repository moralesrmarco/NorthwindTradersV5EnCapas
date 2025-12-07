using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptProveedores : Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        ProveedorBLL _proveedorBLL;

        public FrmRptProveedores()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _proveedorBLL = new ProveedorBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptProveedores_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var proveedores = _proveedorBLL.ObtenerProveedores(false, null, true);
                MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {proveedores.Count} registro(s)");
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", proveedores));
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
