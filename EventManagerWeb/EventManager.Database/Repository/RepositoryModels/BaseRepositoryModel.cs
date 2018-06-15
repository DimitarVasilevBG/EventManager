using EventManager.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Database.Repository.RepositoryModels
{
    public class BaseRepositoryModel<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> Querable;

        protected EventsDbContext DBContext;

        public BaseRepositoryModel(EventsDbContext context)
        {
            Querable = context.Set<TEntity>();
            DBContext = context;
        }

        public IQueryable<TEntity> All()
        {
            return Querable;
        }

        public IQueryable<TEntity> AllIncluding(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Querable.Include(x => includeProperties);
        }

        public TEntity GetById(int id)
        {
            return Querable.Find(id);
        }

        public void AddRange(IEnumerable<TEntity> entityList, bool saveChanges = true)
        {
            Querable.AddRange(entityList);
            if (saveChanges) DBContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Querable.Remove(entity);
            DBContext.SaveChanges();
        }

        public void DeleteRange(List<int> ids)
        {
            if (ids != null && ids.Any())
            {
                var entitiesToDelete = new List<TEntity>();

                ids.ForEach(x => entitiesToDelete.Add(Querable.Find(x)));
                if (entitiesToDelete.Any())
                {
                    Querable.RemoveRange(entitiesToDelete);
                    DBContext.SaveChanges();
                }
            }
        }

        public TEntity Add(TEntity entity, bool saveChanges = true)
        {
            Querable.Add(entity);
            if (saveChanges) DBContext.SaveChanges();
            return entity;
        }

        public int SaveChanges()
        {
            return DBContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> itemsToRemove)
        {
            if (itemsToRemove.Any())
            {
                Querable.RemoveRange(itemsToRemove);
                DBContext.SaveChanges();
            }
        }

    }
}
