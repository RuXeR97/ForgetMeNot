﻿using CommonComponents;
using PresentationLayer.Common;
using PresentationLayer.Views.CustomControls;
using System;
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
        public event EventHandler MainViewLoadEventRaised;
        public event EventHandler MainViewFormClosingEventRaised;
        public event EventHandler AddEventToolStripButtonClickEventRaised;
        public event EventHandler SettingsToolStripButtonClickEventRaised;

        private Button[] DayButtons;
        private Label[] DaysLabels;
        private Button ArrowLeftButton;
        private Button ArrowRightButton;
        private Label[] DateLabels;
        private NotifyIcon NotifyIcon;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private readonly string path;
        private Button chosenDayButton;


        public MainView()
        {
            InitializeComponent();
            SetMenuProperties(true, AutoSizeMode.GrowAndShrink, Color.LimeGreen, Color.LimeGreen,
               DockStyle.Fill, FormBorderStyle.None, false);

            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        }
        public void ShowMainView()
        {
            Show();
        }
        public void SetMenuPosition()
        {
            this.Location = new Point(Properties.Settings.Default.LocationX, Properties.Settings.Default.LocationY);
        }
        public void SaveMenuPosition()
        {
            Properties.Settings.Default.LocationX = this.Location.X;
            Properties.Settings.Default.LocationY = this.Location.Y;
            Properties.Settings.Default.Save();
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

        public void InitializeNotifyIcon()
        {
            NotifyIcon = new NotifyIcon();
            NotifyIcon.Visible = true;
            NotifyIcon.Icon = Icon.ExtractAssociatedIcon(path + @"\Resources\icon.ico");

            NotifyIcon.ContextMenuStrip = SetNotifyIconContextMenuStrip();
            NotifyIcon.DoubleClick += MaximizeApplicationButton_Click;
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

        private void SetMenuProperties(bool autoSize, AutoSizeMode autoSizeMode, Color backColor,
    Color transparencyKeyColor, DockStyle dock, FormBorderStyle formBorderStyle, bool showInTaskBar)
        {
            this.AutoSize = autoSize;
            this.AutoSizeMode = autoSizeMode;
            this.Dock = dock;
            this.ShowInTaskbar = showInTaskBar;
            FormBorderStyle = formBorderStyle;
        }
        private ContextMenuStrip SetNotifyIconContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit")
            {
                Image = (Bitmap)Bitmap.FromFile(path + @"\Resources\exitIcon.ico")
            };
            exitMenuItem.Click += new EventHandler(ExitApplicationButton_Click);
            exitMenuItem.Name = "Exit";
            contextMenuStrip.Items.Add(exitMenuItem);

            ToolStripMenuItem settingsMenuItem = new ToolStripMenuItem("Settings")
            {
                Image = (Bitmap)Bitmap.FromFile(path + @"\Resources\settingsIcon.ico")
            };
            settingsMenuItem.Click += new EventHandler(SettingsButton_Click);
            settingsMenuItem.Name = "Settings";
            contextMenuStrip.Items.Add(settingsMenuItem);

            return contextMenuStrip;
        }
        private ContextMenuStrip SetMainViewContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem addEventMenuItem = new ToolStripMenuItem("Add event")
            {
                Image = (Bitmap)Bitmap.FromFile(path + @"\Resources\addIcon.ico")
            };
            addEventMenuItem.Name = "Add event";
            addEventMenuItem.Click += AddEventButton_Click;
            contextMenuStrip.Items.Add(addEventMenuItem);

            ToolStripMenuItem minimizeApplicationMenuItem = new ToolStripMenuItem("Minimize")
            {
                Image = (Bitmap)Bitmap.FromFile(path + @"\Resources\minimizeIcon.ico")
            };
            minimizeApplicationMenuItem.Name = "Minimize to tray";
            minimizeApplicationMenuItem.Click += MinimizeApplicationButton_Click;
            contextMenuStrip.Items.Add(minimizeApplicationMenuItem);

            ToolStripMenuItem closeApplicationMenuItem = new ToolStripMenuItem("Exit")
            {
                Image = (Bitmap)Bitmap.FromFile(path + @"\Resources\exitIcon.ico")
            };
            closeApplicationMenuItem.Name = "Exit";
            closeApplicationMenuItem.Click += ExitApplicationButton_Click;
            contextMenuStrip.Items.Add(closeApplicationMenuItem);

            return contextMenuStrip;
        }

        #endregion

        #region MainView's Events
        private void MainView_Load(object sender, EventArgs e)
        {
            foreach (Button button in DayButtons)
            {
                MainViewButtonsHelper.SetButtonOfDayMouseBehaviour(button);
            }

            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: MainViewLoadEventRaised, eventArgs: e);
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
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: MainViewFormClosingEventRaised, eventArgs: e);
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
                        ContextMenuStrip contextMenuStrip = SetMainViewContextMenuStrip();
                        
                        Button button = sender as Button;
                        chosenDayButton = button;
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
            var asd = sender as Button;
            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: ButtonOfArrowRightMouseClickEventRaised, eventArgs: e);
        }
        #endregion

        #region ToolStripButtons' events
        private void AddEventButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(objectRaisingEvent: chosenDayButton, eventHandlerRaised: AddEventToolStripButtonClickEventRaised, eventArgs: e);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: SettingsToolStripButtonClickEventRaised, eventArgs: e);
        }

        private void ExitApplicationButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeApplicationButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void MaximizeApplicationButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}
