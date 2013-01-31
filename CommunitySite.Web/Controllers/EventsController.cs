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
            var repo = new UnitOfWork();
            var events = repo.Events.GetAll().Where(x => x.FromDate >= DateTime.Now).OrderBy(x => x.FromDate);
            return View(events);
        }

        public ActionResult Archive()
        {
            var repo = new UnitOfWork();
            var events = repo.Events.GetAll().Where(x => x.ToDate < DateTime.Now).OrderByDescending(x => x.FromDate);
            return View(events);
        }

        public ActionResult Detail(Guid id)
        {
            var repo = new UnitOfWork();
            var model = repo.Events.GetAll().FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
