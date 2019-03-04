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

        private DateTime _whatDate;
        public AddEventView(DateTime whatDate)
        {
            InitializeComponent();

            _whatDate = whatDate;
            var service = new TaskService(new TaskGoogleRepository(), null);
            var calendarsNames = service.GetCalendarsList();

            calendarsComboBox.DataSource = calendarsNames;

            SetStartTimeKryptonDateTimePicker();
            SetEndTimeKryptonDateTimePicker();
            SetStartHourKryptonDateTimePicker();
            SetEndHourKryptonDateTimePicker();
        }


        #region Setting krypton controls

        private void SetStartTimeKryptonDateTimePicker()
        {
            startTimeKryptonDateTimePicker.Value = _whatDate;
        }

        private void SetEndTimeKryptonDateTimePicker()
        {
            endTimeKryptonDateTimePicker.Value = _whatDate;
        }

        private void SetStartHourKryptonDateTimePicker()
        {
            startHourKryptonDateTimePicker.Value = DateTime.Now;
        }

        private void SetEndHourKryptonDateTimePicker()
        {
            endHourKryptonDateTimePicker.Value = DateTime.Now.AddHours(1);
        }
        #endregion

        private void confirmKryptonButton_Click(object sender, EventArgs e)
        {
            EventDescription = descriptionKryptonTextBox.Text;
            EventLocation = locationKryptonTextBox.Text;
            EventCalendar = calendarsComboBox.Text;
            EventStartTime = new EventDateTime()
            {
                DateTime = startTimeKryptonDateTimePicker.Value,
                TimeZone = "Europe/Warsaw",
            };
            EventEndTime = new EventDateTime()
            {
                DateTime = endTimeKryptonDateTimePicker.Value,
                TimeZone = "Europe/Warsaw",
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
