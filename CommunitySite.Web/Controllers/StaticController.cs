using System.Web.Mvc;

namespace CommunitySite.Web.Controllers
{
    public class StaticController : Controller
    {
        public ActionResult Page(string id)
        {
            return View(id);
        }
    }
}
