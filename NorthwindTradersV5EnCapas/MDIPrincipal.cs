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
            TabControlPrincipal.ConfigurarIconos(Properties.Resources.pestanaOff, Properties.Resources.pestanaOn);
            Instance = this;
            this.Text = Utils.nwtr;
            // Suscribirse al evento de Utils
            Utils.FormularioAgregado += (form) =>
            {
                ActualizarBarraDeEstado();
            };
        }

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Utils.CerrarTodasLasPestañas(TabControlPrincipal);
        }

        private void mantenimientoDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleadosCrud frm = new FrmEmpleadosCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de empleados «");
        }

        private void frmEjemploUsoJerarquiaClaseEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void listadoDeCategoríasConProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoriasConProductosListado frm = new FrmCategoriasConProductosListado();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Listado de categorías con productos «");
        }

        private void reporteDeCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptCategorias frm = new FrmRptCategorias();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de categorías «");
        }

        private void reporteDeCategoríasConProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptCategoriasConProductos frm = new FrmRptCategoriasConProductos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de categorías con productos «");
        }

        private void mantenimientoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductosCrud frm = new FrmProductosCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de productos «");
        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductosListado frm = new FrmProductosListado();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Listado de productos «");
        }

        private void consultaDeProductosPorCategoríaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCategoriasProductos frm = new FrmCategoriasProductos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Consulta de productos por categoría «");
        }

        private void consultaDeProductosPorProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProveedoresProductos frm = new FrmProveedoresProductos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Consulta de productos por proveedor «");
        }

        private void consultaAlfabéticaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductosConsultaAlfabetica frm = new FrmProductosConsultaAlfabetica();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Consulta alfabética de productos «");
        }

        private void listadoDeCategoríasConProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCategoriasConProductosListado frm = new FrmCategoriasConProductosListado();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Listado de categorías con productos «");
        }

        private void productosPorEncimaDelPrecioPromedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductosPorEncimaPrecioPromedio frm = new FrmProductosPorEncimaPrecioPromedio();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Productos por encima del precio promedio «");
        }

        private void reporteDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptProductos frm = new FrmRptProductos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de productos «");
        }

        private void reporteAlfabéticoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptProductosAlfabetico frm = new FrmRptProductosAlfabetico();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de productos en orden alfabético «");
        }

        private void reporteDeProductosPorProveedorConDetalleDelProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRptProdPorProvConDetProv frm = new FrmRptProdPorProvConDetProv();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de productos por proveedor con detalle del proveedor «");
        }

        private void reporteDeCategoríasConProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRptCategoriasConProductos frm = new FrmRptCategoriasConProductos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de categorías con productos «");
        }

        private void reporteDeProductosPorProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRptProductosPorProveedor frm = new FrmRptProductosPorProveedor();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de productos por proveedor «");
        }

        private void mantenimientoDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentasCrud frm = new FrmVentasCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de ventas «");
        }

        private void mantenimientoDeDetalleDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentasDetalleCrud frm = new FrmVentasDetalleCrud();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de detalle de ventas «");
        }

        private void mantenimientoDeVentasV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentasCrudV2 frm = new FrmVentasCrudV2();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Mantenimiento de ventas Ver. 2 «");
        }

        private void reporteDeVentasPorRangoDeFechaDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptVentasPorRangoFechaVenta frm = new FrmRptVentasPorRangoFechaVenta();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de ventas por rango de fecha de venta «");
        }

        private void reporteDeVentasPorDiferentesCriteriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRptVentasPorDiferentesCriterios frm = new FrmRptVentasPorDiferentesCriterios();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Reporte de ventas por diferentes criterios «");
        }

        private void ventasMensualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficaVentasMensuales frm = new FrmGraficaVentasMensuales();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Gráfica de ventas mensuales «");
        }

        private void comparativoDeVentasAnualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficaVentasAnuales frm = new FrmGraficaVentasAnuales();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Gráfica comparativa de ventas anuales «");
        }

        private void topProductosMásVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficaTopProductosMasVendidos frm = new FrmGraficaTopProductosMasVendidos();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Gráfica de top productos más vendidos «");
        }

        private void ventasPorVendedoresDeTodosLosAñosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficaVentasPorVendedores frm = new FrmGraficaVentasPorVendedores();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Gráfica de ventas por vendedores de todos los años «");
        }

        private void ventasPorVendedoresPorAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficaDeVentasDeVendedoresPorAnio frm = new FrmGraficaDeVentasDeVendedoresPorAnio();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Gráfica de ventas por vendedores por año «");
        }

        private void ventasMensualesPorVendedorPorAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficaVentasMensualesPorVendedorPorAnio frm = new FrmGraficaVentasMensualesPorVendedorPorAnio();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Gráfica comparativa de ventas mensuales por vendedores por año «");
        }

        private void ventasMensualesPorVendedorPorAñobarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficaVentasMensualesPorVendedorPorAnioBarras frm = new FrmGraficaVentasMensualesPorVendedorPorAnioBarras();
            Utils.AgregarFormularioEnTab(TabControlPrincipal, frm, "» Gráfica comparativo de ventas mensuales por vendedores por año (barras) «");
        }

        private void ventasMensualesPorVendedorPorAñobarras2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
