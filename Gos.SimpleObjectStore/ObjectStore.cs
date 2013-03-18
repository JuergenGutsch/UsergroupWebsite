using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gos.SimpleObjectStore
{
    public class ObjectStore
    {
        public static string DefaultQueryProperty { get; set; }
        public static IDataProvider DataProvider { get; set; }
        public static bool FormatOutput { get; set; }
        private static readonly object LockObject = new object();
        private static readonly IDictionary<Type, IObjectStore> Repositories = new Dictionary<Type, IObjectStore>();


        public static IObjectStore<TEntity> GetInstance<TEntity>() where TEntity : IEntity, new()
        {
            lock (LockObject)
            {
                if (!Repositories.ContainsKey(typeof(TEntity)))
                {
                    Repositories.Add(typeof(TEntity), new ObjectStore<TEntity>());
                }
                return Repositories[typeof(TEntity)] as IObjectStore<TEntity>;
            }
        }
    }

    public class ObjectStore<TEntity> : IObjectStore<TEntity> where TEntity : IEntity, new()
    {
        private readonly object _lockObject = new object();
        private ICollection<TEntity> _entities;
        private bool _isDirty;

        public ObjectStore()
        {
            lock (_lockObject)
            {
                _entities = new Collection<TEntity>();

                ObjectStore.DataProvider.DataSourceChanged +=
                    (sender, eventArgs) =>
                    {
                        if (eventArgs.EntityType != typeof(TEntity).Name)
                        {
                            return;
                        }
                        DiscardChanges();
                    };
                DiscardChanges();
            }
        }

        public void DiscardChanges()
        {
            lock (_lockObject)
            {
                _entities = ObjectStore.DataProvider.Load<TEntity>();
                _isDirty = false;
            }
        }

        public void SaveOnSubmit(TEntity entiy)
        {
            lock (_lockObject)
            {
                var existing = _entities.FirstOrDefault(x => x.Id == entiy.Id);
                if (existing != null)
                {
                    _entities.Remove(existing);
                }

                _entities.Add(entiy);
                _isDirty = true;
            }
        }

        public void SaveOnSubmit(IEnumerable<TEntity> enties)
        {
            lock (_lockObject)
            {
                foreach (var entity in enties)
                {
                    SaveOnSubmit(entity);
                }
            }
        }

        public void DeleteOnSubmit(Func<TEntity, bool> predicate)
        {
            lock (_lockObject)
            {
                var entities = _entities.Where(predicate);
                foreach (var entity in entities)
                {
                    _entities.Remove(entity);
                    _isDirty = true;
                }
            }
        }

        public void DeleteAllOnSubmit()
        {
            lock (_lockObject)
            {
                _entities.Clear();
                _isDirty = true;
            }
        }

        public void SubmitChanges()
        {
            lock (_lockObject)
            {
                if (!_isDirty) return;

                ObjectStore.DataProvider.Save(_entities);
                _isDirty = false;
            }
        }

        public IEnumerable<TEntity> LoadAll()
        {
            return _entities;
        }

        public TEntity LoadBy(Func<TEntity, bool> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            lock (_lockObject)
            {
                SubmitChanges();
            }
        }
    }
}