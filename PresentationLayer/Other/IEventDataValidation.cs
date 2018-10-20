using System;

namespace PresentationLayer.Other
{
    interface IEventDataValidation
    {
        bool ValidateHours(DateTime startHour, DateTime endHour);
        bool ValidateTimes(DateTime startTime, DateTime endTime);
        bool ValidateLocation();
        bool ValidateDescription();
    }
}
