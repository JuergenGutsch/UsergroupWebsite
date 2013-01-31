using CommunitySite.Web.Data.Models;

namespace CommunitySite.Web.Data
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            Events = new RepositoryBase<Event>();
        }

        public IRepository<Event> Events { get; set; }
    }
}