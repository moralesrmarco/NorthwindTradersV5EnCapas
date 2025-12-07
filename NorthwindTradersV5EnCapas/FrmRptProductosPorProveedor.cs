using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Linq;
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
                // Conteos
                int totalProveedores = productosPorProveedor
                            .Select(p => p.CompanyName) // ajusta al nombre real de la propiedad
                            .Distinct()
                            .Count();
                int totalProductos = productosPorProveedor
                    .Where(p => !string.Equals(p.ProductName, "Sin producto", StringComparison.OrdinalIgnoreCase)) // excluye los productos ficticios "Sin producto" que aparecen en el reporte cuando un proveedor no tiene productos
                    .Select(p => new { p.ProductID, p.ProductName }) // cuenta por combinación Id + nombre para considerar los productos con el mismo nombre pero diferente Id
                    .Distinct()
                    .Count();
                string leyenda = $"Se encontraron {totalProveedores} proveedor(es) y {totalProductos} producto(s)";
                MDIPrincipal.ActualizarBarraDeEstado(leyenda);
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
