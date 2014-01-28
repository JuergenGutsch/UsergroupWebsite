using System.Collections.Generic;

namespace CommunitySite.Web.Models
{
    public class HomeModel
    {
        public IEnumerable<EventDetailModel> Events { get; set; }
    }
}