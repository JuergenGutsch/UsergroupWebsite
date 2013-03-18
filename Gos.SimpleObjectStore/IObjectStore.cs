using System;
using System.Collections.Generic;

namespace Gos.SimpleObjectStore
{
    public interface IObjectStore<TEntity> : IObjectStore, IDisposable where TEntity : IEntity, new()
    {
        void DiscardChanges();
        void SaveOnSubmit(TEntity entiy);
        void SaveOnSubmit(IEnumerable<TEntity> enties);
        void DeleteOnSubmit(Func<TEntity, bool> predicate);
        void DeleteAllOnSubmit();
        void SubmitChanges();
        IEnumerable<TEntity> LoadAll();
        TEntity LoadBy(Func<TEntity, bool> func);
    }

    public interface IObjectStore
    {
    }
}