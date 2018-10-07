﻿using DomainLayer.Models.MonthTasks;
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
            tasksArray = GetCurrentMonthTasksToArray();

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

        private IMonthTasksModel GetDataFromLocalRepository()
        {
            IMonthTasksModel _monthTaskModel = new MonthTasksModel();

            _monthTaskModel.CurrentDate = CurrentDate;
            _monthTaskModel.PreviousMonthTasks = _taskService.GetByMonth(_monthTaskModel.CurrentDate.AddMonths(-1));
            _monthTaskModel.CurrentMonthTasks = _taskService.GetByMonth(_monthTaskModel.CurrentDate);
            _monthTaskModel.NextMonthTasks = _taskService.GetByMonth(_monthTaskModel.CurrentDate.AddMonths(1));

            return _monthTaskModel;
        }

        private string[] GetCurrentMonthTasksToArray()
        {
            int daysInMonth = DateTime.DaysInMonth(_monthTaskModel.CurrentDate.Year, _monthTaskModel.CurrentDate.Month);
            string[] arrayOfTasks = new string[daysInMonth];

            string finalTask = null;
            for (int i = 0; i < arrayOfTasks.Length; i++)
            {
                List<TaskModel> taskModelsPerDay = _monthTaskModel.CurrentMonthTasks.
                    SelectMany(x => x.Value).Where(y => y.EndTime.Day == i).ToList();
                foreach (var taskModel in taskModelsPerDay)
                {
                    finalTask += taskModel.Title + Environment.NewLine;
                }

                //if (Regex.Matches(finalTask, @"[a-zA-Z]").Count > 0)
                arrayOfTasks[i] = finalTask;
                finalTask = null;
            }
            return arrayOfTasks;
        }
    }

}
