using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaGoGo.Models.Response
{
    public class TimeServiceResponse
    {
        public TimeServiceResponse()
        {
            Notifications = new NotificationCollection();
        }

        public DateTime Result { get; set; }
        public NotificationCollection Notifications { get; set; }
    }
}
