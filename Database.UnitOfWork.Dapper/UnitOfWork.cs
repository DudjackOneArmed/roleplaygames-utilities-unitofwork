using Database.UnitOfWork.Contracts;

namespace Database.UnitOfWork.Dapper
{
    /// <inheritdoc/>
    public class UnitOfWork : UnitOfWorkBase
    {
        private bool _isDisposed = false;
        private IDbTransaction _transaction;

        /// <summary>
        /// Current connection
        /// </summary>
        protected IDbConnection Connection { get; }

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;

            Connection.Open();
            _transaction = Connection.BeginTransaction();
        }

        /// <inheritdoc/>
        public override void Dispose()
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
        public override void SaveChanges()
        {
            _transaction.Commit();
            RecreateTransaction();
        }

        /// <inheritdoc/>
        public override Task SaveChangesAsync()
        {
            return Task.Run(SaveChanges);
        }

        /// <inheritdoc/>
        public override void RejectAllChanges()
        {
            _transaction.Rollback();
            RecreateTransaction();
        }

        /// <inheritdoc/>
        public override void RejectChanges<TEntity>()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override IReadOnlyRepository<TEntity> CreateReadOnlyRepository<TEntity>() => new ReadOnlyRepository<TEntity>(Connection);

        /// <inheritdoc/>
        protected override IRepository<TEntity> CreateRepository<TEntity>() => new Repository<TEntity>(Connection);

        /// <summary>
        /// Closes old transactions and creates new one
        /// </summary>
        protected void RecreateTransaction()
        {
            _transaction.Dispose();
            _transaction = Connection.BeginTransaction();
        }
    }
}
