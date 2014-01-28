using System;
using System.Linq;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using CommunitySite.Web.Data.Models;
using CommunitySite.Web.Models;

namespace CommunitySite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var events = _unitOfWork.Events.LoadAll()
                                        .OrderBy(x => x.FromDate)
                                        .Where(x => x.ToDate >= DateTime.Now)
                                        .Take(3);

            var model = new HomeModel
                {
                    Events = events
                };
            return View(model);
        }

    }
}
