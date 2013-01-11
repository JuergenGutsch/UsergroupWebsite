using System;
using System.Web.Mvc;
using System.Linq;
using CommunitySite.Web.Data;

namespace CommunitySite.Web.Controllers
{
    public class EventsController : Controller
    {
        //
        // GET: /Events/
        public ActionResult Index()
        {
            var repo = new EventRepository();
            var events = repo.GetAll(x => x.FromDate >= DateTime.Now).OrderBy(x => x.FromDate);
            return View(events);
        }

        public ActionResult Archive()
        {
            var repo = new EventRepository();
            var events = repo.GetAll(x => x.ToDate < DateTime.Now).OrderByDescending(x => x.FromDate);
            return View(events);
        }

        public ActionResult Detail(string id)
        {
            var repo = new EventRepository();
            var model = repo.GetAll(x => x.RowKey == id).FirstOrDefault();
            return View(model);
        }

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
