using System;

namespace CommunitySite.Web.Data.Models
{
    public class Speaker : IEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid PersonId { get; set; }
    }
}