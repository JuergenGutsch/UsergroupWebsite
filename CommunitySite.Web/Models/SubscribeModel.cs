using System;
using CommunitySite.Web.Data.Models;
using FluentValidation;

namespace CommunitySite.Web.Models
{
    public class SubscribeModel
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public Event Event { get; set; }
    }

    public class SubscribeValidator : AbstractValidator<SubscribeModel>
    {
        public SubscribeValidator()
        {
            RuleFor(model => model.Name).NotNull();
            RuleFor(model => model.Email).NotNull().EmailAddress();
        }
    }
}