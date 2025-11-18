using System;
using System.Windows.Forms;
using Utilities;

namespace NorthwindTradersV5EnCapas
{
    internal class U
    {
        public static void MsgCatchOue(Exception ex)
        {
            Utils.MsgCatchOue(ex, () => MDIPrincipal.ActualizarBarraDeEstado());
        }
        public static void MsgWarning(string mensaje) => Utils.MsgWarning(mensaje);

        public static void MsgExclamation(string mensaje) => Utils.MsgExclamation(mensaje);

        public static void MsgError(string mensaje) => Utils.MsgError(mensaje);

        public static void MsgInformation(string mensaje) => Utils.MsgInformation(mensaje);

        public static DialogResult MsgQuestion(string mensaje) => Utils.MsgQuestion(mensaje);

        public static DialogResult MsgCerrarForm() => Utils.MsgCerrarForm();

    }
}
