using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViaGoGo.Domain;
using ViaGoGo.Models;
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

        public Func<WorkingDayViewModel, T> OnComplete { get; set; }

        public T Execute(DateTime? date)
        {
            var model = new WorkingDayViewModel();

            TimeServiceResponse result = new TimeServiceResponse();

            if (!date.HasValue)
            {
                model.Notifications.Add(new Notification(Errors.IncorrectDate));
            }

            if (!model.Notifications.HasErrors)
            {
                result = TimeService.ReturnNextWorkingDay(date.Value);
                model.Notifications = result.Notifications;
            };

            if (!model.Notifications.HasErrors)
            {
                model.NextWorkingDay = result.NextworkingDay;
            }
            
            return OnComplete(model);
        }
    }
}