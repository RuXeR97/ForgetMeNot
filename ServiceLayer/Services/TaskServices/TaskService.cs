using Google.Apis.Requests;
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

        public void Add(string calendarId, IDirectResponseSchema body)
        {
            // method to validate model
            _taskRepository.Add(calendarId, body);
        }

        public void Update(IDirectResponseSchema newCalendarEvent, string calendarId, string oldEventId)
        {
            _taskRepository.Update(newCalendarEvent, calendarId, oldEventId);
        }


        public void Delete(string calendarId, string eventId)
        {
            // method to validate model
            _taskRepository.Delete(calendarId, eventId);
        }

        public IDirectResponseSchema GetAllEvents()
        {
            return _taskRepository.GetAllEvents();
        }

        public IDirectResponseSchema GetEventsByMonth(DateTime month)
        {
            return _taskRepository.GetEventsByMonth(month);
        }

        public List<string> GetCalendarsList()
        {
            return _taskRepository.GetCalendarsList();
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
