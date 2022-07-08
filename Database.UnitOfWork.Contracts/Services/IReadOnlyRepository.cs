using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts.Services
{
    /// <summary>
    /// Repository for reading data
    /// </summary>
    /// <typeparam name="TEntity">Database entity type</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Read all entities
        /// </summary>
        /// <returns>Entities from database</returns>
        IQueryable<TEntity> Read();
    }
}
