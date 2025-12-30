using System.Windows.Forms;

namespace Utilities
{
    public class NudNoWheel : NumericUpDown
    {
        public bool WheelEnabled { get; set; } = true;

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (WheelEnabled)
            {
                base.OnMouseWheel(e); // comportamiento normal
            }
            else
            {
                ((HandledMouseEventArgs)e).Handled = true; // bloquea el scroll
            }
        }
    }
}
