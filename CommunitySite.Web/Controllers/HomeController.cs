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
            var uow = new UnitOfWork();
            var eventModel = uow.Events.GetAll()
                .OrderBy(x => x.FromDate)
                .FirstOrDefault(x => x.ToDate >= DateTime.Now);

            var model = new HomeModel
                {
                    Event = eventModel
                };
            return View(model);
        }

    }
}
