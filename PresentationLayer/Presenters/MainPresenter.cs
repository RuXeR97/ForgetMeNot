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
            _mainView = mainView;
            _mainView.InitializeDays(DateTime.Now, width, height + sizeY / 2, sizeX, sizeY);

            CurrentDate = DateTime.Now;
        }

        public IMainView GetMainView()
        {
            return _mainView;
        }

        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewMouseDownEventRaised += new MouseEventHandler(OnMainViewMouseDownEventRaised);
            _mainView.MainViewMouseUpEventRaised += new MouseEventHandler(OnMainViewMouseUpEventRaised);
            _mainView.MainViewMouseMoveEventRaised += new MouseEventHandler(OnMainViewMouseMoveEventRaised);
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
            throw new NotImplementedException();
        }

        private void OnMainViewMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnMainViewMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
