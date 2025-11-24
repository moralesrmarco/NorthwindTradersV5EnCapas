using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptEmpleadosConFoto : Form
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private EmpleadoBLL _empleadoBLL;

        public FrmRptEmpleadosConFoto()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _empleadoBLL = new EmpleadoBLL(_connectionString);
        }

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptEmpleadosConFoto_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptEmpleadosConFoto_Load(object sender, EventArgs e)
        {
            try
            {
                //MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                //var ds = new DataSet();
                //string cnStr = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindMySql"].ConnectionString;
                //using (var cn = new MySql.Data.MySqlClient.MySqlConnection(cnStr))
                //using (var da = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT e1.*, e2.FirstName As ReportsToFirstName, e2.LastName As ReportsToLastName, IFNULL(CONCAT(e2.LastName, ', ', e2.FirstName), 'N/A') AS ReportsToName FROM Employees As e1 Left Join Employees As e2 On e1.ReportsTo = e2.EmployeeID", cn))
                //    da.Fill(ds, "Employees");
                //// Quitar encabezado OLE a Photo en el Datatable
                //var table = ds.Tables["Employees"];
                //foreach (DataRow row in table.Rows)
                //{
                //    if (Convert.ToInt32(row["EmployeeId"]) < 9)
                //    {
                //        if (row["Photo"] != DBNull.Value)
                //        {
                //            byte[] photoData = (byte[])row["Photo"];
                //            if (photoData.Length > 78) // Asegurarse de que hay suficientes bytes para quitar el encabezado OLE
                //            {
                //                byte[] cleanedPhotoData = new byte[photoData.Length - 78];
                //                Array.Copy(photoData, 78, cleanedPhotoData, 0, cleanedPhotoData.Length);
                //                row["Photo"] = cleanedPhotoData;
                //            }
                //            else
                //            {
                //                row["Photo"] = DBNull.Value; // Si no hay suficientes bytes, establecer como nulo
                //            }
                //        }
                //    }
                //}
                //MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {ds.Tables["Employees"].Rows.Count} registros");
                //var rds = new ReportDataSource("DataSet1", ds.Tables["Employees"]);
                //reportViewer1.LocalReport.DataSources.Clear();
                //reportViewer1.LocalReport.DataSources.Add(rds);
                //reportViewer1.RefreshReport();
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var empleados = _empleadoBLL.ObtenerTodosLosEmpleados();
                MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {empleados.Count} registros");
                var rds = new ReportDataSource("DataSet1", empleados);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
