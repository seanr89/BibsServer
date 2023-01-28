using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Infrastructure.Contexts;

namespace Infrastructure.Repos;

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext _context { get; set; }
        //protected readonly IDbContextFactory _factory;
        public RepositoryBase()
        {
        }

        #region Non-Tracked

        public IQueryable<T> FindAllNotTracked()
        {
            return this._context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByConditionNotTracked(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).AsNoTracking();
        }

        #endregion

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public void SetContext(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }