using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts.Services
{
    /// <summary>
    /// Repository for read and edit data
    /// </summary>
    /// <typeparam name="TEntity">Database entity type</typeparam>
    public interface IRepository<TEntity> where TEntity : EntityBase
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
        /// Updades modified entity
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
