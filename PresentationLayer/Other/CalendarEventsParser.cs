using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using System;
using System.Linq;

namespace PresentationLayer.Other
{
    public class CalendarEventsParser : ICalendarEventsParser
    {
        public string[] ConvertCalendarEventsToArray(DateTime currentDate,
            IUniqueComponentList<CalendarEvent> calendarEvents)
        {
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            string[] arrayOfTasks = new string[daysInMonth];
            DateTime dateCounter = new DateTime(currentDate.Year, currentDate.Month, 1);
            string finalTask = null;
            var eventModels = calendarEvents.Where(i => i.DtStart.Month == currentDate.Month);

            for (int i = 0; i < arrayOfTasks.Length; i++)
            {
                var dayEventModels = eventModels.Where(j => j.DtStart.Day == dateCounter.Day);
                if (dayEventModels != null)
                {
                    foreach (var taskModel in dayEventModels)
                    {
                        finalTask += taskModel.Summary + Environment.NewLine;
                    }

                    arrayOfTasks[i] = finalTask;
                    finalTask = null;
                }
                dateCounter = dateCounter.AddDays(1);
            }
            return arrayOfTasks;
        }
    }
}
