using ServiceLayer.Services.TaskServices;
using System;
using System.IO;
using System.Linq;
namespace InfrastructureLayer.DataAccess.Repositories.Local.Task
{
    public class TaskLocalRepository
    {
        //private string path;
        //private string fileName;
        //private string textFromFile;

        //public TaskLocalRepository(string userLogin)
        //{
        //    fileName = userLogin + "Tasks.ics";

        //    // change later
        //    path = fileName;
        //}

        //public void Add(IRecurringComponent taskModel)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddRange()
        //{

        //}

        //// done
        //public void Delete(IRecurringComponent calendarEvent)
        //{
        //    string[] lines = textFromFile
        //    .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        //    int counter = 11;
        //    string[] newArray = new string[lines.Length - counter];

        //    int idOfRowToDelete = Array.FindIndex(lines, i => i.Contains(calendarEvent.Uid.ToString()));
        //    int minIndex = idOfRowToDelete - 4;

        //    bool omitLines = false;

        //    // creating new array without specified event
        //    textFromFile = null;
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        if (i == minIndex)
        //        {
        //            omitLines = true;
        //        }

        //        if (omitLines)
        //        {
        //            if (i == lines.Length - 11)
        //            {
        //                break;
        //            }

        //            textFromFile += lines[i + 11] + Environment.NewLine;
        //            newArray[i] = lines[i + 11];
        //        }
        //        else
        //        {
        //            textFromFile += lines[i] + Environment.NewLine;
        //            newArray[i] = lines[i];
        //        }
        //    }
        //    var calendar = Calendar.Load(textFromFile);
        //    var calendarEvents = calendar.Events;
        //    lines = newArray;
        //}

        //public void DeleteById(int taskModelId)
        //{
        //    throw new NotImplementedException();
        //}

        //// done
        //public IUniqueComponentList<CalendarEvent> GetAll()
        //{
        //    textFromFile = File.ReadAllText(path);
        //    var calendar = Calendar.Load(textFromFile);
        //    var calendarEvents = calendar.Events;

        //    var test = calendarEvents.FirstOrDefault();
        //    Delete(test);

        //    return calendarEvents;
        //}

        //// done
        //public IUniqueComponentList<CalendarEvent> GetByMonth(DateTime date)
        //{
        //    var taskModels = GetAll().Where(i => i.DtStart.Month == date.Month);
        //    return (UniqueComponentListProxy<CalendarEvent>)taskModels;
        //}

        //public void Update(IRecurringComponent calendarEvent, IRecurringComponent newCalendarEvent)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
