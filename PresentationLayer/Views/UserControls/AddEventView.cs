using CommonComponents;
using Google.Apis.Calendar.v3.Data;
using InfrastructureLayer.DataAccess.Repositories.Specific.Task;
using ServiceLayer.Services.TaskServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class AddEventView : Form, IAddEventView
    {
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }
        public EventDateTime EventStartTime { get; set; }
        public EventDateTime EventEndTime { get; set; }
        public string EventCalendar { get; set; }

        public event EventHandler ConfirmKryptonButtonClickEventRaised;
        public event EventHandler CancelKryptonButtonClickEventRaised;

        public event EventHandler StartHourKryptonDateTimePickerValueChangedEventRaised;
        public event EventHandler EndHourKryptonDateTimePickerValueChangedEventRaised;
        public event EventHandler StartTimeKryptonDateTimePickerValueChangedEventRaised;
        public event EventHandler EndTimeKryptonDateTimePickerValueChangedEventRaised;
        public AddEventView()
        {
            InitializeComponent();

            var service = new TaskService(new TaskGoogleRepository(), null);
            var calendarsNames = service.GetCalendarsList();

            calendarsComboBox.DataSource = calendarsNames;

            SetCalendarsComboBox();
            SetStartTimeKryptonDateTimePicker();
            SetEndTimeKryptonDateTimePicker();
            SetStartHourKryptonDateTimePicker();
            SetEndHourKryptonDateTimePicker();
        }


        #region Setting krypton controls
        private void SetCalendarsComboBox()
        {

        }

        private void SetStartTimeKryptonDateTimePicker()
        {

        }

        private void SetEndTimeKryptonDateTimePicker()
        {

        }

        private void SetStartHourKryptonDateTimePicker()
        {

        }

        private void SetEndHourKryptonDateTimePicker()
        {

        }
        #endregion

        private void confirmKryptonButton_Click(object sender, EventArgs e)
        {
            EventDescription = descriptionKryptonTextBox.Text;
            EventLocation = locationKryptonTextBox.Text;
            EventCalendar = calendarsComboBox.Text;
            EventStartTime = new EventDateTime()
            {
                // still to edit
                DateTime = startTimeKryptonDateTimePicker.Value
            };
            EventEndTime = new EventDateTime()
            {
                // still to edit
                DateTime = endTimeKryptonDateTimePicker.Value
            };

            EventHelpers.RaiseEvent(objectRaisingEvent: confirmKryptonButton, eventHandlerRaised: ConfirmKryptonButtonClickEventRaised, eventArgs: e);
            
        }

        private void cancelKryptonButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(objectRaisingEvent: cancelKryptonButton, eventHandlerRaised: CancelKryptonButtonClickEventRaised, eventArgs: e);
        }

        public void CloseWindow()
        {
            this.Close();
        }

        public void ShowWindow()
        {
            this.Show();
        }
    }
}
