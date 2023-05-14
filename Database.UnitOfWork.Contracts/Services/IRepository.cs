using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts.Services
{
    /// <summary>
    /// Base repositories interface
    /// </summary>
    public interface IRepository
    {
    }

    /// <summary>
    /// Repository for read and edit data
    /// </summary>
    /// <typeparam name="TEntity">Database entity type</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : EntityBase
    {
        /// <summary>
        /// Reads all entities
        /// </summary>
        /// <returns>Entities from database</returns>
        IQueryable<TEntity> Read();

        /// <summary>
        /// Adds entity to database
        /// </summary>
        /// <param name="item">Item to add</param>
        void Add(TEntity item);

        /// <summary>
        /// Updates modified entity
        /// </summary>
        /// <param name="item">Item to update</param>
        void Update(TEntity item);

        /// <summary>
        /// Deletes entity from database
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(TEntity item);
    }
}
