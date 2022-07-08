using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts.Services
{
    /// <summary>
    /// Repository for read and edit data
    /// </summary>
    /// <typeparam name="TEntity">Database entity type</typeparam>
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="item">Item to add</param>
        void Add(TEntity item);

        /// <summary>
        /// Updade modified entity
        /// </summary>
        /// <param name="item">Item to update</param>
        void Update(TEntity item);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(TEntity item);
    }
}
