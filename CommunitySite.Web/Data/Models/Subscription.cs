using System;
using Gos.SimpleObjectStore;

namespace CommunitySite.Web.Data.Models
{
    public class Subscription : IEntity
    {
        [Identifier]
        public String Email { get; set; }
        public bool IsValid { get; set; }
        public Guid ValidationKey { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DataValidated { get; set; }
    }
}