using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Utilities
{
    public static class Utils
    {
        #region VariablesGlobales
            public static string nwtr => ConfigurationManager.AppSettings["nwtr"];
            public const string clbdd = "Consultando la base de datos... ";
            public const string oueclbdd = "Ocurrio un error con la base de datos:\n";
            public const string oue = "Ocurrio un error:\n";
            public const string preguntaCerrar = "Se detectaron cambios en los datos del formulario.\n\n¿Esta seguro de querer cerrar el formulario?, si responde SI, se perderan los datos no guardados";
            public const string insertandoRegistro = "Insertando registro en la base de datos...";
            public const string modificandoRegistro = "Modificando registro en la base de datos...";
            public const string eliminandoRegistro = "Eliminando registro en la base de datos...";
            public const string errorCriterioSelec = "Error: Proporcione los criterios de selección";
            public const string noDatos = "No se encontraron datos para mostrar en el reporte";
        #endregion

        // Los siguientes tres métodos trabajan juntos para detectar cambios en TextBox y ComboBox,
        // para que funcionen los metodos FormClosing de los formularios de mantenimiento
        // Método recursivo para recorrer todos los controles anidados
        private static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                yield return ctrl;
                // Recorrer hijos si existen
                foreach (var child in GetAllControls(ctrl))
                    yield return child;
            }
        }

        // Captura valores iniciales SOLO de TextBox y ComboBox,
        // ignorando los que empiezan con txtB o cboB
        public static Dictionary<string, object> CapturarValoresOriginales(Control parent)
        {
            var valores = new Dictionary<string, object>(StringComparer.Ordinal);
            foreach (Control ctrl in GetAllControls(parent))
            {
                var name = ctrl.Name;
                if (string.IsNullOrEmpty(name)) continue;

                if (ctrl is TextBox txt)
                {
                    if (!name.StartsWith("txtB", StringComparison.OrdinalIgnoreCase))
                        valores[name] = txt.Text ?? string.Empty;
                }
                else if (ctrl is ComboBox cbo)
                {
                    if (!name.StartsWith("cboB", StringComparison.OrdinalIgnoreCase))
                        valores[name] = cbo.SelectedIndex;
                }
                else if (ctrl is CheckBox chk)
                {
                    if (!name.StartsWith("chkB", StringComparison.OrdinalIgnoreCase))
                        valores[name] = chk.Checked;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    if (!name.StartsWith("dtpB", StringComparison.OrdinalIgnoreCase))
                        valores[name] = dtp.Value;
                }
                else if (ctrl is NumericUpDown nud)
                {
                    if (!name.StartsWith("nudB", StringComparison.OrdinalIgnoreCase))
                        valores[name] = nud.Value;
                }
            }
            return valores;
        }

        // Compara valores actuales contra los originales
        // Ahora recibe también el ErrorProvider
        public static bool HayCambios(Control parent, Dictionary<string, object> valoresOriginales, ErrorProvider errorProvider)
        {
            if (valoresOriginales == null)
            {
                // sin baseline, lanza excepción
                throw new Exception("Error al ejecutar el metodo HayCambios, el diccionario de valores originales no puede ser nulo.");
            }
            bool hayCambios = false;

            // Limpiar errores previos
            errorProvider.Clear();

            foreach (Control ctrl in GetAllControls(parent))
            {
                var name = ctrl.Name;
                if (string.IsNullOrEmpty(name)) continue;

                if (ctrl is TextBox txt)
                {
                    if (name.StartsWith("txtB", StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (valoresOriginales.TryGetValue(name, out var original))
                    {
                        var actual = txt.Text ?? string.Empty;
                        if (!Equals(original, actual))
                        {
                            hayCambios = true;
                            errorProvider.SetError(txt, "Este campo fue modificado, guarde el formulario o cierrelo sin confirmar los cambios");
                        }
                    }
                }
                else if (ctrl is ComboBox cbo)
                {
                    if (name.StartsWith("cboB", StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (valoresOriginales.TryGetValue(name, out var original))
                    {
                        var actual = cbo.SelectedIndex;
                        if (!Equals(original, actual))
                        {
                            hayCambios = true;
                            errorProvider.SetError(cbo, "Este campo fue modificado, guarde el formulario o cierrelo sin confirmar los cambios");
                        }
                    }
                }
                else if (ctrl is CheckBox chk)
                {
                    if (name.StartsWith("chkB", StringComparison.OrdinalIgnoreCase)) continue;

                    if (valoresOriginales.TryGetValue(name, out var original))
                    {
                        var actual = chk.Checked;
                        if (!Equals(original, actual))
                        {
                            hayCambios = true;
                            errorProvider.SetError(chk, "Este campo fue modificado, guarde el formulario o cierrelo sin confirmar los cambios");
                        }
                    }
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    if (name.StartsWith("dtpB", StringComparison.OrdinalIgnoreCase)) continue;

                    if (valoresOriginales.TryGetValue(name, out var original))
                    {
                        var actual = dtp.Value;
                        if (!Equals(original, actual))
                        {
                            hayCambios = true;
                            errorProvider.SetError(dtp, "Este campo fue modificado, guarde el formulario o cierrelo sin confirmar los cambios");
                        }
                    }
                }
                else if (ctrl is NumericUpDown nud)
                {
                    if (name.StartsWith("nudB", StringComparison.OrdinalIgnoreCase)) continue;

                    if (valoresOriginales.TryGetValue(name, out var original))
                    {
                        var actual = nud.Value;
                        if (!Equals(original, actual))
                        {
                            hayCambios = true;
                            errorProvider.SetError(nud, "Este campo fue modificado, guarde el formulario o cierrelo sin confirmar los cambios");
                        }
                    }
                }
            }
            return hayCambios;
        }

        public static byte[] StripOleHeader(byte[] oleBytes, int employeeId)
        {
            if (oleBytes == null || oleBytes.Length == 0)
                return oleBytes;
            const int OLE_HEADER_LENGTH = 78; // Tamaño típico del encabezado OLE
            int offset = (employeeId <= 8 && oleBytes.Length > OLE_HEADER_LENGTH)
            ? OLE_HEADER_LENGTH
            : 0;

            int length = oleBytes.Length - offset;
            if (length <= 0)
                return Array.Empty<byte>();

            var imageBytes = new byte[length];
            Buffer.BlockCopy(oleBytes, offset, imageBytes, 0, length);
            return imageBytes;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;
            using (var clone = new Bitmap(image))
            using (var ms = new MemoryStream())
            {
                clone.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public static void ValidaTxtBIdIni(TextBox txtBIdIni, TextBox txtBIdFin)
        {
            int numBIdIni = 0, numBIdFin = 0;
            if (txtBIdIni.Text != "")
            {
                if (int.TryParse(txtBIdIni.Text, out int numTxtBIdIni))
                {
                    if (numTxtBIdIni == 0)
                    {
                        MessageBox.Show("El valor del Id inicial no puede ser cero", Utils.nwtr, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBIdIni.Text = "1";
                        txtBIdIni.Focus();
                        return;
                    }
                    numBIdIni = numTxtBIdIni;
                    if (txtBIdFin.Text == "")
                        txtBIdFin.Text = txtBIdIni.Text;
                }
                else
                    MessageBox.Show("Por favor ingrese un número valido", Utils.nwtr, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtBIdFin.Text != "")
            {
                if (int.TryParse(txtBIdFin.Text, out int numTxtBIdFin))
                {
                    numBIdFin = numTxtBIdFin;
                }
                else
                    MessageBox.Show("Por favor ingrese un número valido", Utils.nwtr, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (numBIdFin < numBIdIni)
                txtBIdFin.Text = txtBIdIni.Text;
        }

        public static void ValidaTxtBIdFin(TextBox txtBIdIni, TextBox txtBIdFin)
        {
            int numBIdIni = 0, numBIdFin = 0;
            if (txtBIdIni.Text != "")
            {
                if (int.TryParse(txtBIdIni.Text, out int numTxtBIdIni))
                {
                    numBIdIni = numTxtBIdIni;
                }
                else
                    MessageBox.Show("Por favor ingrese un número valido", Utils.nwtr, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtBIdIni.Text = txtBIdFin.Text;
            }
            if (txtBIdFin.Text != "")
            {
                if (int.TryParse(txtBIdFin.Text, out int numTxtBIdFin))
                {
                    if (numTxtBIdFin == 0)
                    {
                        MessageBox.Show("El valor del Id final no puede ser cero", Utils.nwtr, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBIdFin.Text = "1";
                        txtBIdFin.Focus();
                        Utils.ValidaTxtBIdIni(txtBIdIni, txtBIdFin);
                        return;
                    }
                    numBIdFin = numTxtBIdFin;
                }
                else
                    MessageBox.Show("Por favor ingrese un número valido", Utils.nwtr, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (numBIdIni > numBIdFin)
                txtBIdIni.Text = txtBIdFin.Text;
        }

        public static void ValidarDigitosConPunto(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            // valida que exista solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
            // forzar que solo se capturen como máximo dos dígitos despues del punto decimal
            if (e.KeyChar != 8)
            {
                string numsDecimales = (sender as TextBox).Text + e.KeyChar;
                if ((sender as TextBox).Text.IndexOf('.') > -1)
                {
                    int posComienzo = (sender as TextBox).Text.IndexOf('.');
                    numsDecimales = numsDecimales.Substring(posComienzo, numsDecimales.Length - posComienzo);
                    if (numsDecimales.Length > 3)
                        e.Handled = true;
                }
            }
        }

        public static void ValidarDigitosSinPunto(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8);
        }

        public static void ConfDgv(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.AutoResizeColumns();
        }

        public static void MsgCatchOue(Exception ex, Action actualizarBarraEstado)
        {
            MsgError(Utils.oue + ex.Message);
            actualizarBarraEstado?.Invoke();
        }

        public static void MsgCatchOueclbdd(SqlException ex, Action actualizarBarraEstado)
        {
            if (ex.Number == 53) // Error de conexión
                MsgError("No se pudo conectar a la base de datos.\n\nVerifique su conexión.");
            else
                MsgError(Utils.oueclbdd + ex.Message);
            actualizarBarraEstado?.Invoke();
        }

        // Métodos específicos que llaman al genérico
        public static void MsgWarning(string mensaje) =>
            MostrarMensaje(mensaje, icono: MessageBoxIcon.Warning);

        public static void MsgExclamation(string mensaje) =>
            MostrarMensaje(mensaje, icono: MessageBoxIcon.Exclamation);

        public static void MsgError(string mensaje) =>
            MostrarMensaje(mensaje, icono: MessageBoxIcon.Error);

        public static void MsgInformation(string mensaje) =>
            MostrarMensaje(mensaje, icono: MessageBoxIcon.Information);

        public static DialogResult MsgQuestion(string mensaje) =>
            MostrarMensaje(mensaje, botones: MessageBoxButtons.YesNo, icono: MessageBoxIcon.Question, defaultButton: MessageBoxDefaultButton.Button2);

        public static DialogResult MsgCerrarForm() =>
            MostrarMensaje(preguntaCerrar, botones: MessageBoxButtons.YesNo, icono: MessageBoxIcon.Question, defaultButton: MessageBoxDefaultButton.Button2);
        // Método genérico
        public static DialogResult MostrarMensaje(
            string mensaje,
            string titulo = null,
            MessageBoxButtons botones = MessageBoxButtons.OK,
            MessageBoxIcon icono = MessageBoxIcon.Information,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            return MessageBox.Show(
                mensaje,
                titulo ?? nwtr,
                botones,
                icono,
                defaultButton
            );
        }

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
            // Usamos una lista temporal para las páginas que sí se pueden quitar
            var paginasParaQuitar = new List<TabPage>();
            foreach (TabPage page in tabControl.TabPages)
            {
                Form form = null;
                foreach (Control ctrl in page.Controls)
                {
                    if (ctrl is Form f)
                    {
                        form = f;
                        f.Close(); // dispara FormClosing
                        break;
                    }
                }
                // Solo marcamos la página para quitar si el form se cerró de verdad
                if (form == null || form.IsDisposed)
                {
                    paginasParaQuitar.Add(page);
                }
            }
            // Ahora sí quitamos solo las pestañas que se cerraron
            foreach (var page in paginasParaQuitar)
            {
                tabControl.TabPages.Remove(page);
            }
        }

        public static void CerrarPestañaSeleccionada(TabControl tabControl)
        {
            if (tabControl.SelectedTab != null)
            {
                Form form = null;
                foreach (Control ctrl in tabControl.SelectedTab.Controls)
                {
                    if (ctrl is Form f)
                    {
                        form = f;
                        f.Close();
                        break;
                    }
                }
                // Solo quitar la pestaña si el formulario se cerró de verdad
                if (form == null || form.IsDisposed)
                {
                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                }
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

        // Método para pintar GroupBox con borde negro y texto negro
        public static void GrbPaint(Form form, object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            if (groupBox != null)
            {
                DrawGroupBox(form, groupBox, e.Graphics, Color.Black, Color.Black);
            }
        }

        // Método para pintar GroupBox con borde gris y texto negro
        public static void GrbPaint2(Form form, object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            if (groupBox != null)
            {
                DrawGroupBox(form, groupBox, e.Graphics, Color.Black, Color.LightSlateGray);
            }
        }

        // Método genérico para dibujar cualquier GroupBox
        public static void DrawGroupBox(Form form, GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                using (Brush textBrush = new SolidBrush(textColor))
                using (Brush borderBrush = new SolidBrush(borderColor))
                using (Pen borderPen = new Pen(borderBrush))
                {
                    SizeF strSize = g.MeasureString(box.Text, box.Font);
                    Rectangle rect = new Rectangle(
                        box.ClientRectangle.X,
                        box.ClientRectangle.Y + (int)(strSize.Height / 2),
                        box.ClientRectangle.Width - 1,
                        box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                    // Limpiar el área con el color de fondo del formulario
                    g.Clear(form.BackColor);
                    // Dibujar el texto del GroupBox
                    g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                    // Dibujar los bordes
                    // Izquierda
                    g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                    // Derecha
                    g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    // Abajo
                    g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    // Arriba (partido en dos para dejar espacio al texto)
                    g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                    g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
                }
            }
        }
    }
}
