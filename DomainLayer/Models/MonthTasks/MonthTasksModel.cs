using System;
using System.Collections.Generic;

namespace DomainLayer.Models.MonthTasks
{
    public class MonthTasksModel : IMonthTasksModel
    {
        public DateTime CurrentDate { get; set; }

        public List<Task.TaskModel> PreviousMonthTasks { get; set; }
        public List<Task.TaskModel> CurrentMonthTasks { get; set; }
        public List<Task.TaskModel> NextMonthTasks { get; set; }
    }
}
