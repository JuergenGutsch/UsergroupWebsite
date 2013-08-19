using System;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using CommunitySite.Web.Data.Models;
using CommunitySite.Web.Models;

namespace CommunitySite.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Subscribe(string id)
        {
            Event loadetEvent = null;
            if (!String.IsNullOrWhiteSpace(id))
            {
                loadetEvent = _unitOfWork.Events.GetById(new Guid(id));
            }

            return View(new SubscribeModel
                {
                    Event = loadetEvent
                });
        }
        [HttpPost]
        public ActionResult Subscribe(string id, SubscribeModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            Event loadetEvent = null;
            if (!String.IsNullOrWhiteSpace(id))
            {
                loadetEvent = _unitOfWork.Events.GetById(new Guid(id));
            }

            var subscription = new Subscription()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    EventId = new Guid(id)
                };

            _unitOfWork.Subscriptions.SaveOrUpdate(subscription);

            return RedirectToAction("Subscribe");
        }


        [HttpGet]
        public ActionResult Activate(Guid id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Unsubscribe(Guid id)
        {
            return View();
        }
    }
}
