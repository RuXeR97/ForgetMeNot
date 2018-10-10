using CommonComponents;
using PresentationLayer.Common;
using PresentationLayer.Views.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainView : Form, IMainView
    {

        public event MouseEventHandler ButtonOfArrowLeftMouseClickEventRaised;
        public event MouseEventHandler ButtonOfArrowRightMouseClickEventRaised;

        private Button[] DayButtons;
        private Label[] DaysLabels;
        private Button ArrowLeftButton;
        private Button ArrowRightButton;
        private Label[] DateLabels;
        private List<string> TasksStrings;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;



        public MainView()
        {
            InitializeComponent();
            SetMenuProperties(true, AutoSizeMode.GrowAndShrink, Color.LimeGreen, Color.LimeGreen,
               DockStyle.Fill, FormBorderStyle.None, false);
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

        #region Public initialization methods
        public Button[] InitializeDays(DateTime currentDate, int width, int height, int sizeX, int sizeY)
        {
            // for refreshing purposes
            if (DayButtons != null)
            {
                foreach (var dayButton in DayButtons)
                {
                    dayButton.Dispose();
                }
            }

            DayButtons = DaysInitializationAlgorithm(currentDate, width, height, sizeX, sizeY,
                ButtonOfDay_MouseDown, ButtonOfDay_MouseUp, ButtonOfDay_MouseMove, ButtonOfDay_Paint);

            Controls.AddRange(DayButtons);
            return DayButtons;
        }
        public Label[] InitializeLabelsOWeekfDays(int countOfDaysInWeek, int width, int height, int sizeX)
        {
            // for refreshing purposes
            if (DaysLabels != null)
            {
                foreach (var dayLabel in DaysLabels)
                {
                    dayLabel.Dispose();
                }
            }

            DaysLabels = new Label[countOfDaysInWeek];
            string[] daysOfWeek = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            for (int i = 0; i < countOfDaysInWeek; i++)
            {
                width += sizeX;
                DaysLabels[i] = new Label();
                DaysLabels[i].Location = new Point(width, height);
                DaysLabels[i].Text = daysOfWeek[i];
                DaysLabels[i].ForeColor = Color.Black;
                DaysLabels[i].AutoSize = true;
            }
            Controls.AddRange(DaysLabels);
            return DaysLabels;
        }
        public Label[] InitializeDateLabels(int width, int height, int sizeX, int sizeY, DateTime date)
        {
            // for refreshing purposes
            if (DateLabels != null)
            {
                foreach (var dateLabel in DateLabels)
                {
                    dateLabel.Dispose();
                }
            }

            int amountOfLabels = 2;
            DateLabels = new Label[amountOfLabels];

            DateLabels[0] = new Label();

            DateLabels[0].Location = new Point(92, 10);
            DateLabels[0].Text = date.Year.ToString();
            DateLabels[0].Font = new Font("Arial", 7);


            DateLabels[1] = new Label();
            DateLabels[1].Location = new Point(87, 21);
            DateLabels[1].Text = date.ToString("MMM", CultureInfo.InvariantCulture);
            DateLabels[1].Font = new Font("Arial", 14);

            DateLabels[0].ForeColor = DateLabels[1].ForeColor = Color.Black;
            DateLabels[0].AutoSize = DateLabels[1].AutoSize = true;

            Controls.AddRange(DateLabels);
            return DateLabels;
        }
        public Button InitializeLeftArrow(int sizeX, int sizeY)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(path + @"\Resources\leftArrow.png");

            ArrowLeftButton = new Button
            {
                AutoSize = true,
                Image = bitmap,
                Size = new Size(sizeX, sizeY / 3),
                Location = new Point(Math.Abs(sizeX / 2), 10)
            };
            ArrowLeftButton.MouseClick += ArrowLeftButton_Click;

            Controls.Add(ArrowLeftButton);
            return ArrowLeftButton;
        }
        public Button InitializeRightArrow(int sizeX, int sizeY)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(path + @"\Resources\rightArrow.png");

            ArrowRightButton = new Button
            {
                AutoSize = true,
                Image = bitmap,
                Size = new Size(sizeX, sizeY / 3),
                Location = new Point(Math.Abs(5 * sizeX + sizeX / 2), 10),
            };
            ArrowRightButton.MouseClick += ArrowRightButton_Click;

            Controls.Add(ArrowRightButton);
            return ArrowRightButton;
        }
        public void InitializeToolTips(string[] text, int height, int width)
        {
            if (text == null)
                return;
            for (int i = 0; i < text.Length; i++)
            {
                ToolTip toolTip = new CustomToolTip(height, width);
                toolTip.SetToolTip(DayButtons[i], text[i]);
            }
        }
        public void HighlightDaysButtonsWithTasks(string[] text)
        {
            if (text == null)
                return;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != null)
                {
                    DayButtons[i].BackColor = Color.LightYellow;
                }
            }
        }
        #endregion

        #region Private initialization methods

        private Button[] DaysInitializationAlgorithm(DateTime currentDate, int width, int height, int sizeX, int sizeY,
            MouseEventHandler mouseDownHandler, MouseEventHandler mouseUpHandler,
            MouseEventHandler mouseMoveHandler, PaintEventHandler paintHandler)
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
                days[i].MouseDown += mouseDownHandler;
                days[i].MouseUp += mouseUpHandler;
                days[i].MouseMove += mouseMoveHandler;
                days[i].Paint += paintHandler;
            }

            return days;
        }

        #endregion

        #region MainView's Events
        private void MainView_Load(object sender, EventArgs e)
        {
            foreach (Button button in DayButtons)
            {
                MainViewButtonsHelper.SetButtonOfDayMouseBehaviour(button);
            }
        }
        private void MainView_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void MainView_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void MainView_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        #endregion

        #region ButtonOfDays' Events
        private void ButtonOfDay_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {

                        dragging = true;
                        dragCursorPoint = Cursor.Position;
                        dragFormPoint = this.Location;
                    }
                    break;

                case MouseButtons.Right:
                    {
                        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

                        ToolStripMenuItem menuItem = new ToolStripMenuItem("Add task");
                        menuItem.Name = "Add task";
                        contextMenuStrip.Items.Add(menuItem);
                        Button button = sender as Button;
                        Point screenPoint = button.PointToScreen(new Point(button.Left, button.Bottom));
                        if (screenPoint.Y + contextMenuStrip.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
                        {
                            contextMenuStrip.Show(button, new Point(0, -contextMenuStrip.Size.Height));
                        }
                        else
                        {
                            contextMenuStrip.Show(button, new Point(0, button.Height));
                        }
                    }
                    break;
            }
        }
        private void ButtonOfDay_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void ButtonOfDay_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void ButtonOfDay_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            ControlPaint.DrawBorder(e.Graphics, button.ClientRectangle,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }

        #endregion

        #region Arrows' Events
        private void ArrowLeftButton_Click(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: ButtonOfArrowLeftMouseClickEventRaised, eventArgs: e);
        }

        private void ArrowRightButton_Click(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: ButtonOfArrowRightMouseClickEventRaised, eventArgs: e);
        }

        #endregion
    }
}
