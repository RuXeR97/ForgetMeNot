using DomainLayer.Models.Task;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.TaskServices
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TaskService(ITaskRepository taskRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _taskRepository = taskRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(ITaskModel taskModel)
        {
            // method to validate model
            _taskRepository.Add(taskModel);
        }

        public void Delete(ITaskModel taskModel)
        {
            // method to validate model
            _taskRepository.Delete(taskModel);
        }

        public void DeleteById(int taskModelId)
        {
            _taskRepository.DeleteById(taskModelId);
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetByCreationDate(DateTime creationDate)
        {
            return _taskRepository.GetByCreationDate(creationDate);
        }

        public ITaskModel GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetByMonth(DateTime month)
        {
            var taskModels = _taskRepository.GetByMonth(month);
            return taskModels;
        }

        public void Update(ITaskModel taskModel)
        {
            _taskRepository.Update(taskModel);
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
