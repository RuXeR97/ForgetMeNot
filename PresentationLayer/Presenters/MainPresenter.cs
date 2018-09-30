using DomainLayer.Models.MonthTasks;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _mainView;
        public event EventHandler TaskDetailViewBindingDoneEventRaised;

        private MonthTasksModel MonthTaskModel;

        private readonly int width = -30;
        private readonly int height = 45;
        private readonly int sizeX = 30;
        private readonly int sizeY = 30;
        private const int countOfDaysInWeek = 7;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public DateTime CurrentDate { get; set; }

        public MainPresenter(IMainView mainView)
        {
            CurrentDate = DateTime.Now;
            _mainView = mainView;

            _mainView.InitializeDays(CurrentDate, width, height + sizeY / 2, sizeX, sizeY);
            _mainView.InitializeLabelsOfDays(countOfDaysInWeek, width, height, sizeX);
            _mainView.InitializeDateLabels(width, height, sizeX, sizeY, CurrentDate);
            _mainView.InitializeLeftArrow(sizeX, sizeY);
            _mainView.InitializeRightArrow(sizeX, sizeY);

        }

        public IMainView GetMainView()
        {
            return _mainView;
        }

        private void SubscribeToEventsSetup()
        {
            _mainView.ButtonOfArrowRightMouseDownEventRaised += new MouseEventHandler(OnButtonOfArrowRightMouseDownEventRaised);
            _mainView.ButtonOfArrowLeftMouseDownEventRaised += new MouseEventHandler(OnButtonOfArrowLeftMouseDownEventRaised);
            //_mainView.ButtonOfDayPaintEventRaised += new PaintEventHandler(OnButtonOfDayPaintEventRaised);
        }

        private void OnButtonOfDayPaintEventRaised(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnButtonOfArrowLeftMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            MonthTaskModel.CurrentDate.AddMonths(-1);

            ReloadButtonOfDays();
            ReloadYearLabel();
            ReloadMonthLabel();
        }

        private void ReloadMonthLabel()
        {
            throw new NotImplementedException();
        }

        private void ReloadYearLabel()
        {
            throw new NotImplementedException();
        }

        private void ReloadButtonOfDays()
        {
            throw new NotImplementedException();
        }

        private void OnButtonOfArrowRightMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            MonthTaskModel.CurrentDate.AddMonths(1);

            ReloadButtonOfDays();
            ReloadYearLabel();
            ReloadMonthLabel();
        }

        private void OnMainViewMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            Form form = sender as Form;
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                form.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void OnMainViewMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void OnMainViewMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            Form form = sender as Form;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {

                        dragging = true;
                        dragCursorPoint = Cursor.Position;
                        dragFormPoint = form.Location;
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
    }
}
