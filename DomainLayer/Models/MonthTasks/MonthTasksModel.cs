using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLayer.Models.MonthTasks
{
    public class MonthTasksModel : IMonthTasksModel
    {
        public DateTime CurrentDate { get; set; }

        private Dictionary<DateTime, List<TaskModel>> PreviousMonthTasks { get; set; }
        private Dictionary<DateTime, List<TaskModel>> CurrentMonthTasks { get; set; }
        private Dictionary<DateTime, List<TaskModel>> NextMonthTasks { get; set; }

        private Dictionary<DateTime, List<TaskModel>> MonthTasks;

        public MonthTasksModel()
        {
            MonthTasks = new Dictionary<DateTime, List<TaskModel>>();
        }

        public void Add(ITaskModel task)
        {
            if (MonthTasks.Any(i => i.Value.Any(j => j == task)))
            {
                // throw new ExistingItemException();
            }
            else
            {
                if (MonthTasks.Any(i => i.Key.ToShortDateString() == task.StartTime.ToShortDateString()))
                {
                    foreach (var item in MonthTasks)
                    {
                        if (item.Key.ToShortDateString() == task.StartTime.ToShortDateString())
                        {
                            item.Value.Add((TaskModel)task);
                        }
                    }
                }
                else
                {
                    MonthTasks.Add(task.StartTime, new List<TaskModel>() { (TaskModel)task });
                }


            }
        }


        public void AddRange(Dictionary<DateTime, List<TaskModel>> tasksDictionaryOfLists)
        {
            foreach (var item in tasksDictionaryOfLists)
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

        public void DeleteRange(Dictionary<DateTime, List<TaskModel>> tasksDictionaryOfLists)
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

        public Dictionary<DateTime, List<TaskModel>> GetCurrentMonthTasks()
        {
            var currentMonthsTasks = MonthTasks.Select(i => i).
                Where(j => j.Key.Date.ToShortDateString() == DateTime.Now.ToShortDateString()).
                ToDictionary(i => i.Key, j => j.Value);
            return currentMonthsTasks;
        }

        public Dictionary<DateTime, List<TaskModel>> GetNextMonthTasks()
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, List<TaskModel>> GetPreviousMonthTasks()
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, List<TaskModel>> GetAll()
        {
            return MonthTasks;
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
