using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using System;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskService
    {
        void Add(RecurringComponent taskModel);
        void Update(RecurringComponent taskModel);
        void Delete(RecurringComponent taskModel);
        void DeleteById(int taskModelId);
        IUniqueComponentList<CalendarEvent> GetAll();
        IUniqueComponentList<CalendarEvent> GetByMonth(DateTime month);

        void ValidateModel(RecurringComponent taskModel);
        void ValidateModelDataAnnotations(RecurringComponent taskModel);
        void ValidateTaskTimeOfCreation(RecurringComponent taskModel);
    }
}
