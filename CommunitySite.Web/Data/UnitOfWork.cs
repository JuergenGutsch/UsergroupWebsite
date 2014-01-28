using CommunitySite.Web.Data.Models;
using Gos.SimpleObjectStore;

namespace CommunitySite.Web.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Events = ObjectStore.GetInstance<Event>();
            Persons = ObjectStore.GetInstance<Person>();
            Speakers = ObjectStore.GetInstance<Speaker>();
            Locations = ObjectStore.GetInstance<Location>();
            Subscriptions = ObjectStore.GetInstance<Subscription>();
        }

        public IObjectStore<Event> Events { get; set; }
        public IObjectStore<Person> Persons { get; set; }
        public IObjectStore<Speaker> Speakers { get; set; }
        public IObjectStore<Location> Locations { get; set; }
        public IObjectStore<Subscription> Subscriptions { get; set; }
    }

    public interface IUnitOfWork
    {
        IObjectStore<Event> Events { get; set; }
        IObjectStore<Person> Persons { get; set; }
        IObjectStore<Speaker> Speakers { get; set; }
        IObjectStore<Location> Locations { get; set; }
        IObjectStore<Subscription> Subscriptions { get; set; }
    }
}