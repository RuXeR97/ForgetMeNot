namespace DomainLayer.Models.MonthTasks
{
    public class MonthTasksModel
    {
        //    public DateTime CurrentDate { get; set; }

        //    //private IUniqueComponentList<CalendarEvent> PreviousMonthTasks { get; set; }
        //    //private IUniqueComponentList<CalendarEvent> CurrentMonthTasks { get; set; }
        //    //private IUniqueComponentList<CalendarEvent> NextMonthTasks { get; set; }

        //    //private IUniqueComponentList<CalendarEvent> MonthTasks;

        //    public MonthTasksModel()
        //    {
        //        MonthTasks = new IUniqueComponentList<CalendarEvent>();
        //    }
        //    // done
        //    public void Add(Ical.Net.CalendarComponents.RecurringComponent task)
        //    {
        //        DateTime[] dateTimes = task.EndTime.GetDatesBetween(task.StartTime);
        //        foreach (var date in dateTimes)
        //        {
        //            if (MonthTasks.Any(i => i.Key.ToShortDateString() == date.ToShortDateString()))
        //            {
        //                var selectedMonthTaskList = MonthTasks.
        //                    First(i => i.Key.ToShortDateString() == date.ToShortDateString()).
        //                    Value.
        //                    Where(j => date.IsInOrBetween(task.StartTime, task.EndTime)).ToList();

        //                selectedMonthTaskList.Add((TaskModel)task);
        //                //selectedMonthTaskList.Add((TaskModel)task);
        //            }
        //            else
        //            {
        //                MonthTasks.
        //                    Add(new DateTime(date.Year, date.Month, date.Day), new List<TaskModel>() { (TaskModel)task });
        //            }
        //        }




        //        //if (MonthTasks.Any(i => i.Value.Any(j => j == task)))
        //        //{
        //        //    // throw new ExistingItemException();
        //        //}
        //        //else
        //        //{
        //        //    DateTime[] dateTimes = task.EndTime.GetDatesBetween(task.StartTime);
        //        //    foreach (var date in dateTimes)
        //        //    {
        //        //        if (MonthTasks.Any(i => i.Key.IsInOrBetween(task.StartTime, task.EndTime)))
        //        //        {
        //        //            foreach (var item in MonthTasks)
        //        //            {
        //        //                //if (item.Key.ToShortDateString() == date.ToShortDateString())
        //        //                //{

        //        //                if (item.Key.IsInOrBetween(date, item.Key) && !item.Value.Contains(task))
        //        //                {
        //        //                    item.Value.Add((TaskModel)task);
        //        //                }

        //        //                //}
        //        //            }
        //        //        }
        //        //        else
        //        //        {
        //        //            MonthTasks.Add(new DateTime(date.Year, date.Month, date.Day), new List<TaskModel>() { (TaskModel)task });
        //        //        }
        //        //    }
        //        //}
        //    }
        //    // done
        //    public void AddRange(IUniqueComponentList<CalendarEvent> tasksDictionaryOfLists)
        //    {
        //        foreach (var item in tasksDictionaryOfLists)
        //        {
        //            MonthTasks.Add(item.Key, item.Value);
        //        }
        //    }

        //    public void Edit(int idTask, Ical.Net.CalendarComponents.RecurringComponent newTask)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Edit(Ical.Net.CalendarComponents.RecurringComponent oldTask, Ical.Net.CalendarComponents.RecurringComponent newTask)
        //    {
        //        var taskModels = MonthTasks.FirstOrDefault(i => i.Value.Any(j => j.Equals(oldTask)));
        //        if (taskModels.Equals(default(KeyValuePair<DateTime, List<TaskModel>>)))
        //        {
        //            // throw NotExistingException
        //        }
        //        else
        //        {
        //            var taskModel = taskModels.Value.FirstOrDefault(j => j.Equals(oldTask));
        //            var oldItem = taskModels.Value.FirstOrDefault(i => i.Equals((TaskModel)oldTask));

        //            if (oldItem == null)
        //            {
        //                // throw NotExistingException
        //            }
        //            else
        //            {
        //                oldItem = (TaskModel)newTask;
        //            }
        //        }
        //    }
        //    // done
        //    public void Delete(Ical.Net.CalendarComponents.RecurringComponent task)
        //    {
        //        var taskModels = MonthTasks.FirstOrDefault(i => i.Value.Any(j => j.Equals(task)));
        //        if (!taskModels.Value.Remove((TaskModel)task))
        //        {
        //            // throw NotExistingException
        //        }

        //        //if (MonthTasks.Any(i => i.Value.Any(j => j == task)))
        //        //{
        //        //    if (MonthTasks.Any(i => i.Key.ToShortDateString() == task.StartTime.ToShortDateString()))
        //        //    {
        //        //        foreach (var item in MonthTasks)
        //        //        {
        //        //            if (item.Key.ToShortDateString() == task.StartTime.ToShortDateString())
        //        //            {
        //        //                item.Value.Remove((TaskModel)task);
        //        //            }
        //        //        }
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    // throw NotExistingException
        //        //}
        //    }
        //    // done
        //    public void Delete(int taskId)
        //    {
        //        var taskModels = MonthTasks.FirstOrDefault(i => i.Value.Any(j => j.TaskId == taskId));
        //        var taskModel2 = taskModels.Value.FirstOrDefault(j => j.TaskId == taskId);
        //        if (!taskModels.Value.Remove(taskModel2))
        //        {
        //            // throw NotExistingException
        //        }
        //    }
        //    // done
        //    public void DeleteRange(IUniqueComponentList<CalendarEvent> tasksDictionaryOfLists)
        //    {
        //        foreach (var item in tasksDictionaryOfLists)
        //        {
        //            if (!MonthTasks.Remove(item.Key))
        //            {
        //                // throw NotExistingException
        //            }
        //        }
        //    }
        //    // done
        //    public IUniqueComponentList<CalendarEvent> GetPreviousMonthTasks()
        //    {
        //        var currentMonthsTasks = MonthTasks.Select(i => i).
        //            Where(j => j.Key.Date.ToShortDateString() == CurrentDate.AddMonths(-1).ToShortDateString()).
        //            ToDictionary(i => i.Key, j => j.Value);
        //        return currentMonthsTasks;
        //    }
        //    // done
        //    public IUniqueComponentList<CalendarEvent> GetCurrentMonthTasks()
        //    {
        //        var currentMonthsTasks = MonthTasks.Select(i => i).
        //            Where(j => j.Key.Date.Year == CurrentDate.Year && j.Key.Date.Month == CurrentDate.Month).
        //            ToDictionary(i => i.Key, j => j.Value);
        //        return currentMonthsTasks;
        //    }
        //    // done
        //    public IUniqueComponentList<CalendarEvent> GetNextMonthTasks()
        //    {
        //        var currentMonthsTasks = MonthTasks.Select(i => i).
        //            Where(j => j.Key.Date.ToShortDateString() == CurrentDate.AddMonths(1).ToShortDateString()).
        //            ToDictionary(i => i.Key, j => j.Value);
        //        return currentMonthsTasks;
        //    }
        //    // done
        //    public IUniqueComponentList<CalendarEvent> GetAll()
        //    {
        //        return MonthTasks;
        //    }

    }
}
