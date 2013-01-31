using System;
using System.Collections.Generic;

namespace CommunitySite.Web.Data
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void SaveOrUpdate(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Guid id);
    }
}