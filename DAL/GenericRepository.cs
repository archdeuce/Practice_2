using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ProductDbContext context;
        internal DbSet<TEntity> dbSet;
        private bool disposed = false;

        public GenericRepository()
        {
            this.context = new ProductDbContext();
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;

            return query.ToList();
        }

        public virtual TEntity Get(int TEntityId)
        {
            return this.dbSet.Find(TEntityId);
        }

        public virtual void Add(TEntity TEntity)
        {
            this.dbSet.Add(TEntity);
        }

        public virtual void Delete(int TEntityId)
        {
            TEntity entityToDelete = this.dbSet.Find(TEntityId);
            this.Delete(entityToDelete);
        }

        public virtual void Delete(TEntity TEntity)
        {
            if (this.context.Entry(TEntity).State == EntityState.Detached)
                this.dbSet.Attach(TEntity);

            this.dbSet.Remove(TEntity);
        }

        public virtual void Update(TEntity TEntity)
        {
            this.dbSet.Attach(TEntity);
            this.context.Entry(TEntity).State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this.context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
