using Model.General;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.General
{
    public class BRepository<TEntity> where TEntity : BaseModel
    {
        protected Repository<TEntity> repository;

        public BRepository(Repository<TEntity> repository)
        {
            this.repository = repository;
        }

        //public SolutionContext context { get { return repository.context; } }

        public async Task Add(TEntity entity)
        {
            await repository.Add(entity);
        }

        public async Task Delete(Func<TEntity, bool> predicate)
        {
            await repository.Delete(predicate);
        }

        public async Task<ICollection<TEntity>> GetListAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.GetListAll(predicate);
        }

        public async Task<int> GetListAllCount(Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.GetListAllCount(predicate);
        }

        public async Task<ICollection<TEntity>> GetList(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await repository.GetList(orderpagination, pagination, where, orderBy);
        }

        public async Task<ICollection<TEntity>> GetListOrderByDescending(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDescending = null)
        {
            return await repository.GetListOrderByDescending(orderpagination, pagination, where, orderByDescending);
        }

        public async Task<ICollection<TEntity>> GetListPrimitive(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await repository.GetListPrimitive(orderpagination, pagination, where, orderBy);
        }

        public async Task<ICollection<TEntity>> GetInclude(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await repository.GetInclude(orderpagination, pagination, where, include, orderBy);
        }

        public async Task<ICollection<TEntity>> GetIncludeNotPagination(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            return await repository.GetIncludeNotPagination(where, include);
        }

        public async Task<ICollection<TEntity>> GetIncludeNotPaginationAsNoTracking(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            return await repository.GetIncludeNotPaginationAsNoTracking(where, include);
        }

        public async Task Update(TEntity entity)
        {
            await repository.Update(entity);
        }

        public async Task<TEntity> Get(params object[] Keys)
        {
            return await repository.Get(Keys);
        }

        public async Task<ICollection<TEntity>> GetPerField(Expression<Func<TEntity, bool>> where)
        {
            return await repository.GetPerField(where);
        }

        public void Dispose()
        {
            repository.Dispose();
        }


    }
}
