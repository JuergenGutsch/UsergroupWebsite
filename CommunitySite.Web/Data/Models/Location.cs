using System;

namespace CommunitySite.Web.Data.Models
{
    public class Location : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Capacity { get; set; }
    }
}