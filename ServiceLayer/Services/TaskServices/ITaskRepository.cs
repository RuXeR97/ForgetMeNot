using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskRepository
    {
        void Add(ITaskModel taskModel);
        void Update(ITaskModel taskModel);
        void Delete(ITaskModel taskModel);
        void DeleteById(int taskModelId);
        Dictionary<DateTime, List<TaskModel>> GetAll();
        Dictionary<DateTime, List<TaskModel>> GetByMonth(DateTime month);
        ITaskModel GetById(int id);
        Dictionary<DateTime, List<TaskModel>> GetByCreationDate(DateTime creationDate);

    }
}
