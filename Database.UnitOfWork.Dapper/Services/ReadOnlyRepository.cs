using Database.UnitOfWork.Contracts.Entities;
using Database.UnitOfWork.Contracts.Services;

namespace Database.UnitOfWork.Dapper.Services
{
    /// <inheritdoc/>
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        protected IDbConnection Connection { get; }

        public ReadOnlyRepository(IDbConnection connection)
        {
            Connection = connection;
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> Read()
        {
            return Connection.GetAll<TEntity>().AsQueryable();
        }
    }
}
