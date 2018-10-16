using Google.Apis.Requests;
using ServiceLayer.CommonServices;
using System;

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

        public void Add(IDirectResponseSchema taskModel)
        {
            // method to validate model
            _taskRepository.Add(taskModel);
        }

        public void Delete(IDirectResponseSchema taskModel)
        {
            // method to validate model
            _taskRepository.Delete(taskModel);
        }

        public void DeleteById(int taskModelId)
        {
            _taskRepository.DeleteById(taskModelId);
        }

        public IDirectResponseSchema GetAllEvents()
        {
            return _taskRepository.GetAllEvents();
        }

        public IDirectResponseSchema GetEventsByMonth(DateTime month)
        {
            return _taskRepository.GetByMonth(month);
        }

        public void ValidateModel(IDirectResponseSchema taskModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(taskModel);
            ValidateTaskTimeOfCreation(taskModel);
        }

        public void ValidateModelDataAnnotations(IDirectResponseSchema taskModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(taskModel);
        }

        public void ValidateTaskTimeOfCreation(IDirectResponseSchema taskModel)
        {
            // some code to validate timeofcreation
        }
    }
}
