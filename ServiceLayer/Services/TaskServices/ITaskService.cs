using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskService
    {
        void Add(ITaskModel taskModel);
        void Update(ITaskModel taskModel);
        void Delete(ITaskModel taskModel);
        void DeleteById(int taskModelId);
        SortedDictionary<DateTime, List<TaskModel>> GetAll();
        SortedDictionary<DateTime, List<TaskModel>> GetByMonth(DateTime month);
        ITaskModel GetById(int id);
        SortedDictionary<DateTime, List<TaskModel>> GetByCreationDate(DateTime creationDate);
        void ValidateModel(ITaskModel taskModel);
        void ValidateModelDataAnnotations(ITaskModel taskModel);
        void ValidateTaskTimeOfCreation(ITaskModel taskModel);
    }
}
