using System;
using Gos.SimpleObjectStore;

namespace CommunitySite.Web.Data.Models
{
    public class Subscription : IEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public Guid EventId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DataActivated { get; set; }
    }
}