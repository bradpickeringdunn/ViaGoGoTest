using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViaGoGo.Domain;
using ViaGoGo.Models.Response;

namespace ViaGoGo.Actions
{
    public class GetNextWorkingDayAction<T> where T:class
    {
        private ITimeService TimeService;

        public GetNextWorkingDayAction(ITimeService timeService)
        {
            this.TimeService = timeService;
        }

        public Func<TimeServiceResponse, T> OnSuccess{get;set;}

        public Func<T> OnFailed { get; set; }

        public T Execute(DateTime today){

            var notifications = new NotificationCollection();
            var nextWorkingDay = TimeService.ReturnNextWorkingDay(today);

            return nextWorkingDay.Notifications.HasErrors ? OnFailed() : OnSuccess(nextWorkingDay);
        }
    }
}