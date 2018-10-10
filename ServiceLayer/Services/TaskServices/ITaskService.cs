using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using System;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskService
    {
        void Add(IRecurringComponent taskModel);
        void Update(IRecurringComponent taskModel);
        void Delete(IRecurringComponent taskModel);
        void DeleteById(int taskModelId);
        IUniqueComponentList<CalendarEvent> GetAll();
        IUniqueComponentList<CalendarEvent> GetByMonth(DateTime month);

        void ValidateModel(IRecurringComponent taskModel);
        void ValidateModelDataAnnotations(IRecurringComponent taskModel);
        void ValidateTaskTimeOfCreation(IRecurringComponent taskModel);
    }
}
