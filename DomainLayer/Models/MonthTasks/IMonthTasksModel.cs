using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace DomainLayer.Models.MonthTasks
{
    public interface IMonthTasksModel
    {
        DateTime CurrentDate { get; set; }
        SortedDictionary<DateTime, List<TaskModel>> PreviousMonthTasks { get; set; }
        SortedDictionary<DateTime, List<TaskModel>> CurrentMonthTasks { get; set; }
        SortedDictionary<DateTime, List<TaskModel>> NextMonthTasks { get; set; }
    }
}