using Google.Apis.Requests;
using System;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskService
    {
        void Add(string calendarId, string text);
        void Update(IDirectResponseSchema newCalendarEvent, string calendarId, string oldEventId);
        void Delete(string calendarId, string eventId);
        IDirectResponseSchema GetAllEvents();
        IDirectResponseSchema GetEventsByMonth(DateTime month);

        void ValidateModel(IDirectResponseSchema taskModel);
        void ValidateModelDataAnnotations(IDirectResponseSchema taskModel);
        void ValidateTaskTimeOfCreation(IDirectResponseSchema taskModel);
    }
}
