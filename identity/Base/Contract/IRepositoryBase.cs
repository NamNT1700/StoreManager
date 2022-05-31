using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Base.Contract
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        IQueryable<T> FindByConditionWithTracking(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void CreateMany(IEnumerable<T> entitys);

        void Update(T entity);
        void UpdateMany(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteMany(IEnumerable<T> entities);

        public Task SaveAsync();

        public Task Dispose();
    }
}