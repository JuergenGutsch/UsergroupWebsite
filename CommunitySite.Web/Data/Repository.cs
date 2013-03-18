﻿using System;
using System.Collections.Generic;
using Gos.SimpleObjectStore;

namespace CommunitySite.Web.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public IEnumerable<TEntity> GetAll()
        {
            using (var repository = ObjectStore.GetInstance<TEntity>())
            {
                return repository.LoadAll();
            }
        }

        public TEntity GetById(Guid id)
        {
            using (var repository = ObjectStore.GetInstance<TEntity>())
            {
                return repository.LoadBy(x => x.Id == id);
            }
        }

        public void SaveOrUpdate(TEntity entity)
        {
            using (var repository = ObjectStore.GetInstance<TEntity>())
            {
                repository.SaveOnSubmit(entity);
                repository.SubmitChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            Delete(entity.Id);
        }

        public void Delete(Guid id)
        {
            using (var repository = ObjectStore.GetInstance<TEntity>())
            {
                repository.DeleteOnSubmit(x => x.Id == id);
                repository.SubmitChanges();
            }
        }
    }
}