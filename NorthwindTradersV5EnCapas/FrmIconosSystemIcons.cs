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
    public partial class FrmIconosSystemIcons : Form
    {
        public FrmIconosSystemIcons()
        {
            InitializeComponent();
            MostrarIconos();
        }

        private void MostrarIconos()
        {
            AgregarIcono(SystemIcons.Application, "Application");
            AgregarIcono(SystemIcons.Information, "Information");
            AgregarIcono(SystemIcons.Error, "Error");
            AgregarIcono(SystemIcons.Warning, "Warning");
            AgregarIcono(SystemIcons.Question, "Question");
            AgregarIcono(SystemIcons.Shield, "Shield");
        }

        private void AgregarIcono(Icon icono, string nombre)
        {
            var pic = new PictureBox
            {
                Image = icono.ToBitmap(),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(32, 32),
                Margin = new Padding(10)
            };

            var lbl = new Label
            {
                Text = $"SystemIcons.{nombre}",
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Margin = new Padding(10)
            };

            var panel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };
            panel.Controls.Add(pic);
            panel.Controls.Add(lbl);

            flpContenedor.Controls.Add(panel);
        }
    }
}
