using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTradersV5EnCapas.Controles
{
    public class TabHeaderButton : Panel
    {
        private Label lbl;
        private PictureBox pic;
        private CustomTabHeader owner;

        public int Index { get; }

        public TabHeaderButton(string text, int index, CustomTabHeader owner)
        {
            this.owner = owner;
            Index = index;

            Padding = new Padding(8, 4, 6, 4);
            Margin = new Padding(2);
            Cursor = Cursors.Hand;
            Height = owner.Height - 4;

            lbl = new Label
            {
                Text = text,
                AutoSize = true,
                Dock = DockStyle.Left
            };

            pic = new PictureBox
            {
                Width = 11,
                Dock = DockStyle.Right,
                SizeMode = PictureBoxSizeMode.CenterImage
            };

            Controls.Add(pic);
            Controls.Add(lbl);

            Width = lbl.Width + pic.Width + Padding.Left + Padding.Right;

            Click += (s, e) => owner.TabControl.SelectedIndex = Index;
            lbl.Click += (s, e) => owner.TabControl.SelectedIndex = Index;
            pic.Click += (s, e) => owner.TabControl.SelectedIndex = Index;
        }

        public void Update(int selectedIndex)
        {
            bool selected = Index == selectedIndex;

            BackColor = selected
                ? SystemColors.Highlight
                : SystemColors.GradientActiveCaption;

            lbl.ForeColor = selected
                ? SystemColors.HighlightText
                : SystemColors.ActiveCaptionText;

            lbl.Font = new Font(
                lbl.Font,
                selected ? FontStyle.Bold : FontStyle.Regular);

            pic.Image = selected
                ? owner.IconOn
                : owner.IconOff;
        }
    }
}
