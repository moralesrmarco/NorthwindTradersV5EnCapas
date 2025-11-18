using BLL;
using Entities.DTOs;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmEmpleadosCrud : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Northwind2ConnectionString"].ConnectionString;
        private EmployeeBLL employeeBLL;
        // si es true significa que realizara busqueda con los criterios proporcionados 
        // si es false significa que obtendra los ultimos 20 registros y no hay criterios
        private bool EjecutarConfDgv = true; 

        public FrmEmpleadosCrud()
        {
            InitializeComponent();
            employeeBLL = new EmployeeBLL(connectionString);
        }

        private void FrmEmpleadosCrud_Load(object sender, EventArgs e)
        {
            tabcOperacion.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcOperacion.DrawItem += tabcOperacion_DrawItem;
            panel1.AutoScrollMinSize = new Size(1000, 800);
            DeshabilitarControles();
            Utils.ConfDgv(dgv);
            LlenarDgv(false);
        }

        private void tabcOperacion_DrawItem(object sender, DrawItemEventArgs e) => Utils.DibujarPestañas(sender as TabControl, e);

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint(this, sender, e);

        private void FrmEmpleadosCrud_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmEmpleadosCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            // por mientras, sino borrar
        }

        private void DeshabilitarControles()
        {
            txtNombres.ReadOnly = txtApellidos.ReadOnly = txtTitulo.ReadOnly = txtTitCortesia.ReadOnly = true;
            txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCodigoP.ReadOnly = true;
            txtPais.ReadOnly = txtTelefono.ReadOnly = txtExtension.ReadOnly = true;
            dtpFNacimiento.Enabled = dtpFContratacion.Enabled = false;
            txtNotas.ReadOnly = false;
            cboReportaA.Enabled = false;
            picFoto.Enabled = false;
            btnCargar.Enabled = false;
        }

        private void HabiliarControles()
        {
            txtNombres.ReadOnly = txtApellidos.ReadOnly = txtTitulo.ReadOnly = false;
            txtTitCortesia.ReadOnly = false;
            txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCodigoP.ReadOnly = false;
            txtPais.ReadOnly = txtTelefono.ReadOnly = txtExtension.ReadOnly = false;
            txtNotas.ReadOnly = false;
            dtpFNacimiento.Enabled = dtpFContratacion.Enabled = cboReportaA.Enabled = true;
            picFoto.Enabled = true;
        }

        private void LlenarDgv(bool selectorRealizaBusqueda)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                DtoEmpleadosBuscar dtoEmpleadoBuscar = null;
                var empleados = employeeBLL.ObtenerEmpleados(selectorRealizaBusqueda, dtoEmpleadoBuscar);
                dgv.DataSource = empleados;
                if (EjecutarConfDgv)
                {
                    ConfDgv();
                    EjecutarConfDgv = false;
                }
                if (selectorRealizaBusqueda)
                    MDIPrincipal.ActualizarBarraDeEstado($"Se muestran los últimos {dgv.RowCount} empleados registrados");
                else
                    MDIPrincipal.ActualizarBarraDeEstado($"Se encontraron {dgv.RowCount} registros");
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        void ConfDgv()
        {
            dgv.Columns["EmployeeID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["BirthDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["City"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Country"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["ReportsToName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv.Columns["Photo"].Width = 20;
            dgv.Columns["Photo"].DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);
            ((DataGridViewImageColumn)dgv.Columns["Photo"]).ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgv.Columns["Title"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["BirthDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["City"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Country"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["ReportsToName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["BirthDate"].DefaultCellStyle.Format = "dd \" de \"MMM\" de \"yyyy";

            dgv.Columns["EmployeeID"].HeaderText = "Id";
            dgv.Columns["FirstName"].HeaderText = "Nombres";
            dgv.Columns["LastName"].HeaderText = "Apellidos";
            dgv.Columns["Title"].HeaderText = "Título";
            dgv.Columns["BirthDate"].HeaderText = "Fecha de nacimiento";
            dgv.Columns["City"].HeaderText = "Ciudad";
            dgv.Columns["Country"].HeaderText = "País";
            dgv.Columns["Photo"].HeaderText = "Foto";
            dgv.Columns["ReportsToName"].HeaderText = "Reporta a";
        }

    }
}
