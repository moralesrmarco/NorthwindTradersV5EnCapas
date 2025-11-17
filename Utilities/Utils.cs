using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public static class Utils
    {
        #region VariablesGlobales
        public static string nwtr => ConfigurationManager.AppSettings["nwtr"];
        public static string clbdd = "Consultando la base de datos... ";
        public static string oueclbdd = "Ocurrio un error con la base de datos:\n";
        public static string oue = "Ocurrio un error:\n";
        //public static string nwtr = "» Northwind Traders Ver 5.0 Arquitectura en capas «";
        public static string preguntaCerrar = "¿Esta seguro de querer cerrar el formulario?, si responde SI, se perderan los datos no guardados";
        public static string insertandoRegistro = "Insertando registro en la base de datos...";
        public static string modificandoRegistro = "Modificando registro en la base de datos...";
        public static string eliminandoRegistro = "Eliminando registro en la base de datos...";
        public static string errorCriterioSelec = "Error: Proporcione los criterios de selección";
        public static string noDatos = "No se encontraron datos para mostrar en el reporte";
        #endregion

        public static void AgregarFormularioEnTab(TabControl tabControl, Form formulario, string titulo)
        {
            // Buscar si ya existe una pestaña con ese título
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Text == titulo)
                {
                    // Si ya existe, seleccionarla y salir
                    tabControl.SelectedTab = page;
                    return;
                }
            }
            // Crear una nueva pestaña
            TabPage nuevaPestaña = new TabPage(titulo);
            // Configurar el formulario para incrustarlo
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            // Agregar el formulario a la pestaña
            nuevaPestaña.Controls.Add(formulario);
            // Agregar la pestaña al TabControl
            tabControl.TabPages.Add(nuevaPestaña);
            // Seleccionar la pestaña recién agregada
            tabControl.SelectedTab = nuevaPestaña;
            // Mostrar el formulario incrustado
            formulario.Show();
        }

        public static void CerrarTodasLasPestañas(TabControl tabControl)
        {
            // Opción 2 (más segura): recorrer y cerrar formularios incrustados antes de limpiar
            foreach (TabPage page in tabControl.TabPages)
            {
                foreach (Control ctrl in page.Controls)
                {
                    if (ctrl is Form form)
                    {
                        form.Close(); // cerrar el formulario incrustado
                    }
                }
            }
            tabControl.TabPages.Clear();
        }

        public static void CerrarPestañaSeleccionada(TabControl tabControl)
        {
            if (tabControl.SelectedTab != null)
            {
                // Cerrar el formulario incrustado si existe
                foreach (Control ctrl in tabControl.SelectedTab.Controls)
                {
                    if (ctrl is Form form)
                    {
                        form.Close();
                    }
                }
                // Quitar la pestaña seleccionada
                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
        }

        public static void DibujarPestañas(TabControl tabControl, DrawItemEventArgs e)
        {
            TabPage page = tabControl.TabPages[e.Index];
            bool isSelected = (e.Index == tabControl.SelectedIndex);
            // Colores fijos
            Color backColor = isSelected ? SystemColors.Highlight : SystemColors.GradientActiveCaption;
            Color textColor = isSelected ? SystemColors.HighlightText : SystemColors.ActiveCaptionText;
            // Fuente fija: itálica si está seleccionada, regular si no
            Font textFont = isSelected
                ? new Font(e.Font, FontStyle.Italic)
                : new Font(e.Font, FontStyle.Regular);
            // Pintar fondo
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            // Pintar texto centrado
            TextRenderer.DrawText(e.Graphics,
                                  page.Text,
                                  textFont,
                                  e.Bounds,
                                  textColor,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public static void OpenForm<T>(Form mdiParent) where T : Form, new()
        {
            T newForm = new T
            {
                MdiParent = mdiParent,
                WindowState = FormWindowState.Maximized
            };
            newForm.Show();
        }

        public static void CloseForms(Action actualizarBarraDeEstado)
        {
            //Declaramos una lista de tipo Form
            List<Form> formularios = new List<Form>();
            //Recorremos Application.OpenForms el cual tiene la lista de formularios y metemos todos los forms en la lista que declarmos
            foreach (Form form in Application.OpenForms)
                formularios.Add(form);
            // recorremos la lista de formularios
            for (int i = 0; i < formularios.Count; i++)
            {
                // validamos que el nombre de los formularios sean distintos al unico formulario que queremos abierto
                if (formularios[i].Name != "MDIPrincipal")
                    formularios[i].Close();
                else
                    //MDIPrincipal.ActualizarBarraDeEstado();
                    actualizarBarraDeEstado?.Invoke();
            }
        }
    }
}
