using Google.Apis.Calendar.v3.Data;
using Google.Apis.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Other
{
    public class CalendarEventsParser : ICalendarEventsParser
    {
        public string[] ConvertCalendarEventsToArray(DateTime currentDate, IList<Event> calendarEvents)
        {
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            string[] arrayOfTasks = new string[daysInMonth];
            DateTime dateCounter = new DateTime(currentDate.Year, currentDate.Month, 1);
            string finalTask = null;

            for (int i = 0; i < arrayOfTasks.Length; i++)
            {
                var dayEventModels = calendarEvents.Where(j => j.Start.DateTime.Value.Day == dateCounter.Day);
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
