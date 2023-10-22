using Database.UnitOfWork.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Database.UnitOfWork.EF
{
    /// <inheritdoc/>
    public class UnitOfWork : UnitOfWorkBase
    {
        private bool _isDisposed = false;

        protected DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public override void RejectAllChanges()
        {
            foreach (var entry in Context.ChangeTracker.Entries())
            {
                RejectEntry(entry);
            }
        }

        /// <inheritdoc/>
        public override void RejectChanges<TEntity>()
        {
            foreach (var entry in Context.ChangeTracker.Entries<TEntity>())
            {
                RejectEntry(entry);
            }
        }

        /// <inheritdoc/>
        public override void SaveChanges()
        {
            SaveChangesInternal();
        }

        /// <inheritdoc/>
        public override Task SaveChangesAsync() => SaveChangesAsyncInternal();

        /// <inheritdoc/>
        public override void Dispose()
        {
            if (_isDisposed)
                return;

            Context.Dispose();

            _isDisposed = true;

            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected override IReadOnlyRepository<TEntity> CreateReadOnlyRepository<TEntity>() => new ReadOnlyRepository<TEntity>(Context);

        /// <inheritdoc/>
        protected override IRepository<TEntity> CreateRepository<TEntity>() => new Repository<TEntity>(Context);

        /// <summary>
        /// Saves changes, override it to implement additional work with files etc
        /// </summary>
        protected virtual void SaveChangesInternal() => Context.SaveChanges();

        /// <summary>
        /// Save changes async, override it to implement additional work with files etc
        /// </summary>
        protected virtual async Task SaveChangesAsyncInternal() => await Context.SaveChangesAsync().ConfigureAwait(false);

        private static void RejectEntry(EntityEntry entry)
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.State = EntityState.Modified; // revert changes made to deleted entity
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }
}
