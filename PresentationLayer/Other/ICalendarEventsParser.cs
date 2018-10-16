using Google.Apis.Calendar.v3.Data;
using Google.Apis.Requests;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Other
{
    public interface ICalendarEventsParser
    {
        string[] ConvertCalendarEventsToArray(DateTime currentDate,
            IList<Event> calendarEvents);
    }
}
