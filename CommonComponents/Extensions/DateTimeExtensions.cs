using System;

namespace CommonComponents.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsInOrBetween(this DateTime input, DateTime date1, DateTime date2)
        {
            return ((input > date1 && input < date2) || (input == date1) || (input == date2));
        }

        public static DateTime[] GetDatesBetween(this DateTime input, DateTime date1)
        {
            int countOfDays = input.DayOfYear - date1.DayOfYear + 1;
            DateTime[] result = new DateTime[countOfDays];

            int whatDayCounter = input.Day;
            int whatMonthCounter = input.Month;
            int whatYearCounter = input.Year;
            DateTime tempDate = date1;

            if (input.Month == date1.Month)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = tempDate;
                    tempDate = tempDate.AddDays(1);
                }
            }
            else
            {

            }
            return result;
        }
    }
}
