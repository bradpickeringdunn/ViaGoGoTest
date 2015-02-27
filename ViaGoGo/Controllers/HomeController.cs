using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaGoGo.Domain;

namespace ViaGoGo.Controllers
{
    public class HomeController : Controller
    {
        private ITimeService TimeService;

        public HomeController(ITimeService timeService)
        {
            this.TimeService = timeService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
