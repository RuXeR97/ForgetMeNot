using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Common
{
    public static class MainViewButtonsHelper
    {
        public static void SetButtonOfDayMouseBehaviour(Button button)
        {
            button.Paint += new PaintEventHandler(OnButtonOfDayPaintEventRaised);
        }

        public static void SetButtonOfArrowLeftBehaviour(Button button)
        {

        }

        public static void SetButtonOfArrowRightBehaviour(Button button)
        {

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

        private static void OnButtonOfArrowLeftMouseDownEventRaised(object sender, MouseEventArgs e)
        {

        }

        private static void OnButtonOfArrowRightMouseDownEventRaised(object sender, MouseEventArgs e)
        {

        }


    }
}
