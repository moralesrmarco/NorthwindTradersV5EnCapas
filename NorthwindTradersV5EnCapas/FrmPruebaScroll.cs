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
    public partial class FrmPruebaScroll : Form
    {

        private Panel panelPrincipal;

        //public FrmPruebaScroll()
        //{
        //    InitializeComponent();
        //}

        public FrmPruebaScroll()
        {
            this.Text = "Prueba Scroll en Panel";
            this.Size = new Size(400, 300);

            // Crear el panel
            panelPrincipal = new Panel();
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.AutoScroll = true; // Activar scroll automático

            // Agregar el panel al formulario
            this.Controls.Add(panelPrincipal);

            // Crear varios controles para que excedan la altura
            for (int i = 0; i < 50; i++)
            {
                TextBox txt = new TextBox();
                txt.Text = $"Caja {i + 1}";
                txt.Location = new Point(20, 30 * i); // cada caja más abajo
                txt.Width = 200;
                panelPrincipal.Controls.Add(txt);
            }
        }

    }
}
