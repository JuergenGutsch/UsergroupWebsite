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

        public ActionResult Index(int? id)
        {
            var currentPage = id.HasValue ? id.Value : 0;

            var events = _unitOfWork.Events
                .LoadAll(x => x.FromDate >= DateTime.Now)
                .OrderBy(x => x.FromDate)
                .Select(x => new EventDetailModel
                {
                    Event = x
                }).ToList();

            var model = new EventDetailListModel
            {
                Events = events.Skip(currentPage * 10).Take(10),
                CurrentPage = currentPage,
                PageCount = PageCount(events.Count())
            };

            return View(model);
        }

        private int PageCount(int itemsCount)
        {
            var pageCount = itemsCount / 10;
            if (itemsCount % 10 > 0)
            {
                pageCount++;
            }
            return pageCount;
        }

        public ActionResult Archive(int? id)
        {
            var currentPage = id.HasValue ? id.Value : 0;

            var events = _unitOfWork.Events
                .LoadAll(x => x.ToDate < DateTime.Now)
                .OrderByDescending(x => x.FromDate)
                .Select(x => new EventDetailModel
                {
                    Event = x
                }).ToList();

            var model = new EventDetailListModel
            {
                Events = events.Skip(currentPage * 10).Take(10),
                CurrentPage = currentPage,
                PageCount = PageCount(events.Count())
            };

            return View(model);
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
            throw new NotImplementedException();
        }
    }
}
