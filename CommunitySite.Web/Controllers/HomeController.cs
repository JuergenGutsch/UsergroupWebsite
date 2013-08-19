using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var source = _unitOfWork.Events.GetAll()
                                        .OrderBy(x => x.FromDate)
                                        .FirstOrDefault(x => x.ToDate >= DateTime.Now) ?? new Event
                                            {
                                                Title = "Kein Event Gefunden",
                                                Teaser = "Leider gibt es keine aktuellen Termine"
                                            };

            var model = new HomeModel
                {
                    Event = source
                };
            return View(model);
        }

    }
}
