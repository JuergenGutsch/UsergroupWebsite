using System;
using System.Linq;
using System.Web.Mvc;
using CommunitySite.Web.Data;

namespace CommunitySite.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //
        // GET: /Events/
        public ActionResult Index()
        {
            var events = _unitOfWork.Events.GetAll().Where(x => x.FromDate >= DateTime.Now).OrderBy(x => x.FromDate);
            return View(events);
        }

        public ActionResult Archive()
        {
            var events = _unitOfWork.Events.GetAll().Where(x => x.ToDate < DateTime.Now).OrderByDescending(x => x.FromDate);
            return View(events);
        }

        public ActionResult Detail(Guid id)
        {
            var model = _unitOfWork.Events.GetAll().FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
