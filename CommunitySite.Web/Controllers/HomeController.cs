using System;
using System.Linq;
using System.Web.Mvc;
using CommunitySite.Web.Data;
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

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var eventModel = _unitOfWork.Events.GetAll()
                .OrderBy(x => x.FromDate)
                .FirstOrDefault(x => x.ToDate >= DateTime.Now);

            var model = new HomeModel
                {
                    Event = eventModel
                };
            return View(model);
        }

    }
}
