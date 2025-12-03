using System;
using System.Drawing;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;
        public static MDIPrincipal Instance { get; private set; }

        public ToolStripStatusLabel ToolStripEstado
        {
            get { return toolStripStatus; }
            set { toolStripStatus = value; }
        }


        public MDIPrincipal()
        {
            InitializeComponent();
            TabControlPrincipal.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabControlPrincipal.DrawItem += TabControlPrincipal_DrawItem;
            Instance = this;
            this.Text = Utils.nwtr;
            // Suscribirse al evento de Utils
            Utils.FormularioAgregado += (form) =>
            {
                ActualizarBarraDeEstado();
            };
        }

        private void TabControlPrincipal_DrawItem(object sender, DrawItemEventArgs e) => Utils.DibujarPestañas(sender as TabControl, e);

        private void TabControlPrincipal_SelectedIndexChanged(object sender, EventArgs e) => MDIPrincipal.ActualizarBarraDeEstado();

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = SystemColors.GradientInactiveCaption; // el color que quieras
                }
            }
        }

        public static void ActualizarBarraDeEstado(string mensaje = "Listo.", bool error = false)
        {
            if (Instance != null && !Instance.IsDisposed)
            {
                if (mensaje != "Listo.")
                {
                    if (error)
                        Instance.ToolStripEstado.BackColor = System.Drawing.Color.Red;
                    else
                        Instance.ToolStripEstado.BackColor = SystemColors.ActiveCaption;
                }
                else
                {
                    if (error)
                    {
                        Instance.ToolStripEstado.ForeColor = System.Drawing.Color.White;
                        Instance.ToolStripEstado.Font = new Font(Instance.ToolStripEstado.Font, FontStyle.Bold);
                    }
                    else
                    {
                        Instance.ToolStripEstado.ForeColor = SystemColors.ControlText;
                        Instance.ToolStripEstado.BackColor = SystemColors.Control;
                        Instance.ToolStripEstado.Font = new Font(Instance.ToolStripEstado.Font, FontStyle.Regular);
                    }
                }
                Instance.ToolStripEstado.Text = mensaje;
                Instance.Refresh();
            }
        }

        private void CloseForms()
        {
            Utils.CloseForms(() => MDIPrincipal.ActualizarBarraDeEstado());
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void cerrarTodasLasPestañasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.CerrarTodasLasPestañas(TabControlPrincipal);
        }

        private void cerrarLaPestañaSeleccionadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.CerrarPestañaSeleccionada(TabControlPrincipal);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Utils.CerrarPestañaSeleccionada(TabControlPrincipal);
        }

        private void mantenimientoDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ActualizarBarraDeEstado();
            FrmEmpleadosCrud frm = new FrmEmpleadosCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de empleados «");
        }

        private void frmPruebaScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ActualizarBarraDeEstado();
            FrmPruebaScroll frm = new FrmPruebaScroll();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de FrmPruebaScroll «");
        }

        private void frmIconosSystemIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ActualizarBarraDeEstado();
            FrmIconosSystemIcons frm = new FrmIconosSystemIcons();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de FrmIconosSystemIcons «");
        }

        private void frmEjemploUsoJerarquiaClaseEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ActualizarBarraDeEstado();
            FrmEjemploUsoJerarquiaClaseEmpleado frm = new FrmEjemploUsoJerarquiaClaseEmpleado();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Ejemplo uso jerarquía clase Empleado «");
        }

        private void reporteDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptEmpleados frm = new FrmRptEmpleados();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de empleados «");
        }

        private void reporteDeEmpleadosConFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptEmpleadosConFoto frm = new FrmRptEmpleadosConFoto();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de empleados con foto «");
        }

        private void reporteDeEmpleadosConFoto2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptEmpleado2 frm = new FrmRptEmpleado2();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de empleados con foto 2 «");
        }

        private void mantenimientoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesCrud frm = new FrmClientesCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de clientes «");
        }

        private void directorioDeClientesYProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesyProveedoresDirectorio frm = new FrmClientesyProveedoresDirectorio();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Directorio de clientes y proveedores «");
        }

        private void directorioDeClientesYProveedoresPorCiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesyProveedoresDirectorioxCiudad frm = new FrmClientesyProveedoresDirectorioxCiudad();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Directorio de clientes y proveedores por ciudad «");
        }

        private void directorioDeClientesYProveedoresPorPaísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesyProveedoresDirectorioxPais frm = new FrmClientesyProveedoresDirectorioxPais();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Directorio de clientes y proveedores por país «");
        }

        private void directorioDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptClientes frm = new FrmRptClientes();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de clientes «");
        }

        private void directorioDeClientesYProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRptClientesyProveedoresDirectorio frm = new FrmRptClientesyProveedoresDirectorio();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de clientes y proveedores «");
        }

        private void directorioDeClientesYProveedoresPorCiudadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRptClientesyProveedoresDirectorioxCiudad frm = new FrmRptClientesyProveedoresDirectorioxCiudad();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de clientes y proveedores por ciudad «");
        }

        private void directorioDeClientesYProveedoresPorPaísToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRptClientesyProveedoresDirectorioxPais frm = new FrmRptClientesyProveedoresDirectorioxPais();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de clientes y proveedores por país «");
        }

        private void mantenimientoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedoresCrud frm = new FrmProveedoresCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de proveedores «");
        }

        private void directorioDeClientesYProveedoresToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmClientesyProveedoresDirectorio frm = new FrmClientesyProveedoresDirectorio();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Directorio de clientes y proveedores «");
        }

        private void directorioDeClientesYProveedoresPorCiudadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmClientesyProveedoresDirectorioxCiudad frm = new FrmClientesyProveedoresDirectorioxCiudad();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Directorio de clientes y proveedores por ciudad «");
        }

        private void directorioDeClientesYProveedoresPorPaísToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmClientesyProveedoresDirectorioxPais frm = new FrmClientesyProveedoresDirectorioxPais();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Directorio de clientes y proveedores por país «");
        }

        private void consultaDeProductosPorProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedoresProductos frm = new FrmProveedoresProductos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Consulta de productos por proveedor «");
        }

        private void directorioDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptProveedores frm = new FrmRptProveedores();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de proveedores «");
        }

        private void directorioDeClientesYProveedoresToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmRptClientesyProveedoresDirectorio frm = new FrmRptClientesyProveedoresDirectorio();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de clientes y proveedores «");
        }

        private void directorioDeClientesYProveedoresPorCiudadToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmRptClientesyProveedoresDirectorioxCiudad frm = new FrmRptClientesyProveedoresDirectorioxCiudad();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de clientes y proveedores por ciudad «");
        }

        private void directorioDeClientesYProveedoresPorPaísToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmRptClientesyProveedoresDirectorioxPais frm = new FrmRptClientesyProveedoresDirectorioxPais();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte directorio de clientes y proveedores por país «");
        }

        private void reporteDeProductosPorProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptProductosPorProveedor frm = new FrmRptProductosPorProveedor();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de productos por proveedor «");
        }

        private void reporteDeProductosPorProveedorConDetalleDelProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptProdPorProvConDetProv frm = new FrmRptProdPorProvConDetProv();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de productos por proveedor con detalle del proveedor «");
        }

        private void mantenimientoDeCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoriasCrud frm = new FrmCategoriasCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de categorías «");
        }

        private void consultaDeProductosPorCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoriasProductos frm = new FrmCategoriasProductos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Consulta de productos por categoría «");
        }

        private void listadoDeProductosPorCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductosPorCategoriasListado frm = new FrmProductosPorCategoriasListado();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Listado de productos por categoría «");
        }

        private void reporteDeCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptCategorias frm = new FrmRptCategorias();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de categorías «");
        }

        private void reporteDeProductosPorCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
