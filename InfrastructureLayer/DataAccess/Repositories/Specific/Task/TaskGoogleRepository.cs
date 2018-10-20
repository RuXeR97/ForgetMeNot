using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Requests;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using ServiceLayer.Services.TaskServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Task
{
    public class TaskGoogleRepository : BaseSpecificRepository, ITaskRepository
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private string credentialsFileName = "credentials.json";
        private CalendarService service;
        public TaskGoogleRepository()
        {
            UserCredential credential;
            string applicationName = "Forget me not!";
            using (var stream =
                new FileStream(credentialsFileName, FileMode.Open, FileAccess.Read))
            {
                string credPath = "privateToken";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName,
            });

        }

        public void Add(string calendarId, IDirectResponseSchema newCalendarEvent)
        {
            var body = newCalendarEvent as Event;
            EventsResource.InsertRequest request = service.Events.Insert(body, calendarId);
        }

        public void Update(IDirectResponseSchema newCalendarEvent, string calendarId, string oldEventId)
        {
            var _newCalendarEvent = newCalendarEvent as Event;
            EventsResource.UpdateRequest request = service.Events.Update(_newCalendarEvent, calendarId, oldEventId);
        }

        public void Delete(string calendarId, string eventId)
        {
            EventsResource.DeleteRequest request = service.Events.Delete(calendarId, eventId);
        }

        public void DeleteById(string calendarId, string eventId)
        {
            service.Events.Delete(calendarId, eventId);
        }

        public IDirectResponseSchema GetAllEvents()

        {
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.MinValue;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 1000;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                }
                return events;
            }
            else
            {
                return null;
            }
        }

        public IDirectResponseSchema GetEventsByMonth(DateTime? month)
        {
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.MinValue;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 1000;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();
            Events eventsByMonth = new Events();
            if (events.Items != null && events.Items.Count > 0)
            {
                eventsByMonth.Summary = events.Summary;
                eventsByMonth.TimeZone = events.TimeZone;

                foreach (var eventItem in events.Items)
                {
                    if (eventItem.Start.DateTime.Value.Month == month.Value.Month)
                        eventsByMonth.Items.Add(eventItem);
                }
                return eventsByMonth;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetCalendarsList()
        {
            var calendars = service.CalendarList.List().Execute().Items;
            List<string> calendarsNames = new List<string>();
            foreach (CalendarListEntry entry in calendars)
            {
                calendarsNames.Add(entry.Summary);
            }

            return calendarsNames;
        }
    }


}
