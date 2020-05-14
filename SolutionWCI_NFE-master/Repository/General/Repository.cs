using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.General
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        #region .:: Prorpiedades ::.
        protected SolutionContext _db;

        public SolutionContext context;
        #endregion

        #region .:: Construtor ::.
        public Repository(SolutionContext db)
        {
            _db = db;
        }

        #endregion

        #region .:: Crud ::.
        public async Task Add(TEntity entity)
        {
            entity = BeforAdd(entity);
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                    tc.Commit();
                    ClearEntityCache();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        public async Task Delete(Func<TEntity, bool> predicate)
        {
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Set<TEntity>().Where(predicate).ToList().ForEach(del => _db.Set<TEntity>().Remove(del));
                    await _db.SaveChangesAsync();
                    tc.Commit();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        public async Task<ICollection<TEntity>> GetListAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<int> GetListAllCount(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).CountAsync();
        }

        public async Task<ICollection<TEntity>> GetList(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
                query = query.Where(where).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();
        }


        public async Task<ICollection<TEntity>> GetListOrderByDescending(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDescending = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
                query = query.Where(where).OrderByDescending(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);

            if (orderByDescending != null)
                return await orderByDescending(query).ToListAsync();
            else
                return await query.ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetListPrimitive(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
            {
                var initialQuery = query.Where(where);
                var orderedQuery = orderBy(initialQuery);
                query = orderedQuery.Skip(pagination.PageSkip).Take(pagination.PageTake);

                //query = query.Where(where).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<ICollection<TEntity>> GetInclude(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            //return _db.Set<TEntity>().Where(where).Include(include).AsQueryable();

            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
            {
                if (include != null)
                {
                    if (include.Body is NewExpression)
                    {
                        (include.Body as NewExpression).Arguments.ToList().ForEach(x =>
                        {
                            var inc = x as MemberExpression;
                            string s = inc.ToString();
                            s = s.Substring(s.IndexOf('.') + 1);
                            query = query.Include(s);
                        });

                        query = query.Where(where).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);
                    }
                    else
                    {
                        query = query.Where(where).Include(include).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);
                    }
                }
                else
                {
                    query = query.Where(where).Include(include).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);
                }
            }



            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<ICollection<TEntity>> GetIncludeNotPagination(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
            {
                if (include != null)
                {
                    if (include.Body is NewExpression)
                    {
                        (include.Body as NewExpression).Arguments.ToList().ForEach(x =>
                        {
                            var inc = x as MemberExpression;
                            string s = inc.ToString();
                            s = s.Substring(s.IndexOf('.') + 1);
                            query = query.Include(s);
                        });

                        query = query.Where(where);
                    }
                    else
                    {
                        query = query.Where(where).Include(include);
                    }
                }
                else
                {
                    query = query.Where(where).Include(include);
                }
            }


            return await query.ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetIncludeNotPaginationAsNoTracking(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
            {
                if (include != null)
                {
                    if (include.Body is NewExpression)
                    {
                        (include.Body as NewExpression).Arguments.ToList().ForEach(x =>
                        {
                            var inc = x as MemberExpression;
                            string s = inc.ToString();
                            s = s.Substring(s.IndexOf('.') + 1);
                            query = query.Include(s);
                        });

                        query = query.Where(where);
                    }
                    else
                    {
                        query = query.Where(where).Include(include);
                    }
                }
                else
                {
                    query = query.Where(where).Include(include);
                }
            }


            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            entity = BeforUpdate(entity);
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    tc.Commit();
                    ClearEntityCache();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        public async Task<TEntity> Get(params object[] Keys)
        {

            TEntity entity = await _db.Set<TEntity>().FindAsync(Keys);
            return entity;
        }

        public async Task<ICollection<TEntity>> GetPerField(Expression<Func<TEntity, bool>> where)
        {
            ICollection<TEntity> entity = await _db.Set<TEntity>().Where(where).ToListAsync();
            return entity;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
        #endregion

        #region .:: Methods Helpers ::.
        public virtual TEntity BeforAdd(TEntity entity)
        {
            entity.Active = true;
            entity.UserID = 1;
            entity.UserIDLastUpdate = 1;
            entity.CreateDate = DateTime.Now;
            entity.ModifieldDate = DateTime.Now;
            return entity;
        }

        public virtual TEntity BeforUpdate(TEntity entity)
        {
            entity.UserIDLastUpdate = entity.UserIDLastUpdate;
            entity.ModifieldDate = DateTime.Now;
            return entity;
        }

        // Métodos Internos
        private void ClearEntityCache()
        {
            try
            {
                foreach (EntityEntry dbEntityEntry in _db.ChangeTracker.Entries())
                    if (dbEntityEntry.Entity != null)
                        dbEntityEntry.State = EntityState.Detached;
            }
            catch
            {
            }
        }

        //private static int? IdUsuario
        //{
        //    get
        //    {
        //        if (HttpContext.Current != null)
        //        {
        //            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;

        //            var claim = identity.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier));
        //            if (claim != null)
        //                return int.Parse(claim.Value);
        //        }
        //        return null;
        //    }
        //}

        //public static IEnumerable<Claim> UserClaims
        //{
        //    get
        //    {
        //        if (HttpContext.Current == null)
        //            return null;

        //        var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
        //        return identity.Claims;
        //    }
        //}

        #endregion
    }
}
