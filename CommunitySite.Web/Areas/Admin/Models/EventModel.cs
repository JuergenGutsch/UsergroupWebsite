using System.Collections.Generic;
using System.Web.Mvc;
using CommunitySite.Web.Data.Models;

namespace CommunitySite.Web.Areas.Admin.Models
{
    public class EventModel
    {
        public Event Event { get; set; }
        public IEnumerable<SelectListItem> Speakers { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
    }
}