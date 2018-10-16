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

        public void Add(IDirectResponseSchema calendarEvent)
        {
            throw new NotImplementedException();
        }

        public void Delete(IDirectResponseSchema calendarEvent)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int calendarEventId)
        {
            throw new NotImplementedException();
        }
        
        // done
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

        // done
        public IDirectResponseSchema GetByMonth(DateTime? month)
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

        public void Update(IDirectResponseSchema calendarEvent, IDirectResponseSchema newCalendarEvent)
        {
            throw new NotImplementedException();
        }
    }


}
