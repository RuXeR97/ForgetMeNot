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
    }
}
