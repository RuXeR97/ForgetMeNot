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
    public partial class AddEventView : Form
    {
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

        private void startHourKryptonDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startHourKryptonDateTimePicker.Value > endHourKryptonDateTimePicker.Value)
            {
                endHourKryptonDateTimePicker.Value = startHourKryptonDateTimePicker.Value.AddMinutes(30);
            }
        }

        private void endHourKryptonDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startHourKryptonDateTimePicker.Value > endHourKryptonDateTimePicker.Value)
            {
                startHourKryptonDateTimePicker.Value = endHourKryptonDateTimePicker.Value.AddMinutes(-30);
            }
        }

        private void confirmKryptonButton_Click(object sender, EventArgs e)
        {
            ValidateStartHour();
            ValidateEndHour();
            ValidateStartTime();
            ValidateEndTime();
            ValidateLocation();
            ValidateDescription();
        }

        private void ValidateDescription()
        {
            throw new NotImplementedException();
        }

        private void ValidateLocation()
        {
            throw new NotImplementedException();
        }

        private void ValidateEndTime()
        {
            throw new NotImplementedException();
        }

        private void ValidateStartTime()
        {
            throw new NotImplementedException();
        }

        private void ValidateEndHour()
        {
            throw new NotImplementedException();
        }

        private void ValidateStartHour()
        {
            throw new NotImplementedException();
        }

        private void startTimeKryptonDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(startTimeKryptonDateTimePicker.Value > endTimeKryptonDateTimePicker.Value)
            {
                endTimeKryptonDateTimePicker.Value = startTimeKryptonDateTimePicker.Value;
            }
        }

        private void endTimeKryptonDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(startTimeKryptonDateTimePicker.Value > endTimeKryptonDateTimePicker.Value)
            {
                startTimeKryptonDateTimePicker.Value = endTimeKryptonDateTimePicker.Value;
            }
        }
    }
}
