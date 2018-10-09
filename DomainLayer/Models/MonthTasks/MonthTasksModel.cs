using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLayer.Models.MonthTasks
{
    public class MonthTasksModel : IMonthTasksModel
    {
        public DateTime CurrentDate { get; set; }

        private SortedDictionary<DateTime, List<TaskModel>> PreviousMonthTasks { get; set; }
        private SortedDictionary<DateTime, List<TaskModel>> CurrentMonthTasks { get; set; }
        private SortedDictionary<DateTime, List<TaskModel>> NextMonthTasks { get; set; }

        private SortedDictionary<DateTime, List<TaskModel>> MonthTasks;

        public MonthTasksModel()
        {
            MonthTasks = new SortedDictionary<DateTime, List<TaskModel>>();
        }

        public void Add(ITaskModel task)
        {
            if (MonthTasks.Any(i => i.Value.Any(j => j == task)))
            {
                // throw new ExistingItemException();
            }
            else
            {
                //MonthTasks.
            }
        }


        public void AddRange(SortedDictionary<DateTime, List<TaskModel>> tasksSortedDictionaryOfLists)
        {
            foreach (var item in tasksSortedDictionaryOfLists)
            {
                MonthTasks.Add(item.Key, item.Value);
            }
        }

        public void Delete(ITaskModel task)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idTask)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(SortedDictionary<DateTime, List<TaskModel>> tasksSortedDictionaryOfLists)
        {
            throw new NotImplementedException();
        }

        public void Edit(int idTask, ITaskModel newTask)
        {
            throw new NotImplementedException();
        }

        public void Edit(ITaskModel oldTask, ITaskModel newTask)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetCurrentMonthTasks()
        {
            var currentMonthTasks = MonthTasks.Select(i => i).Where(j => j.Key.Date.ToShortDateString() == DateTime.Now.ToShortDateString());
            return (SortedDictionary<DateTime, List<TaskModel>>)currentMonthTasks;
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetNextMonthTasks()
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetPreviousMonthTasks()
        {
            throw new NotImplementedException();
        }
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
