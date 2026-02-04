using System;
using System.Windows.Forms;

namespace NorthwindTradersV5EnCapas
{
    public partial class ControlBuscarVenta : UserControl
    {
        // Propiedades públicas para acceder a los valores
        public NumericUpDown NudBIdIni => nudBIdIni;
        public NumericUpDown NudBIdFin => nudBIdFin;

        public TextBox TxtBCliente => txtBCliente;

        // Exponer directamente los DateTimePicker
        public DateTimePicker DtpFVentaIni => dtpBFVentaIni;
        public DateTimePicker DtpFVentaFin => dtpBFVentaFin;

        public DateTimePicker DtpFRequeridoIni => dtpBFRequeridoIni;
        public DateTimePicker DtpFRequeridoFin => dtpBFRequeridoFin;

        public DateTimePicker DtpFEnvioIni => dtpBFEnvioIni;
        public DateTimePicker DtpFEnvioFin => dtpBFEnvioFin;

        public CheckBox ChkbFVentaNull => chkbBFVentaNull;
        public CheckBox ChkbFRequeridoNull => chkbBFRequeridoNull;
        public CheckBox ChkbFEnvioNull => chkbBFEnvioNull;

        public TextBox TxtBEmpleado => txtBEmpleado;

        public TextBox TxtBCompañiaT => txtBCompañiaT;

        public TextBox TxtBDirigidoa => txtBDirigidoa;
        
        public ControlBuscarVenta()
        {
            InitializeComponent();
        }

    }
}
