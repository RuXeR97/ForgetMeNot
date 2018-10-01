using DomainLayer.Models.MonthTasks;
using System;
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

            SubscribeToEventsSetup();
        }

        public IMainView GetMainView()
        {
            return _mainView;
        }

        private void SubscribeToEventsSetup()
        {
            _mainView.ButtonOfArrowLeftMouseClickEventRaised += new MouseEventHandler(OnButtonOfArrowLeftMouseDownEventRaised);
            _mainView.ButtonOfArrowRightMouseClickEventRaised += new MouseEventHandler(OnButtonOfArrowRightMouseDownEventRaised);
        }

        private void OnButtonOfDayPaintEventRaised(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnButtonOfArrowLeftMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(-1);
            //MonthTaskModel.CurrentDate.AddMonths(-1);

            ReloadButtonOfDays();
            ReloadMonthAndYearLabels();
        }


        private void OnButtonOfArrowRightMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(1);
            //MonthTaskModel.CurrentDate.AddMonths(1);

            ReloadButtonOfDays();
            ReloadMonthAndYearLabels();
        }
        private void ReloadMonthAndYearLabels()
        {
            // change CurrentDate
            _mainView.InitializeDateLabels(width, height, sizeX, sizeY, CurrentDate);
        }

        private void ReloadButtonOfDays()
        {
            // change CurrentDate
            _mainView.InitializeDays(CurrentDate, width, height + sizeY / 2, sizeX, sizeY);
        }
    }
}
