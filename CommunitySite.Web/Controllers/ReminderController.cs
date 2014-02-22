using System;
using System.Linq;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using CommunitySite.Web.Data.Models;
using CommunitySite.Web.Models;
using CommunitySite.Web.Services;

namespace CommunitySite.Web.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _mailService;

        public ReminderController(IUnitOfWork unitOfWork, IEmailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ReminderModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ReminderModel model)
        {
            try
            {

                if (_unitOfWork.Subscriptions.LoadAll(x => x.Email.Equals(model.Email)).Any())
                {
                    ModelState.AddModelError("Email", "Diese E-Mail ist bereits registriert.");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var subscription = new Subscription
                {
                    Email = model.Email,
                    ValidationKey = Guid.NewGuid(),
                    IsValid = false,
                    DateCreated = DateTime.Now,
                    DataValidated = DateTime.MinValue
                };

                _mailService.SendGlobalSubscriptionActivationMessage(subscription);

                _unitOfWork.Subscriptions.SaveOnSubmit(subscription);
                _unitOfWork.Subscriptions.SubmitChanges();

                model.Success = true;
            }
            catch (Exception ex)
            {
                model.Error = ex.ToString();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Activate(Guid id)
        {
            var subscription = _unitOfWork.Subscriptions.LoadSingle(x => x.ValidationKey == id);

            var model = new ActivateModel
            {
                Exists = subscription != null,
                Email = subscription != null ? subscription.Email : String.Empty
            };

            if (model.Exists)
            {
                subscription.IsValid = true;
                subscription.DataValidated = DateTime.Now;

                _unitOfWork.Subscriptions.SaveOnSubmit(subscription);
                _unitOfWork.Subscriptions.SubmitChanges();
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Unsubscribe(Guid id)
        {
            var subscription = _unitOfWork.Subscriptions.LoadSingle(x => x.ValidationKey == id);

            var model = new UnsubscribeModel
            {
                Exists = subscription != null,
                Email = subscription != null ? subscription.Email : String.Empty
            };

            if (model.Exists)
            {
                subscription.IsValid = true;
                subscription.DataValidated = DateTime.Now;

                _unitOfWork.Subscriptions.DeleteOnSubmit(subscription);
                _unitOfWork.Subscriptions.SubmitChanges();
            }

            return View(model);
        }
    }
}