using System.Collections.Generic;
using CommunitySite.Web.Data.Models;

namespace CommunitySite.Web.Models
{
    public class HomeModel
    {
        public IEnumerable<Event> Events { get; set; }
    }
}