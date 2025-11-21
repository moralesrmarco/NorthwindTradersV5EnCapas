using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTradersV5EnCapas
{
    partial class FrmIconosSystemIcons
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpContenedor;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpContenedor = new FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpContenedor
            // 
            this.flpContenedor.Dock = DockStyle.Fill;
            this.flpContenedor.FlowDirection = FlowDirection.TopDown;
            this.flpContenedor.AutoScroll = true;
            this.flpContenedor.WrapContents = false;
            this.flpContenedor.Padding = new Padding(20);
            // 
            // FrmIconosSystemIcons
            // 
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.flpContenedor);
            this.Text = "Íconos de SystemIcons";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }


        #endregion
    }
}