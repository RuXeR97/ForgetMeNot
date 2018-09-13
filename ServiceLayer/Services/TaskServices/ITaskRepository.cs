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
        IEnumerable<TaskModel> GetAll();
        TaskModel GetByTimeOfCreation(DateTime date);
        TaskModel GetById(int id);

    }
}
