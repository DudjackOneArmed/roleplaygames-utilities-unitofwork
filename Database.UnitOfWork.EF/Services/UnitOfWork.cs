using Database.UnitOfWork.Contracts.Entities;
using Database.UnitOfWork.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Database.UnitOfWork.EF.Services
{
    /// <inheritdoc/>
    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed = false;

        protected DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        /// <inheritdoc/>
        public IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : EntityBase
        {
            var repos = (from property in GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         let generics = property.PropertyType.GetGenericArguments()
                         where generics.Length == 1 && generics.First() == typeof(TEntity)
                         select property.GetValue(this));

            return repos.OfType<IReadOnlyRepository<TEntity>>().SingleOrDefault() ?? new ReadOnlyRepository<TEntity>(Context);
        }

        /// <inheritdoc/>
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            var repos = (from property in GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         let generics = property.PropertyType.GetGenericArguments()
                         where generics.Length == 1 && generics.First() == typeof(TEntity)
                         select property.GetValue(this));

            return repos.OfType<IRepository<TEntity>>().SingleOrDefault() ?? new Repository<TEntity>(Context);
        }

        /// <inheritdoc/>
        public void RejectAllChanges()
        {
            foreach (var entry in Context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; // revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        /// <inheritdoc/>
        public void RejectChanges<TEntity>() where TEntity : EntityBase
        {
            foreach (var entry in Context.ChangeTracker.Entries<TEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; // revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        /// <inheritdoc/>
        public void SaveChanges()
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
        public async Task SaveChangesAsync()
        {
            using var transaction = await Context.Database.BeginTransactionAsync();

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
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern
        /// </summary>
        /// <param name="isDisposing">Is dispose is used</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                Context.Dispose();

                _isDisposed = true;
            }
        }

        protected virtual void SaveChangesInternal() => Context.SaveChanges();

        protected virtual async Task SaveChangesAsyncInternal() => await Context.SaveChangesAsync().ConfigureAwait(false);
    }
}
