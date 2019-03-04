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
            try
            {
                _taskRepository.Add(calendarId, body);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(IDirectResponseSchema newCalendarEvent, string calendarId, string oldEventId)
        {
            try
            {
                _taskRepository.Update(newCalendarEvent, calendarId, oldEventId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(string calendarId, string eventId)
        {
            try
            {
                _taskRepository.Delete(calendarId, eventId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IDirectResponseSchema GetAllEvents()
        {
            return _taskRepository.GetAllEvents();
        }

        public IDirectResponseSchema GetEventsByMonth(DateTime month)
        {
            try
            {
                return _taskRepository.GetEventsByMonth(month);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetCalendarsList()
        {
            try
            {
                return _taskRepository.GetCalendarsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
