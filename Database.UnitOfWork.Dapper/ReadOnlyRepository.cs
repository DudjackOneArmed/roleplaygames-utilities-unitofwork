using Database.UnitOfWork.Contracts;
using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Dapper
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
