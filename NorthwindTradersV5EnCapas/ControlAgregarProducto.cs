using NorthwindTradersV5EnCapas.Helpers;
using System.Data;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    public partial class ControlAgregarProducto : UserControl
    {
        // Propiedades públicas para exponer los controles internos
        public ComboBox CboCategoria => cboCategoria;
        public ComboBox CboProducto => cboProducto;
        public Button BtnAgregar => btnAgregar;

        public NudNoWheel NudPrecioConIVAIncluido => nudPrecioConIVAIncluido;
        public NudNoWheel NudUInventario => nudUInventario;
        public NudNoWheel NudCantidad => nudCantidad;
        public NudNoWheel NudDescuento => nudDescuento;

        public NudNoWheel NudPrecioPorUnidadSinIVAIncluidoAntesDescuento => nudPrecioPorUnidadSinIVAIncluidoAntesDescuento;
        public NudNoWheel NudIVADelPrecioPorUnidadAntesDescuento => nudIVADelPrecioPorUnidadAntesDescuento;
        public NudNoWheel NudPrecioPorUnidadSinIVADepuesDescuento => nudPrecioPorUnidadSinIVADepuesDescuento;
        public NudNoWheel NudAhorroPorUnidadSinIVA => nudAhorroPorUnidadSinIVA;
        public NudNoWheel NudIVADelPrecioPorUnidadDespuesDescuento => nudIVADelPrecioPorUnidadDespuesDescuento;
        public NudNoWheel NudAhorroEnIVAPorUnidadDespuesDescuento => nudAhorroEnIVAPorUnidadDespuesDescuento;
        public NudNoWheel NudPrecioPorUnidadConIVADespuesDescuento => nudPrecioPorUnidadConIVADespuesDescuento;
        public NudNoWheel NudAhorroTotalPorUnidadConIVA => nudAhorroTotalPorUnidadConIVA;

        public NudNoWheel NudSubtotalDelImporteConIVAIncluido2 => nudSubtotalDelImporteConIVAIncluido2;
        public NudNoWheel NudSubtotalDelImporteSinIVASinDescuento2 => nudSubtotalDelImporteSinIVASinDescuento2;
        public NudNoWheel NudSubtotalDelImporteDelIVASinDescuento2 => nudSubtotalDelImporteDelIVASinDescuento2;
        public NudNoWheel NudSubtotalDelImporteSinIVAConDescuento2 => nudSubtotalDelImporteSinIVAConDescuento2;
        public NudNoWheel NudSubtotalIVADespuesDelDescuento2 => nudSubtotalIVADespuesDelDescuento2;
        public NudNoWheel NudSubtotalDelAhorroSinIvaDespuesDescuento2 => nudSubtotalDelAhorroSinIvaDespuesDescuento2;
        public NudNoWheel NudSubtotalDelAhorroEnIVADespuesDescuento2 => nudSubtotalDelAhorroEnIVADespuesDescuento2;
        public NudNoWheel NudSubtotalDelAhorroTotalDespuesDescuento2 => nudSubtotalDelAhorroTotalDespuesDescuento2;
        public NudNoWheel NudTotal2 => nudTotal2;

        public PictureBox PbError => pbError;
        public PictureBox PbInfo => pbInfo;
        public PictureBox PbWarning => pbWarning;

        public PictureBox PbError1 => pbError1;
        public PictureBox PbInfo1 => pbInfo1;
        public PictureBox PbWarning1 => pbWarning1;


        public ControlAgregarProducto()
        {
            InitializeComponent();
        }

        public void LlenarCboCategoria(DataTable categorias)
        {
            ComboBoxHelper.LlenarCbo(cboCategoria, categorias, "CategoryName", "CategoryID");
        }
    }
}
