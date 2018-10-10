using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using System;

namespace PresentationLayer.Other
{
    public interface ICalendarEventsParser
    {
        string[] ConvertCalendarEventsToArray(DateTime currentDate,
            IUniqueComponentList<CalendarEvent> calendarEvents);
    }
}
