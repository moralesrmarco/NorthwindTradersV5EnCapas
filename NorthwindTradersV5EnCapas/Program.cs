using System;
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

            string usuarioAutenticado = null;
            int idUsuarioAutenticado = 0;
            string nombreUsuarioAutenticado = null;

            // Obtener pantallas
            Screen[] pantallas = Screen.AllScreens;
            Screen pantallaDestino;
            if (pantallas.Length >= 4)
                // Usar la pantalla 2 (índice 1)
                pantallaDestino = pantallas[1];
            else
            {
                // Usar la pantalla principal
                pantallaDestino = Screen.PrimaryScreen;
                //MessageBox.Show("No hay 4 pantallas conectadas. Se usará la pantalla principal.");
            }

            // Mostrar el formulario de login en la pantalla seleccionada
            using (FrmLogin loginForm = new FrmLogin())
            {
                loginForm.Location = pantallaDestino.WorkingArea.Location;
                loginForm.ShowDialog();
                if (!loginForm.IsAuthenticated)
                    return;
                usuarioAutenticado = loginForm.UsuarioAutenticado;
                idUsuarioAutenticado = loginForm.IdUsuarioAutenticado;
                nombreUsuarioAutenticado = loginForm.NombreUsuarioAutenticado;
            }

            // Instanciar el MDIPrincipal en la misma pantalla
            MDIPrincipal mdiPrincipal = new MDIPrincipal
            {
                UsuarioAutenticado = usuarioAutenticado,
                IdUsuarioAutenticado = idUsuarioAutenticado,
                NombreUsuarioAutenticado = nombreUsuarioAutenticado,
                StartPosition = FormStartPosition.Manual,
                Location = pantallaDestino.WorkingArea.Location,
            };
            Application.Run(mdiPrincipal);

            //// Instanciar el MDI principal
            //MDIPrincipal mdiPrincipal = new MDIPrincipal();

            //// Obtener pantallas
            //Screen[] pantallas = Screen.AllScreens;

            //if (pantallas.Length >= 4)
            //{
            //    Screen pantalla4 = pantallas[1];

            //    // Posicionar el MDI en la pantalla 4
            //    mdiPrincipal.StartPosition = FormStartPosition.Manual;
            //    mdiPrincipal.Location = pantalla4.WorkingArea.Location;
            //    mdiPrincipal.Bounds = pantalla4.WorkingArea;
            //    //mdiPrincipal.WindowState = FormWindowState.Maximized; // opcional
            //}
            //else
            //{
            //    MessageBox.Show("No hay 4 pantallas conectadas.");
            //}

            // Ejecutar la aplicación con el MDI principal
            //Application.Run(mdiPrincipal);
        }
    }
}
