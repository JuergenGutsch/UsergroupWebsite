using System;

namespace CommunitySite.Web.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}