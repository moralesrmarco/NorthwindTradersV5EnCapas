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
        private EmpleadoBLL employeeBLL;
        // si es true significa que realizara busqueda con los criterios proporcionados 
        // si es false significa que obtendra los ultimos 20 registros y no hay criterios
        private bool EjecutarConfDgv = true; 

        public FrmEmpleadosCrud()
        {
            InitializeComponent();
            employeeBLL = new EmpleadoBLL(connectionString);
        }

        private void FrmEmpleadosCrud_Load(object sender, EventArgs e)
        {
            tabcOperacion.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcOperacion.DrawItem += tabcOperacion_DrawItem;
            panel1.AutoScrollMinSize = new Size(1000, 800);
            DeshabilitarControles();
            LlenarCboPais();
            LlenarCboReportaA();
            Utils.ConfDgv(dgv);
            LlenarDgv(false);
        }

        private void tabcOperacion_DrawItem(object sender, DrawItemEventArgs e) => Utils.DibujarPestañas(sender as TabControl, e);

        private void GrbPaint(object sender, PaintEventArgs e) => Utils.GrbPaint(this, sender, e);

        private void FrmEmpleadosCrud_FormClosed(object sender, FormClosedEventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void FrmEmpleadosCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpListar)
                if (txtId.Text.Trim() != "" || txtNombres.Text.Trim() != "" || txtApellidos.Text.Trim() != "" || txtTitulo.Text.Trim() != "" || txtTitCortesia.Text.Trim() != "" || txtDomicilio.Text.Trim() != "" || txtCiudad.Text.Trim() != "" || txtRegion.Text.Trim() != "" || txtCodigoP.Text.Trim() != "" || txtPais.Text.Trim() != "" || txtTelefono.Text.Trim() != "" || txtExtension.Text.Trim() != "" || dtpFNacimiento.Value != dtpFNacimiento.MinDate || dtpFContratacion.Value != dtpFContratacion.MinDate || txtNotas.Text.Trim() != "" || cboReportaA.SelectedIndex > 0)
                {
                    if (Utils.MsgCerrarForm() == DialogResult.No)
                        e.Cancel = true;
                }
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
            //btnCargar.Enabled = true;  // no se debe habilitar este control para los registros 1 al 8
        }

        private void LlenarCboPais()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var paises = employeeBLL.ObtenerEmpleadosPaisesCbo();
                cboBPais.DataSource = paises;
                cboBPais.ValueMember = "Id";
                cboBPais.DisplayMember = "Pais";
                cboBPais.SelectedIndex = 0;
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void LlenarCboReportaA()
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                var empleados = employeeBLL.ObtenerEmpleadosReportaaCbo();
                cboReportaA.DataSource = empleados;
                cboReportaA.ValueMember = "Id";
                cboReportaA.DisplayMember = "Nombre";
                cboReportaA.SelectedIndex = 0;
                MDIPrincipal.ActualizarBarraDeEstado();
            }
            catch (Exception ex)
            {
                U.MsgCatchOue(ex);
            }
        }

        private void LlenarDgv(bool selectorRealizaBusqueda)
        {
            try
            {
                MDIPrincipal.ActualizarBarraDeEstado(Utils.clbdd);
                DtoEmpleadosBuscar dtoEmpleadosBuscar = new DtoEmpleadosBuscar
                {
                    IdIni = string.IsNullOrEmpty(txtBIdIni.Text) ? 0 : Convert.ToInt32(txtBIdIni.Text),
                    IdFin = string.IsNullOrEmpty(txtBIdFin.Text) ? 0 : Convert.ToInt32(txtBIdFin.Text),
                    Nombres = txtBNombres.Text.Trim(),
                    Apellidos = txtBApellidos.Text.Trim(),
                    Titulo = txtBTitulo.Text.Trim(),
                    Domicilio = txtBDomicilio.Text.Trim(),
                    Ciudad = txtBCiudad.Text.Trim(),
                    Region = txtBRegion.Text.Trim(),
                    CodigoP = txtBCodigoP.Text.Trim(),
                    Pais = cboBPais.SelectedValue.ToString(),
                    Telefono = txtBTelefono.Text.Trim()
                };
                var empleados = employeeBLL.ObtenerEmpleadosDgv(selectorRealizaBusqueda, dtoEmpleadosBuscar);
                dgv.DataSource = empleados;
                if (EjecutarConfDgv)
                {
                    ConfDgv();
                    EjecutarConfDgv = false;
                }
                if (!selectorRealizaBusqueda)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarDatosEmpleado();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(true);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            BorrarDatosBusqueda();
            BorrarDatosEmpleado();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(false);
        }

        void BorrarMensajesError() => errorProvider1.Clear();

        void BorrarDatosBusqueda()
        {
            txtBIdIni.Text = txtBIdFin.Text = txtBNombres.Text = txtBApellidos.Text = string.Empty;
            txtBTitulo.Text = txtBDomicilio.Text = txtBCiudad.Text = string.Empty;
            txtBRegion.Text = txtBCodigoP.Text = txtBTelefono.Text = string.Empty;
            cboBPais.SelectedIndex = 0;
        }

        void BorrarDatosEmpleado()
        {
            txtId.Text = txtNombres.Text = txtApellidos.Text = txtTitulo.Text = string.Empty;
            txtTitCortesia.Text = txtDomicilio.Text = txtCiudad.Text = string.Empty;
            txtRegion.Text = txtCodigoP.Text = txtTelefono.Text = txtPais.Text = string.Empty;
            txtExtension.Text = txtNotas.Text = string.Empty;
            cboReportaA.SelectedIndex = -1;
            picFoto.Image = Properties.Resources.FotoPerfil;
            dtpFNacimiento.Value = dtpFNacimiento.MinDate;
            dtpFContratacion.Value = dtpFContratacion.MinDate;
        }

        void txtBIdIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        void txtBIdFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        void txtBIdIni_Leave(object sender, EventArgs e)
        {
            Utils.ValidaTxtBIdIni(txtBIdIni, txtBIdFin);
        }

        void txtBIdFin_Leave(object sender, EventArgs e)
        {
            Utils.ValidaTxtBIdFin(txtBIdIni, txtBIdFin);
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (txtNombres.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtNombres, "Ingrese el nombre");
            }
            if (txtApellidos.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtApellidos, "Ingrese el apellido");
            }
            if (txtTitulo.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtTitulo, "Ingrese el título");
            }
            if (txtTitCortesia.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtTitCortesia, "Ingrese el título de cortesia");
            }
            if (txtDomicilio.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtDomicilio, "Ingrese el domicilio");
            }
            if (txtCiudad.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtCiudad, "Ingrese la ciudad");
            }
            if (txtPais.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtPais, "Ingrese el país");
            }
            if (txtTelefono.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtTelefono, "Ingrese el teléfono");
            }
            if (picFoto.Image == null)
            {
                valida = false;
                errorProvider1.SetError(btnCargar, "Ingrese la foto");
            }
            if (dtpFNacimiento.Value == new DateTime(1753, 1, 1))
            {
                valida = false;
                errorProvider1.SetError(dtpFNacimiento, "Ingrese la fecha de nacimiento");
            }
            if (dtpFContratacion.Value == new DateTime(1753, 1, 1))
            {
                valida = false;
                errorProvider1.SetError(dtpFContratacion, "Ingrese la fecha de contratación");
            }
            if (cboReportaA.SelectedValue == null || cboReportaA.SelectedValue.ToString() == "-1")
            {
                valida = false;
                errorProvider1.SetError(cboReportaA, "Seleccione a quien reporta el empleado");
            }
            return valida;
        }

    }
}
