using System;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using CommunitySite.Web.Data.Models;
using CommunitySite.Web.Models;
using CommunitySite.Web.Services;

namespace CommunitySite.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _mailService;

        public SubscriptionController(IUnitOfWork unitOfWork, IEmailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
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
            if (!ModelState.IsValid)
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
                    EventId = loadetEvent != null ? loadetEvent.Id : Guid.Empty,
                    IsActive = false,
                    DateCreated = DateTime.Now,
                    DataActivated = DateTime.MinValue
                };

            _unitOfWork.Subscriptions.SaveOrUpdate(subscription);

            _mailService.SendGlobalSubscriptionActivationMessage(subscription);

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
