using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EventManager.Database.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> All();
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id);
        T Add(T entity, bool saveChanges = true);
        void AddRange(IEnumerable<T> entityList, bool saveChanges = true);
        void Delete(T entity);
        void DeleteRange(List<int> ids);
        void DeleteRange(IEnumerable<T> itemsToRemove);
        int SaveChanges();
    }
}
