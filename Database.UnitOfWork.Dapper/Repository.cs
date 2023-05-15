using Dapper.Contrib.Extensions;
using Database.UnitOfWork.Contracts;
using Database.UnitOfWork.Contracts.Entities;
using System.Data;

namespace Database.UnitOfWork.Dapper
{
    /// <inheritdoc/>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected IDbConnection Connection { get; }

        public Repository(IDbConnection connection)
        {
            Connection = connection;
        }

        /// <inheritdoc/>
        public virtual void Add(TEntity item)
        {
            Connection.Insert(item);
        }

        /// <inheritdoc/>
        public virtual void Delete(TEntity item)
        {
            Connection.Delete(item);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> Read()
        {
            return Connection.GetAll<TEntity>().AsQueryable();
        }

        /// <inheritdoc/>
        public virtual void Update(TEntity item)
        {
            Connection.Update(item);
        }
    }
}
