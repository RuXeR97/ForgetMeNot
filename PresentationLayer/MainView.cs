using PresentationLayer.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainView : Form, IMainView
    {
        public event MouseEventHandler MainViewMouseUpEventRaised;
        public event MouseEventHandler MainViewMouseDownEventRaised;
        public event MouseEventHandler MainViewMouseMoveEventRaised;
        public event MouseEventHandler ButtonOfArrowRightMouseDownEventRaised;
        public event MouseEventHandler ButtonOfArrowLeftMouseDownEventRaised;

        public event MouseEventHandler ButtonOfDayMouseUpEventRaised;
        public event MouseEventHandler ButtonOfDayMouseDownEventRaised;
        public event MouseEventHandler ButtonOfDayMouseMoveEventRaised;
        public event PaintEventHandler ButtonOfDayPaintEventRaised;

        private Button[] DayButtons;



        public MainView()
        {
            InitializeComponent();
            SetMenuProperties(true, AutoSizeMode.GrowAndShrink, Color.LimeGreen, Color.LimeGreen,
               DockStyle.Fill, FormBorderStyle.None, false);
            //ButtonHelper.InitializeDayButtons()

        }

        public void ShowMainView()
        {
            Show();
        }

        private void SetMenuProperties(bool autoSize, AutoSizeMode autoSizeMode, Color backColor,
            Color transparencyKeyColor, DockStyle dock, FormBorderStyle formBorderStyle, bool showInTaskBar)
        {
            this.AutoSize = autoSize;
            this.AutoSizeMode = autoSizeMode;
            this.Dock = dock;
            this.ShowInTaskbar = showInTaskBar;
            FormBorderStyle = formBorderStyle;
        }

        public Button[] InitializeDays(DateTime currentDate, int width, int height, int sizeX, int sizeY)
        {

            DayButtons = DaysInitializationAlgorithm(currentDate, width, height, sizeX, sizeY,
                    ButtonOfDayMouseUpEventRaised, ButtonOfDayMouseDownEventRaised, ButtonOfDayMouseMoveEventRaised,
                    ButtonOfDayPaintEventRaised);
            Controls.AddRange(DayButtons);
            return DayButtons;
        }

        private Button[] DaysInitializationAlgorithm(DateTime currentDate, int width, int height, int sizeX, int sizeY,
            MouseEventHandler mouseUpHandler, MouseEventHandler mouseDownHandler, MouseEventHandler mouseMoveHandler,
            PaintEventHandler paintHandler)
        {
            int daysInRow = 7;
            DateTime firstDayDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            int lengthOfMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            Button[] days = new Button[lengthOfMonth];
            int j = Convert.ToInt16(firstDayDate.DayOfWeek) - 1;

            width += sizeX * j;
            int maxWidth = sizeX * (daysInRow - 1);
            for (int i = 0; i < lengthOfMonth; i++)
            {
                if ((width == maxWidth) && i != 0)
                {
                    width = 0;
                    height += sizeY;
                }
                else
                    width += sizeX;

                days[i] = new Button();
                days[i].Text = Convert.ToString(i + 1);
                days[i].Location = new Point(width, height);
                days[i].Size = new Size(sizeX, sizeY);
                days[i].MouseUp += mouseUpHandler;
                days[i].MouseDown += mouseDownHandler;
                days[i].MouseMove += mouseMoveHandler;
                days[i].Paint += paintHandler;
            }

            return days;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            foreach (Button button in DayButtons)
            {
                ButtonHelper.SetButtonOfDayMouseBehaviour(button);
            }
        }
    }
}
