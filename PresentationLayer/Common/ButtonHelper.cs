using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Common
{
    public static class ButtonHelper
    {
        public static void SetButtonOfDayMouseBehaviour(Button button)
        {
            button.Paint += new PaintEventHandler(OnButtonOfDayPaintEventRaised);
        }

        private static void OnButtonOfDayPaintEventRaised(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            ControlPaint.DrawBorder(e.Graphics, button.ClientRectangle,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
