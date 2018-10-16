using Google.Apis.Calendar.v3.Data;
using Google.Apis.Requests;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskRepository
    {
        void Add(string calendarId, string text);
        void Update(IDirectResponseSchema newCalendarEvent, string calendarId, string oldEventId);
        void Delete(string calendarId, string eventId);
        IDirectResponseSchema GetAllEvents();
        IDirectResponseSchema GetEventsByMonth(DateTime? month);

    }
}
