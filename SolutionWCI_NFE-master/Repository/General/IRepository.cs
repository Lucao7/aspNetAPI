using Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.General
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task Add(TEntity entity);
        Task Delete(Func<TEntity, bool> predicate);
        Task<ICollection<TEntity>> GetListAll(Expression<Func<TEntity, bool>> predicate);
        Task<int> GetListAllCount(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> GetList(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<ICollection<TEntity>> GetListOrderByDescending(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDescending = null);

        Task<ICollection<TEntity>> GetListPrimitive(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<ICollection<TEntity>> GetInclude(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<ICollection<TEntity>> GetIncludeNotPagination(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null);
        Task<ICollection<TEntity>> GetIncludeNotPaginationAsNoTracking(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null);
        Task<TEntity> Get(params object[] Keys);

        Task<ICollection<TEntity>> GetPerField(Expression<Func<TEntity, bool>> where);
        Task Update(TEntity entity);
    }
}
