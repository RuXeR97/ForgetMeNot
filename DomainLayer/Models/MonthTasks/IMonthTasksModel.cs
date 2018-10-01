using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace DomainLayer.Models.MonthTasks
{
    public interface IMonthTasksModel
    {
        DateTime CurrentDate { get; set; }
        List<TaskModel> PreviousMonthTasks { get; set; }
        List<TaskModel> CurrentMonthTasks { get; set; }
        List<TaskModel> NextMonthTasks { get; set; }
    }
}