using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PresentationLayer.Views.CustomControls
{
    class CustomToolTip : ToolTip
    {
        #region Custom data
        private readonly int _width;
        private readonly int _height;
        private string _text;
        #endregion

        #region Constructors
        public CustomToolTip(int width, int height)
        {
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
            _width = width;
            _height = height;
        }

        #endregion

        #region Events's handlers
        private void OnPopup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(e.ToolTipSize.Width + 10, e.ToolTipSize.Height + 10);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;

            LinearGradientBrush b = new LinearGradientBrush(e.Bounds,
                Color.GreenYellow, Color.MintCream, 45f);

            g.FillRectangle(b, e.Bounds);

            g.DrawRectangle(new Pen(Brushes.DarkGreen, 2), new Rectangle(e.Bounds.X, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height - 1));

            g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Silver,
                new PointF(e.Bounds.X + 6, e.Bounds.Y + 6)); // shadow layer
            g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Black,
                new PointF(e.Bounds.X + 5, e.Bounds.Y + 5)); // top layer


            b.Dispose();
        }

        #endregion
    }
}
