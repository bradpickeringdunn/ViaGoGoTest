using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaGoGo.Models.Response;

namespace ViaGoGo.Domain
{
    public interface ITimeService
    {
        TimeServiceResponse ReturnNextWorkingDay(DateTime today);
    }
}
