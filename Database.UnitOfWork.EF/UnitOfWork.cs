using Database.UnitOfWork.Contracts;
using Microsoft.EntityFrameworkCore;

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

        /// <inheritdoc/>
        public override void RejectChanges<TEntity>()
        {
            foreach (var entry in Context.ChangeTracker.Entries<TEntity>())
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

        /// <inheritdoc/>
        public override void SaveChanges()
        {
            using var transaction = Context.Database.BeginTransaction();

            try
            {
                SaveChangesInternal();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                RejectAllChanges();
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task SaveChangesAsync()
        {
            await using var transaction = await Context.Database.BeginTransactionAsync();

            try
            {
                await SaveChangesAsyncInternal();
                await transaction.CommitAsync().ConfigureAwait(false);
            }
            catch
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                RejectAllChanges();
                throw;
            }
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            if (!_isDisposed)
            {
                Context.Dispose();

                _isDisposed = true;

                GC.SuppressFinalize(this);
            }
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
    }
}
