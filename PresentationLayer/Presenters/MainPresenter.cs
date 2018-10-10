using DomainLayer.Models.MonthTasks;
using DomainLayer.Models.Task;
using InfrastructureLayer.DataAccess.Repositories.Local.Task;
using ServiceLayer.Services.TaskServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _mainView;
        public event EventHandler TaskDetailViewBindingDoneEventRaised;

        private IMonthTasksModel _monthTaskModel;
        private ITaskService _taskService;

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

            _monthTaskModel = GetDataFromLocalRepository();

            //TaskModel taskModel2 = new TaskModel()
            //{
            //    TaskId = 2,
            //    Description = "Test Description 2",
            //    StartTime = DateTime.Now.AddHours(-5),
            //    EndTime = DateTime.Now.AddHours(0),
            //    Title = "Test Task 2"
            //};
            //TaskModel taskModel3 = ()
            //{
            //    TaskId = 3,
            //    Description = "Test Description 10",
            //    StartTime = DateTime.Now.AddHours(-5),
            //    EndTime = DateTime.Now.AddHours(0),
            //    Title = "Test Task 2"
            //};
            //_monthTaskModel.Edit(taskModel2, taskModel3);
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

        private IMonthTasksModel GetDataFromLocalRepository()
        {
            IMonthTasksModel _monthTaskModel = new MonthTasksModel();

            _monthTaskModel.CurrentDate = CurrentDate;

            Dictionary<DateTime, List<TaskModel>> allTasks2 = _taskService.GetAll();
            _monthTaskModel.AddRange(allTasks2);

            return _monthTaskModel;
        }

        private string[] GetCurrentMonthTasksToArray()
        {
            int daysInMonth = DateTime.DaysInMonth(_monthTaskModel.CurrentDate.Year, _monthTaskModel.CurrentDate.Month);
            string[] arrayOfTasks = new string[daysInMonth];

            string finalTask = null;
            var taskModels = _monthTaskModel.GetCurrentMonthTasks();

            for (int i = 0; i < arrayOfTasks.Length; i++)
            {
                List<TaskModel> taskModelsPerDay = taskModels.
                    FirstOrDefault(y => y.Key.Day == (i + 1)).
                    Value;

                if (taskModelsPerDay != null)
                {
                    foreach (var taskModel in taskModelsPerDay)
                    {
                        finalTask += taskModel.Title + Environment.NewLine;
                    }

                    arrayOfTasks[i] = finalTask;
                    finalTask = null;
                }
            }
            return arrayOfTasks;
        }

        #region Loading methods
        private void LoadMonthAndYearLabels()
        {
            _mainView.InitializeDateLabels(width, height, sizeX, sizeY, _monthTaskModel.CurrentDate);
        }

        private void LoadButtonsOfDays()
        {
            _mainView.InitializeDays(_monthTaskModel.CurrentDate, width, height + sizeY / 2, sizeX, sizeY);
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
            _monthTaskModel.CurrentDate = _monthTaskModel.CurrentDate.AddMonths(-1);

            LoadTasksArray();
            LoadButtonsOfDays();
            LoadMonthAndYearLabels();
            LoadToolTips();
            HighlightButtons();
        }

        private void OnButtonOfArrowRightMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            _monthTaskModel.CurrentDate = _monthTaskModel.CurrentDate.AddMonths(1);

            LoadTasksArray();
            LoadButtonsOfDays();
            LoadMonthAndYearLabels();
            LoadToolTips();
            HighlightButtons();
        }
        #endregion
    }

}
