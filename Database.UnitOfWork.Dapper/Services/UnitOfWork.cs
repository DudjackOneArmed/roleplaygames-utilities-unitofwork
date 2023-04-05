using Database.UnitOfWork.Contracts.Entities;
using Database.UnitOfWork.Contracts.Services;
using Database.UnitOfWork.Dapper.Exceptions;
using System.Reflection;

namespace Database.UnitOfWork.Dapper.Services
{
    /// <inheritdoc/>
    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed = false;
        private IDbTransaction _transaction;

        protected IDbConnection Connection { get; }

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;

            Connection.Open();
            _transaction = Connection.BeginTransaction();
        }

        ~UnitOfWork()
        {
            Dispose();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                Connection.Close();
                Connection.Dispose();

                _isDisposed = true;

                GC.SuppressFinalize(this);
            }
        }

        /// <inheritdoc/>
        public virtual IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : EntityBase
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.GetValue(this))
                .OfType<IReadOnlyRepository<TEntity>>()
                .ToList();

            return properties.Any()
                ? (properties.Count == 1
                    ? properties.First()
                    : throw new MoreThanOneRepositoriesUnitOfWorkException($"More than one readonly ripository registered in Unit of work {GetType()}"))
                : new ReadOnlyRepository<TEntity>(Connection);
        }

        /// <inheritdoc/>
        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.GetValue(this))
                .OfType<IRepository<TEntity>>()
                .ToList();

            return properties.Any()
                ? (properties.Count == 1
                    ? properties.First()
                    : throw new MoreThanOneRepositoriesUnitOfWorkException($"More than one readonly ripository registered in Unit of work {GetType()}"))
                : new Repository<TEntity>(Connection);
        }

        /// <inheritdoc/>
        public virtual void SaveChanges()
        {
            _transaction.Commit();
            RecreateTransaction();
        }

        /// <inheritdoc/>
        public virtual Task SaveChangesAsync()
        {
            return Task.Run(SaveChanges);
        }

        /// <inheritdoc/>
        public virtual void RejectAllChanges()
        {
            _transaction.Rollback();
            RecreateTransaction();
        }

        /// <inheritdoc/>
        public virtual void RejectChanges<TEntity>() where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        protected void RecreateTransaction()
        {
            _transaction.Dispose();
            _transaction = Connection.BeginTransaction();
        }
    }
}
