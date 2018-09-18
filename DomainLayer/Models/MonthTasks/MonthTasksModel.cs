using System;
using System.Collections.Generic;

namespace DomainLayer.Models.MonthTasks
{
    public class MonthTasksModel : IMonthTasksModel
    {
        public DateTime CurrentDate { get; set; }

        public List<Task.TaskModel> Tasks { get; set; }
    }
}
