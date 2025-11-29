using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptProductosPorProveedor : Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        ProductoBLL _productoBLL;

        public FrmRptProductosPorProveedor()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _productoBLL = new ProductoBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptProductosPorProveedor_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptProductosPorProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var productosPorProveedor = _productoBLL.ObtenerProductosPorProveedor();
                MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {productosPorProveedor.Count} registros");
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", productosPorProveedor));
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
