using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Other
{
    public class DataValidation : IEventDataValidation
    {
        public bool ValidateDescription()
        {
            throw new NotImplementedException();
        }

        public bool ValidateHours(DateTime startHour, DateTime endHour)
        {
            throw new NotImplementedException();
        }

        public bool ValidateLocation()
        {
            throw new NotImplementedException();
        }

        public bool ValidateTimes(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }
    }
}
