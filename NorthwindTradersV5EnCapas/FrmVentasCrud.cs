using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindTradersV5EnCapas
{
    public partial class FrmVentasCrud : Form
    {
        public FrmVentasCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void FrmVentasCrud_Load(object sender, EventArgs e)
        {
            grbProducto.Visible = true;
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.PerformLayout();
        }
    }
}
