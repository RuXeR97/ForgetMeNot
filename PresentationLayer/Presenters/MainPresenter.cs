using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using InfrastructureLayer.DataAccess.Repositories.Local.Task;
using ServiceLayer.Services.TaskServices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _mainView;
        public event EventHandler TaskDetailViewBindingDoneEventRaised;

        private IUniqueComponentList<CalendarEvent> calendarEvents;
        private ITaskService _taskService;
        private DateTime currentDate;


        private readonly int width = -30;
        private readonly int height = 45;
        private readonly int sizeX = 30;
        private readonly int sizeY = 30;
        private const int countOfDaysInWeek = 7;
        string[] tasksArray;
        public DateTime CurrentDate { get; set; }

        public MainPresenter(IMainView mainView)
        {
            CurrentDate = DateTime.Now;
            _mainView = mainView;
            _taskService = new TaskService(new TaskLocalRepository("ruxer"), null);
            currentDate = DateTime.Now;
            calendarEvents = GetDataFromLocalRepository();

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

        private IUniqueComponentList<CalendarEvent> GetDataFromLocalRepository()
        {
            ICalendarComponent _calendar = new Calendar();
            IUniqueComponentList<CalendarEvent> calendarEvents = _taskService.GetAll();

            return calendarEvents;
        }

        private string[] GetCurrentMonthTasksToArray()
        {
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            string[] arrayOfTasks = new string[daysInMonth];
            DateTime dateCounter = new DateTime(currentDate.Year, currentDate.Month, 1);
            string finalTask = null;
            var eventModels = calendarEvents.Where(i => i.DtStart.Month == currentDate.Month);

            for (int i = 0; i < arrayOfTasks.Length; i++)
            {
                var dayEventModels = eventModels.Where(j => j.DtStart.Day == dateCounter.Day);
                if (dayEventModels != null)
                {
                    foreach (var taskModel in dayEventModels)
                    {
                        finalTask += taskModel.Summary + Environment.NewLine;
                    }

                    arrayOfTasks[i] = finalTask;
                    finalTask = null;
                }
                dateCounter = dateCounter.AddDays(1);
            }
            return arrayOfTasks;
        }

        #region Loading methods
        private void LoadMonthAndYearLabels()
        {
            _mainView.InitializeDateLabels(width, height, sizeX, sizeY, currentDate);
        }

        private void LoadButtonsOfDays()
        {
            _mainView.InitializeDays(currentDate, width, height + sizeY / 2, sizeX, sizeY);
        }

        private void LoadToolTips()
        {
            _mainView.InitializeToolTips(tasksArray);
        }

        private void LoadTasksArray()
        {
            tasksArray = GetCurrentMonthTasksToArray();
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
            currentDate = currentDate.AddMonths(-1);

            LoadTasksArray();
            LoadButtonsOfDays();
            LoadMonthAndYearLabels();
            LoadToolTips();
            HighlightButtons();
        }

        private void OnButtonOfArrowRightMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            currentDate = currentDate.AddMonths(1);

            LoadTasksArray();
            LoadButtonsOfDays();
            LoadMonthAndYearLabels();
            LoadToolTips();
            HighlightButtons();
        }
        #endregion
    }

}
