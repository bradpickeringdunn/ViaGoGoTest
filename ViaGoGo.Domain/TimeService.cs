using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaGoGo.Models.Response;

namespace ViaGoGo.Domain
{
    public class TimeService : ITimeService
    {
        #region ITimeService Members

        public TimeServiceResponse ReturnNextWorkingDay(DateTime today)
        {
            var result = new TimeServiceResponse();
            DateTime? nextWorkingDay = null;

            int numberofDays = 31; //At least one day in 31 consecutive days will be a work day.

            for (int day = 1; day <= numberofDays; day++)
            {
                //Strugeling to think of a better variable name
                var nextDay = today.AddDays(day);

                if(Holidays().All(holiday => holiday.Key.Day != nextDay.Day))
                {
                    nextWorkingDay = GetNextWorkDay(nextDay);
                    break;
                }

                day++;

            }

            if (nextWorkingDay.IsNull())
            {
                result.Notifications.Add
                    (
                        new Notification(Errors.Exception)
                    );
            }
            else
            {
                result.NextworkingDay = nextWorkingDay.Value;

            }

            return result;
        }

        private DateTime GetNextWorkDay(DateTime nextDay)
        {
            
                if (nextDay.DayOfWeek == DayOfWeek.Saturday)
                {
                    nextDay = nextDay.AddDays(2);
                }

                if (nextDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    nextDay = nextDay.AddDays(1);
                }
            

            return nextDay;
                
        }


        #endregion

        private static IDictionary<DateTime, DayOfWeek> Holidays()
        {
            //Having these as harcoded dates is very wrong.
            //This is for this test only and would idealy be placed in a datbase or something similar
            IDictionary<DateTime, DayOfWeek> holidays = new Dictionary<DateTime, DayOfWeek>();

            holidays.Add(new KeyValuePair<DateTime, DayOfWeek>(new DateTime(2015, 12, 25), DayOfWeek.Monday));
            holidays.Add(new KeyValuePair<DateTime, DayOfWeek>(new DateTime(2015, 12, 26), DayOfWeek.Monday));
            holidays.Add(new KeyValuePair<DateTime, DayOfWeek>(new DateTime(2016, 1, 1), DayOfWeek.Monday));

            return holidays;
        }
    }

}
