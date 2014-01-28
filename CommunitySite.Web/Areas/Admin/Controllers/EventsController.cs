using System;
using System.Linq;
using System.Web.Mvc;
using CommunitySite.Web.Areas.Admin.Models;
using CommunitySite.Web.Data;
using CommunitySite.Web.Data.Models;

namespace CommunitySite.Web.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var events = _unitOfWork.Events.LoadAll()
                .OrderByDescending(x => x.FromDate);

            return View(events);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var selectedEvent = _unitOfWork.Events.LoadSingle(x => x.Id == id);

            var model = CreateEventModel(selectedEvent);

            return View(model);
        }

        private EventModel CreateEventModel(Event selectedEvent)
        {
            var model = new EventModel
            {
                Event = selectedEvent,
                Speakers = _unitOfWork.Speakers.LoadAll().Select(x => new SelectListItem
                {
                    Text =
                        _unitOfWork.Persons.LoadSingle(y => y.Id == x.PersonId).FirstName + " " +
                        _unitOfWork.Persons.LoadSingle(y => y.Id == x.PersonId).LastName,
                    Value = x.Id.ToString(),
                    Selected = selectedEvent.SpeakerIds.Contains(x.Id)
                }).OrderBy(x => x.Text),
                Locations = _unitOfWork.Locations.LoadAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = selectedEvent.LocationId.Equals(x.Id)
                })
            };
            return model;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = CreateEventModel(model);
                return View(viewModel);
            }

            _unitOfWork.Events.SaveOnSubmit(model);
            _unitOfWork.Events.SubmitChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Insert()
        {
            var newEvent = new Event();

            var model = CreateEventModel(newEvent);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Event model)
        {
            InsertEventValidation(model);

            if (!ModelState.IsValid)
            {
                var viewModel = CreateEventModel(model);
                return View(viewModel);
            }



            model.Id = Guid.NewGuid();
            _unitOfWork.Events.SaveOnSubmit(model);
            _unitOfWork.Events.SubmitChanges();

            return RedirectToAction("Index");
        }

        private void InsertEventValidation(Event model)
        {
            if (model.FromDate <= DateTime.Now)
            {
                ModelState.AddModelError("FromDate", "Das Startdatum muss in der Zukunft liegen.");
            }
            if (model.ToDate <= DateTime.Now)
            {
                ModelState.AddModelError("ToDate", "Das Enddatum muss in der Zukunft liegen.");
            }
            if (model.FromDate > model.ToDate)
            {
                ModelState.AddModelError("FromDate", "Das Startdatum darf nicht später als das Enddatum sein.");
                ModelState.AddModelError("ToDate", "Das Enddatum darf nicht früher als das Startdatum sein.");
            }
            if (!model.SpeakerIds.Any())
            {
                ModelState.AddModelError("SpeakerIds", "Es muss mindestens ein Sprecher ausgewählt werden.");
            }
            if (model.LocationId == Guid.Empty)
            {
                ModelState.AddModelError("LocationId", "Es muss eine Location ausgewählt werden.");
            }

        }
    }
}
