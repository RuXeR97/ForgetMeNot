using DomainLayer.Models.Task;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.TaskServices
{
    public class TaskServices : ITaskService, ITaskRepository
    {
        private ITaskRepository _taskRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TaskServices(ITaskRepository taskRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _taskRepository = taskRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaskModel GetByTimeOfCreation(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Update(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(ITaskModel taskModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(taskModel);
            ValidateTaskTimeOfCreation(taskModel);
        }

        public void ValidateModelDataAnnotations(ITaskModel taskModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(taskModel);
        }

        public void ValidateTaskTimeOfCreation(ITaskModel taskModel)
        {
            // some code to validate timeofcreation
        }
    }
}
