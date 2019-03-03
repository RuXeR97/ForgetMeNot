using CommonComponents.Exceptions;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Requests;
using InfrastructureLayer.DataAccess.Repositories.Specific.Task;
using PresentationLayer.Other;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.TaskServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class AddEventPresenter : IAddEventPresenter
    {
        private IAddEventView _addEventView;
        private IEventDataValidation _eventDataValidation;
        private ITaskService _taskService;
        private IErrorMessageView _errorMessageView;

        public AddEventPresenter(IAddEventView addEventView)
        {
            _addEventView = addEventView;
            _eventDataValidation = new DataValidation();
            _taskService = new TaskService(new TaskGoogleRepository(), null);
            _errorMessageView = new ErrorMessageView();
            SubscribeToEventsSetup();
        }

        public IAddEventView GetAddEventView()
        {
            return _addEventView;
        }
        private void SubscribeToEventsSetup()
        {
            _addEventView.ConfirmKryptonButtonClickEventRaised +=
                new EventHandler(OnConfirmKryptonButtonClickedEventRaised);

            _addEventView.CancelKryptonButtonClickEventRaised +=
                new EventHandler(OnCancelKryptonButtonClickedEventRaised);
        }

        private void OnConfirmKryptonButtonClickedEventRaised(object sender, EventArgs e)
        {
            try
            {
                //_eventDataValidation.ValidateDescription();
                //_eventDataValidation.ValidateLocation();
                //_eventDataValidation.ValidateHours();
                //_eventDataValidation.ValidateTimes();

                string eventCalendar = _addEventView.EventCalendar;
                IDirectResponseSchema eventBody = new Event()
                {
                    Description = _addEventView.EventDescription,
                    Location = _addEventView.EventLocation,
                    Start = _addEventView.EventStartTime,
                    End = _addEventView.EventEndTime
                };

                Event myEvent = new Event
                {
                    Description = _addEventView.EventDescription,
                    Summary = "Appointment",
                    Location = _addEventView.EventLocation,
                    Start = _addEventView.EventStartTime,
                    End = _addEventView.EventEndTime,
                    Recurrence = new String[] {
                                                "RRULE:FREQ=WEEKLY;BYDAY=MO"
                                               },
                    Attendees = new List<EventAttendee>()
                };
                _taskService.Add(eventCalendar, myEvent);
            }
            catch(InvalidEventDataException ex)
            {
                _errorMessageView.ShowErrorMessageView("Error", ex.Message);
            }
        }

        private void OnCancelKryptonButtonClickedEventRaised(object sender, EventArgs e)
        {
            _addEventView.CloseWindow();
        }

        public void ShowAddEventView()
        {
            _addEventView.ShowWindow();
        }
    }
}
