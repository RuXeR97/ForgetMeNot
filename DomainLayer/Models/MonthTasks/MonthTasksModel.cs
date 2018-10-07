using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace DomainLayer.Models.MonthTasks
{
    public class MonthTasksModel : IMonthTasksModel
    {
        public DateTime CurrentDate { get; set; }

        public SortedDictionary<DateTime, List<TaskModel>> PreviousMonthTasks { get; set; }
        public SortedDictionary<DateTime, List<TaskModel>> CurrentMonthTasks { get; set; }
        public SortedDictionary<DateTime, List<TaskModel>> NextMonthTasks { get; set; }
    }



    //public string[] GetArrayOfCurrentTasks(DateTime date)
    //{
    //    string[] arrayOfStringTasks = null;
    //    int counter = 0;
    //    List<Task.TaskModel> Tasks = (List<Task.TaskModel>)CurrentMonthTasks.FindAll(i => i.TimeOfCreation.Month == date.Month).OrderBy(i => i.TimeOfCreation);
    //    DateTime previousDate = DateTime.MinValue;
    //    string finalString = null;

    //    foreach (var task in Tasks)
    //    {
    //        if (previousDate != task.TimeOfCreation && previousDate != DateTime.MinValue)
    //        {
    //            arrayOfStringTasks[counter] += Tasks;
    //            previousDate = task.TimeOfCreation;
    //            finalString = null;
    //        }
    //        else
    //        {
    //            finalString += task.Title;
    //        }
    //        counter++;
    //    }
    //    if (arrayOfStringTasks == null && counter == 1)
    //    {
    //        arrayOfStringTasks[0] = Tasks.First().Title;
    //    }

    //    return arrayOfStringTasks;
    //}
}
