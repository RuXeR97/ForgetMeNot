using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using System;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskRepository
    {
        void Add(IRecurringComponent calendarEvent);
        void Update(IRecurringComponent calendarEvent, IRecurringComponent newCalendarEvent);
        void Delete(IRecurringComponent calendarEvent);
        void DeleteById(int calendarEventId);
        IUniqueComponentList<CalendarEvent> GetAll();
        IUniqueComponentList<CalendarEvent> GetByMonth(DateTime month);

    }
}
