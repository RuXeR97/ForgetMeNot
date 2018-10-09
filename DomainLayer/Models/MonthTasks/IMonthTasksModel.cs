using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace DomainLayer.Models.MonthTasks
{
    public interface IMonthTasksModel
    {
        DateTime CurrentDate { get; set; }

        SortedDictionary<DateTime, List<TaskModel>> GetPreviousMonthTasks();
        SortedDictionary<DateTime, List<TaskModel>> GetCurrentMonthTasks();
        SortedDictionary<DateTime, List<TaskModel>> GetNextMonthTasks();

        void Add(ITaskModel task);
        void AddRange(SortedDictionary<DateTime, List<TaskModel>> tasksSortedDictionaryOfLists);
        void Edit(int idTask, ITaskModel newTask);
        void Edit(ITaskModel oldTask, ITaskModel newTask);
        void Delete(ITaskModel task);
        void Delete(int idTask);
        void DeleteRange(SortedDictionary<DateTime, List<TaskModel>> tasks);
    }
}