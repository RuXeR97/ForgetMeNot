using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using System;
using System.IO;
using System.Linq;
namespace InfrastructureLayer.DataAccess.Repositories.Local.Task
{
    public class TaskLocalRepository : ServiceLayer.Services.TaskServices.ITaskRepository
    {
        private string path;
        private string fileName;

        public TaskLocalRepository(string userLogin)
        {
            fileName = userLogin + "Tasks.ics";

            // change later
            path = fileName;

            //DomainLayer.Models.MonthTasks.IMonthTasksModel mod = new DomainLayer.Models.MonthTasks.MonthTasksModel();

            //List<TaskModel> lol = new List<TaskModel>();
            //lol.Add(new TaskModel()
            //{
            //    TaskId = 1,
            //    Description = "asd",
            //    StartTime = DateTime.Now.AddHours(-3),
            //    EndTime = DateTime.Now.AddHours(1),
            //    Title = "LOLEK"
            //});
            //List<TaskModel> lol2 = new List<TaskModel>();
            //TaskModel taskModel2 = new TaskModel()
            //{
            //    TaskId = 2,
            //    Description = "Test Description 2",
            //    StartTime = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString()),
            //    EndTime = DateTime.Parse(DateTime.Now.AddDays(-1).AddHours(1).ToShortDateString()),
            //    Title = "Test Task 2"
            //};

            //TaskModel taskModel3 = new TaskModel()
            //{
            //    TaskId = 3,
            //    Description = "Test Description 3",
            //    StartTime = DateTime.Parse(DateTime.Now.ToShortDateString()),
            //    EndTime = DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString()),
            //    Title = "Test Task 3"
            //};
            //mod.Add(taskModel2);
            //mod.Add(taskModel3);

            //File.WriteAllText(path, JsonConvert.SerializeObject(mod.GetAll(), Formatting.Indented));
        }

        public void Add(Ical.Net.CalendarComponents.RecurringComponent taskModel)
        {
            throw new NotImplementedException();
        }

        public void AddRange()
        {
            //var now = DateTime.Now;
            //var later = now.AddHours(1);

            ////Repeat daily for 5 days
            //var rrule = new RecurrencePattern(FrequencyType.Daily, 1) { Count = 5 };

            //var e = new CalendarEvent
            //{
            //    Start = new CalDateTime(now),
            //    End = new CalDateTime(later),
            //    RecurrenceRules = new List<RecurrencePattern> { rrule },
            //};

            //var calendar = new Calendar();
            //calendar.Events.Add(e);

            //var serializer = new CalendarSerializer();
            //var serializedCalendar = serializer.SerializeToString(calendar);
        }

        public void Delete(RecurringComponent taskModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int taskModelId)
        {
            throw new NotImplementedException();
        }

        public IUniqueComponentList<CalendarEvent> GetAll()
        {
            var veventTest = File.ReadAllText(path);
            var calendar = Calendar.Load(veventTest);
            var calendarEvents = calendar.Events;

            return calendarEvents;
        }

        public IUniqueComponentList<CalendarEvent> GetByMonth(DateTime date)
        {
            var taskModels = GetAll().Where(i => i.DtStart.Month == date.Month);

            return (UniqueComponentListProxy<CalendarEvent>)taskModels;
        }

        public void Update(RecurringComponent taskModel)
        {
            throw new NotImplementedException();
        }
    }
}
