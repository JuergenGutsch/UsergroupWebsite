using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommunitySite.Web.Data.Models
{
    public class Event : IEntity
    {
        public Event()
        {
            SpeakerIds = new List<Guid>();
            AttandeeIds = new List<Guid>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Teaser { get; set; }
        public string Description { get; set; }

        public Guid LocationId { get; set; }
        public IEnumerable<Guid> SpeakerIds { get; set; }
        public IEnumerable<Guid> AttandeeIds { get; set; }
    }
}