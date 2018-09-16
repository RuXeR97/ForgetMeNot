using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Task
{
    interface ITaskRepository
    {
        void Add(ITaskModel taskModel);
        void Update(ITaskModel taskModel);
        void Delete(ITaskModel taskModel);
        void DeleteById(int taskModelId);
        IEnumerable<ITaskModel> GetAll();
        TaskModel GetById(int id);
        TaskModel GetByCreationDate(DateTime creationDate);
    }
}
