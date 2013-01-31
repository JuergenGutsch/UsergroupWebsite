using System;

namespace CommunitySite.Web.Data.Models
{
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
}