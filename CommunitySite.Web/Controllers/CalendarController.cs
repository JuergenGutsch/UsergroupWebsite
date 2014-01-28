using System;
using System.Linq;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using CommunitySite.Web.Models;

namespace CommunitySite.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalendarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var events = _unitOfWork.Events.LoadAll(x => x.FromDate >= DateTime.Now).OrderBy(x => x.FromDate);
            return View(events);
        }

        public ActionResult Archive()
        {
            var events = _unitOfWork.Events.LoadAll(x => x.ToDate < DateTime.Now).OrderByDescending(x => x.FromDate);
            return View(events);
        }

        public ActionResult Detail(Guid id)
        {
            var @event = _unitOfWork.Events.LoadSingle(x => x.Id == id);

            var model = new EventDetailModel
            {
                Event = @event,
                Location = _unitOfWork.Locations.LoadSingle(x => x.Id == @event.LocationId)
            };
            return View(model);
        }

        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
