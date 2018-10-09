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
        // done
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
        // done
        public void AddRange(Dictionary<DateTime, List<TaskModel>> tasksDictionaryOfLists)
        {
            foreach (var item in tasksDictionaryOfLists)
            {
                MonthTasks.Add(item.Key, item.Value);
            }
        }

        public void Edit(int idTask, ITaskModel newTask)
        {
            throw new NotImplementedException();
        }

        public void Edit(ITaskModel oldTask, ITaskModel newTask)
        {
            var taskModels = MonthTasks.FirstOrDefault(i => i.Value.Any(j => j.Equals(oldTask)));
            if (taskModels.Equals(default(KeyValuePair<DateTime, List<TaskModel>>)))
            {
                // throw NotExistingException
            }
            else
            {
                var taskModel = taskModels.Value.FirstOrDefault(j => j.Equals(oldTask));
                var oldItem = taskModels.Value.FirstOrDefault(i => i.Equals((TaskModel)oldTask));

                if (oldItem == null)
                {
                    // throw NotExistingException
                }
                else
                {
                    oldItem = (TaskModel)newTask;
                }
            }
        }
        // done
        public void Delete(ITaskModel task)
        {
            var taskModels = MonthTasks.FirstOrDefault(i => i.Value.Any(j => j.Equals(task)));
            if (!taskModels.Value.Remove((TaskModel)task))
            {
                // throw NotExistingException
            }

            //if (MonthTasks.Any(i => i.Value.Any(j => j == task)))
            //{
            //    if (MonthTasks.Any(i => i.Key.ToShortDateString() == task.StartTime.ToShortDateString()))
            //    {
            //        foreach (var item in MonthTasks)
            //        {
            //            if (item.Key.ToShortDateString() == task.StartTime.ToShortDateString())
            //            {
            //                item.Value.Remove((TaskModel)task);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    // throw NotExistingException
            //}
        }
        // done
        public void Delete(int taskId)
        {
            var taskModels = MonthTasks.FirstOrDefault(i => i.Value.Any(j => j.TaskId == taskId));
            var taskModel2 = taskModels.Value.FirstOrDefault(j => j.TaskId == taskId);
            if (!taskModels.Value.Remove(taskModel2))
            {
                // throw NotExistingException
            }
        }
        // done
        public void DeleteRange(Dictionary<DateTime, List<TaskModel>> tasksDictionaryOfLists)
        {
            foreach (var item in tasksDictionaryOfLists)
            {
                if (!MonthTasks.Remove(item.Key))
                {
                    // throw NotExistingException
                }
            }
        }
        // done
        public Dictionary<DateTime, List<TaskModel>> GetPreviousMonthTasks()
        {
            var currentMonthsTasks = MonthTasks.Select(i => i).
                Where(j => j.Key.Date.ToShortDateString() == CurrentDate.AddMonths(-1).ToShortDateString()).
                ToDictionary(i => i.Key, j => j.Value);
            return currentMonthsTasks;
        }
        // done
        public Dictionary<DateTime, List<TaskModel>> GetCurrentMonthTasks()
        {
            var currentMonthsTasks = MonthTasks.Select(i => i).
                Where(j => j.Key.Date.ToShortDateString() == CurrentDate.ToShortDateString()).
                ToDictionary(i => i.Key, j => j.Value);
            return currentMonthsTasks;
        }
        // done
        public Dictionary<DateTime, List<TaskModel>> GetNextMonthTasks()
        {
            var currentMonthsTasks = MonthTasks.Select(i => i).
                Where(j => j.Key.Date.ToShortDateString() == CurrentDate.AddMonths(1).ToShortDateString()).
                ToDictionary(i => i.Key, j => j.Value);
            return currentMonthsTasks;
        }
        // done
        public Dictionary<DateTime, List<TaskModel>> GetAll()
        {
            return MonthTasks;
        }

    }
}
