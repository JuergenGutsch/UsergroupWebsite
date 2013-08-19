﻿using CommunitySite.Web.Data.Models;

namespace CommunitySite.Web.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRepository<Event> events,
                          IRepository<Person> persons,
                          IRepository<Speaker> speakers,
                          IRepository<Location> locations,
                          IRepository<Subscription> subscriptions)
        {
            Events = events;
            Persons = persons;
            Speakers = speakers;
            Locations = locations;
            Subscriptions = subscriptions;
        }

        public IRepository<Event> Events { get; set; }
        public IRepository<Person> Persons { get; set; }
        public IRepository<Speaker> Speakers { get; set; }
        public IRepository<Location> Locations { get; set; }
        public IRepository<Subscription> Subscriptions { get; set; }
    }

    public interface IUnitOfWork
    {
        IRepository<Event> Events { get; set; }
        IRepository<Person> Persons { get; set; }
        IRepository<Speaker> Speakers { get; set; }
        IRepository<Location> Locations { get; set; }
        IRepository<Subscription> Subscriptions { get; set; }
    }
}