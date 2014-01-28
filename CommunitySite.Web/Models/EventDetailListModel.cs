using System.Collections.Generic;

namespace CommunitySite.Web.Models
{
    public class EventDetailListModel
    {
        public IEnumerable<EventDetailModel> Events { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}