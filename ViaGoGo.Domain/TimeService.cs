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
            if (today.DayOfWeek == DayOfWeek.Saturday)
            {

            }

            if (today.DayOfWeek == DayOfWeek.Sunday)
            {

            }
            return new TimeServiceResponse();
        }

        #endregion
    }
}
