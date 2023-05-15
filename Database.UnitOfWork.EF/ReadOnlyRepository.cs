using Database.UnitOfWork.Contracts;
using Database.UnitOfWork.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.UnitOfWork.EF
{
    /// <inheritdoc/>
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        protected DbContext Context { get; }

        public ReadOnlyRepository(DbContext dbContext)
        {
            Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> Read() => Context.Set<TEntity>().AsNoTracking();
    }
}
