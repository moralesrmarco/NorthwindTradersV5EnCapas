using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmRptClientes : Form
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        ClienteBLL _clienteBLL;

        public FrmRptClientes()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _clienteBLL = new ClienteBLL(_connectionString);
        }

        private void GrbPain(object sender, PaintEventArgs e) => Utils.GrbPaint2(this, sender, e);

        private void FrmRptClientes_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmRptClientes_Load(object sender, EventArgs e)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var resultado = _clienteBLL.ObtenerClientes(false, null, true);
                MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {resultado.clientes.Count} registro(s)");
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", resultado.clientes));
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }
    }
}
