using Base.Contract;
using Base.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Server.Identity.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext RepositoryContext { get; set; }

        public RepositoryBase(DbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>();
        }

        //public IQueryable<T> FindAllWithPaging(QueryStringParameters queryStringParameters)
        //{
        //    return RepositoryContext.Set<T>()
        //    .Skip((queryStringParameters.PageNumber - 1) * queryStringParameters.PageSize)
        //    .Take(queryStringParameters.PageSize);
        //}

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression);
        }

        public IQueryable<T> FindByConditionWithTracking(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void CreateMany(IEnumerable<T> entitys)
        {
            RepositoryContext.Set<T>().AddRange(entitys);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void UpdateMany(IEnumerable<T> entities)
        {
            RepositoryContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
        public void DeleteMany(IEnumerable<T> entities)
        {
            RepositoryContext.Set<T>().RemoveRange(entities);
        }

        public async Task SaveAsync()
        {
            await RepositoryContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Dispose()
        {
            await RepositoryContext.DisposeAsync();
        }
    }
}