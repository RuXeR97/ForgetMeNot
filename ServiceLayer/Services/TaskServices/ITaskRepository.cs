using Google.Apis.Calendar.v3.Data;
using Google.Apis.Requests;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskRepository
    {
        void Add(IDirectResponseSchema calendarEvent);
        void Update(IDirectResponseSchema calendarEvent, IDirectResponseSchema newCalendarEvent);
        void Delete(IDirectResponseSchema calendarEvent);
        void DeleteById(int calendarEventId);
        IDirectResponseSchema GetAllEvents();
        IDirectResponseSchema GetEventsByMonth(DateTime? month);

    }
}
