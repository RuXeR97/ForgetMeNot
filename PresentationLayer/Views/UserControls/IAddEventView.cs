using Google.Apis.Calendar.v3.Data;
using System;

namespace PresentationLayer.Views.UserControls
{
    public interface IAddEventView
    {
        event EventHandler CancelKryptonButtonClickEventRaised;
        event EventHandler ConfirmKryptonButtonClickEventRaised;

        string EventDescription { get; set; }
        string EventLocation { get; set; }
        EventDateTime EventStartTime { get; set; }
        EventDateTime EventEndTime { get; set; }
        string EventCalendar { get; set; }

        void CloseWindow();
        void ShowWindow();
    }
}