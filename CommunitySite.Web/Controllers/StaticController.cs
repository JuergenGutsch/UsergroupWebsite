using System;
using System.Web.Mvc;

namespace CommunitySite.Web.Controllers
{
    public class StaticController : Controller
    {
        public ActionResult Page(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }
            var result = ViewEngines.Engines.FindView(ControllerContext, id, null);
            if (result.View == null)
            {
                return HttpNotFound();
            }
            return View(id);
        }
    }
}
