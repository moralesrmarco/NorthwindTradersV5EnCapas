using System.Windows.Forms;

namespace NorthwindTradersV5EnCapas
{
    public partial class ControlDetalleDeLaVenta : UserControl
    {
        // Propiedad pública para acceder al DataGridView interno
        public DataGridView DgvDetalle => dgvDetalle;

        public ControlDetalleDeLaVenta()
        {
            InitializeComponent();
        }

    }
}
