using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using ServiceLayer.Services.TaskServices;
using System;
using System.IO;
using System.Linq;
namespace InfrastructureLayer.DataAccess.Repositories.Local.Task
{
    public class TaskLocalRepository : ITaskRepository
    {
        private string path;
        private string fileName;

        public TaskLocalRepository(string userLogin)
        {
            fileName = userLogin + "Tasks.ics";

            // change later
            path = fileName;
        }

        public void Add(IRecurringComponent taskModel)
        {
            throw new NotImplementedException();
        }

        public void AddRange()
        {

        }

        // done
        public void Delete(IRecurringComponent calendarEvent)
        {
            var calendarEvents = GetAll().Remove((CalendarEvent)calendarEvent);
            //Calendar calendar;
            //var veventTest = File.WriteAllText(path);
            //var calendar = Calendar.
        }

        public void DeleteById(int taskModelId)
        {
            throw new NotImplementedException();
        }

        // done
        public IUniqueComponentList<CalendarEvent> GetAll()
        {
            var veventTest = File.ReadAllText(path);
            var calendar = Calendar.Load(veventTest);
            var calendarEvents = calendar.Events;

            return calendarEvents;
        }

        // done
        public IUniqueComponentList<CalendarEvent> GetByMonth(DateTime date)
        {
            var taskModels = GetAll().Where(i => i.DtStart.Month == date.Month);
            return (UniqueComponentListProxy<CalendarEvent>)taskModels;
        }

        public void Update(IRecurringComponent calendarEvent, IRecurringComponent newCalendarEvent)
        {
            throw new NotImplementedException();
        }
    }
}
