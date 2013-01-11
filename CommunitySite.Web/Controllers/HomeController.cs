using System;
using System.Linq;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using CommunitySite.Web.Models;

namespace CommunitySite.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var repo = new EventRepository();
            var eventModel = repo.GetNextEvent();

            var model = new HomeModel
                {
                    Event = eventModel
                };
            return View(model);
        }

    }
}
