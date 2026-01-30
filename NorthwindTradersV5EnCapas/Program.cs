using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindTradersV5EnCapas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Instanciar el MDI principal
            MDIPrincipal mdiPrincipal = new MDIPrincipal();

            // Obtener pantallas
            Screen[] pantallas = Screen.AllScreens;

            if (pantallas.Length >= 4)
            {
                Screen pantalla4 = pantallas[3];

                // Posicionar el MDI en la pantalla 4
                mdiPrincipal.StartPosition = FormStartPosition.Manual;
                mdiPrincipal.Location = pantalla4.WorkingArea.Location;
                mdiPrincipal.Bounds = pantalla4.WorkingArea;
                //mdiPrincipal.WindowState = FormWindowState.Maximized; // opcional
            }
            else
            {
                MessageBox.Show("No hay 4 pantallas conectadas.");
            }

            // Ejecutar la aplicación con el MDI principal
            Application.Run(mdiPrincipal);


            //Application.Run(new MDIPrincipal());
            //Application.Run(new FrmVentasCrud());
        }
    }
}
