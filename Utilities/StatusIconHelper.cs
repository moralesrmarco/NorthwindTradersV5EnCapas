using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Utilities
{
    public static class StatusIconHelper
    {
        public static void ShowIcons(Control target, ToolTip toolTip,
            (PictureBox pb, Image icon, string message, bool visible) error,
            (PictureBox pb, Image icon, string message, bool visible) info,
            (PictureBox pb, Image icon, string message, bool visible) warning)
        {
            // Ocultar todos primero
            error.pb.Visible = false;
            info.pb.Visible = false;
            warning.pb.Visible = false;

            // Lista en orden de prioridad
            var icons = new List<(PictureBox pb, Image icon, string message, bool visible)>
        {
            error,
            info,
            warning
        };

            int offset = 0;
            foreach (var iconData in icons)
            {
                if (iconData.visible)
                {
                    PositionIcon(target, iconData.pb, offset);
                    iconData.pb.Image = iconData.icon;
                    toolTip.SetToolTip(iconData.pb, iconData.message);
                    iconData.pb.Visible = true;
                    offset += 20; // separar cada ícono 20px
                }
            }
        }

        private static void PositionIcon(Control target, PictureBox pb, int offset)
        {
            pb.Size = new Size(16, 16);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Location = new Point(target.Right + 5 + offset, target.Top + (target.Height - pb.Height) / 2);
            pb.BringToFront();
        }
    }
}
