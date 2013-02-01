using CommunitySite.Web.Data.Models;

namespace CommunitySite.Web.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Events = new Repository<Event>();
        }

        public IRepository<Event> Events { get; set; }
    }

    public interface IUnitOfWork
    {
        IRepository<Event> Events { get; set; }
    }
}