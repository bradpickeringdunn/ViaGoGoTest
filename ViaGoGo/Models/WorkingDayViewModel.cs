using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViaGoGo.Models.Response;

namespace ViaGoGo.Models
{
    public class WorkingDayViewModel
    {
        public WorkingDayViewModel()
        {
            Notifications = new NotificationCollection();
        }

        public NotificationCollection Notifications { get; set; }

        public DateTime NextWorkingDay { get; set; }


    }
}