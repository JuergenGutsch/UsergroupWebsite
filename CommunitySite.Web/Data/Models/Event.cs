using System;
using System.Collections.Generic;
using Gos.SimpleObjectStore;

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
    public class Location : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
    }
    public class Person : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public bool UseGravatar { get; set; }
    }
    public class Speaker : IEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid PersonId { get; set; }
    }
}