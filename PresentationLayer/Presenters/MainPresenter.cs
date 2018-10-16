using Google.Apis.Calendar.v3.Data;
using Google.Apis.Requests;
using InfrastructureLayer.DataAccess.Repositories.Specific.Task;
using PresentationLayer.Other;
using ServiceLayer.Services.TaskServices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        #region Data
        private IMainView _mainView;
        public event EventHandler TaskDetailViewBindingDoneEventRaised;

        private IDirectResponseSchema _calendarEvents;
        private ITaskService _eventGoogleService;
        private ICalendarEventsParser _calendarEventsParser;


        private readonly int width = -30;
        private readonly int height = 45;
        private readonly int sizeX = 30;
        private readonly int sizeY = 30;
        private const int countOfDaysInWeek = 7;
        string[] tasksArray;

        public DateTime CurrentDate { get; set; }
        #endregion

        public MainPresenter(IMainView mainView)
        {
            CurrentDate = DateTime.Now;
            _mainView = mainView;
            _eventGoogleService = new TaskService(new TaskGoogleRepository(), null);

            _calendarEventsParser = new CalendarEventsParser();
            CurrentDate = DateTime.Now;

            _calendarEvents = GetDataFromLocalRepository();
            LoadTasksArray();

            _mainView.InitializeDays(CurrentDate, width, height + sizeY / 2, sizeX, sizeY);
            _mainView.InitializeLabelsOWeekfDays(countOfDaysInWeek, width, height, sizeX);
            _mainView.InitializeDateLabels(width, height, sizeX, sizeY, CurrentDate);
            _mainView.InitializeLeftArrow(sizeX, sizeY);
            _mainView.InitializeRightArrow(sizeX, sizeY);
            _mainView.InitializeToolTips(tasksArray);
            _mainView.HighlightDaysButtonsWithTasks(tasksArray);
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
        private IDirectResponseSchema GetDataFromLocalRepository()
        {
            var calendarEvents = _eventGoogleService.GetAllEvents();

            return calendarEvents;
        }

        #region Loading methods
        private void LoadMonthAndYearLabels()
        {
            _mainView.InitializeDateLabels(width, height, sizeX, sizeY, CurrentDate);
        }

        private void LoadButtonsOfDays()
        {
            _mainView.InitializeDays(CurrentDate, width, height + sizeY / 2, sizeX, sizeY);
        }

        private void LoadToolTips()
        {
            _mainView.InitializeToolTips(tasksArray);
        }

        private void LoadTasksArray()
        {
            var currentMonthEvents = (_calendarEvents as Events).Items.
                Where(i => i.Start.DateTime != null && 
                i.Start.DateTime.Value.Year == CurrentDate.Year && 
                i.Start.DateTime.Value.Month == CurrentDate.Month).ToList();

            tasksArray = _calendarEventsParser.ConvertCalendarEventsToArray(CurrentDate, currentMonthEvents);
        }

        private void HighlightButtons()
        {
            _mainView.HighlightDaysButtonsWithTasks(tasksArray);
        }

        #endregion

        #region Events
        private void OnButtonOfDayPaintEventRaised(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnButtonOfArrowLeftMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(-1);

            LoadTasksArray();
            LoadButtonsOfDays();
            LoadMonthAndYearLabels();
            LoadToolTips();
            HighlightButtons();
        }

        private void OnButtonOfArrowRightMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(1);

            LoadTasksArray();
            LoadButtonsOfDays();
            LoadMonthAndYearLabels();
            LoadToolTips();
            HighlightButtons();
        }
        #endregion
    }

}
