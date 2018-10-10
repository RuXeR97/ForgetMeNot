using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using System;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskRepository
    {
        void Add(RecurringComponent taskModel);
        void Update(RecurringComponent taskModel);
        void Delete(RecurringComponent taskModel);
        void DeleteById(int taskModelId);
        IUniqueComponentList<CalendarEvent> GetAll();
        IUniqueComponentList<CalendarEvent> GetByMonth(DateTime month);

    }
}
