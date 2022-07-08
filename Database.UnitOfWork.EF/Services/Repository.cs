﻿using Database.UnitOfWork.Contracts.Entities;
using Database.UnitOfWork.Contracts.Services;
using Microsoft.EntityFrameworkCore;

namespace Database.UnitOfWork.EF.Services
{
    /// <inheritdoc/>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected DbContext Context { get; }

        public Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public virtual void Add(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        /// <inheritdoc/>
        public virtual void Delete(TEntity item)
        {
            var set = Context.Set<TEntity>();

            if (Context.Entry(item).State == EntityState.Detached)
                set.Attach(item);

            set.Remove(item);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> Read()
        {
            return Context.Set<TEntity>();
        }

        /// <inheritdoc/>
        public virtual void Update(TEntity item)
        {
            Context.Set<TEntity>().Attach(item);
            Context.Entry(item).State = EntityState.Modified;
        }
    }
}
