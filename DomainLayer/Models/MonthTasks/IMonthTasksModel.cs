using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace DomainLayer.Models.MonthTasks
{
    public interface IMonthTasksModel
    {
        DateTime CurrentDate { get; set; }

        Dictionary<DateTime, List<TaskModel>> GetPreviousMonthTasks();
        Dictionary<DateTime, List<TaskModel>> GetCurrentMonthTasks();
        Dictionary<DateTime, List<TaskModel>> GetNextMonthTasks();
        Dictionary<DateTime, List<TaskModel>> GetAll();

        void Add(ITaskModel task);
        void AddRange(Dictionary<DateTime, List<TaskModel>> tasksDictionaryOfLists);
        void Edit(int idTask, ITaskModel newTask);
        void Edit(ITaskModel oldTask, ITaskModel newTask);
        void Delete(ITaskModel task);
        void Delete(int idTask);
        void DeleteRange(Dictionary<DateTime, List<TaskModel>> tasks);
    }
}