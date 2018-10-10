using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
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

        public void Add(IRecurringComponent taskModel)
        {
            // method to validate model
            _taskRepository.Add(taskModel);
        }

        public void Delete(IRecurringComponent taskModel)
        {
            // method to validate model
            _taskRepository.Delete(taskModel);
        }

        public void DeleteById(int taskModelId)
        {
            _taskRepository.DeleteById(taskModelId);
        }

        public IUniqueComponentList<CalendarEvent> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public IUniqueComponentList<CalendarEvent> GetByMonth(DateTime month)
        {
            return _taskRepository.GetByMonth(month);
        }

        public void Update(IRecurringComponent taskModel)
        {
            _taskRepository.Update(taskModel);
        }

        public void ValidateModel(IRecurringComponent taskModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(taskModel);
            ValidateTaskTimeOfCreation(taskModel);
        }

        public void ValidateModelDataAnnotations(IRecurringComponent taskModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(taskModel);
        }

        public void ValidateTaskTimeOfCreation(IRecurringComponent taskModel)
        {
            // some code to validate timeofcreation
        }
    }
}
