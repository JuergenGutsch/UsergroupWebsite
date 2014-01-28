using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gos.SimpleObjectStore;

namespace CommunitySite.Web.Data.Models
{
    public class Event : IEntity
    {
        public Event()
        {
            SpeakerIds = new List<Guid>();
            AttandeeIds = new List<Guid>();
            LocationId = Guid.Empty;
        }
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Titel wird benötigt")]
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        [Required(ErrorMessage = "Teaser wird benötigt")]
        public string Teaser { get; set; }
        [Required(ErrorMessage = "Beschreibung wird benötigt")]
        public string Description { get; set; }
        public Guid LocationId { get; set; }
        public IEnumerable<Guid> SpeakerIds { get; set; }
        public IEnumerable<Guid> AttandeeIds { get; set; }
    }
}