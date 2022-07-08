using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts.Services
{
    /// <summary>
    /// Manage work with database
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get read only repository for entity type
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Read only repository</returns>
        IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : EntityBase;

        /// <summary>
        /// Get repository for entity type
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Repository</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;

        /// <summary>
        /// Save all models changes to DB
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Save all models changes to DB async
        /// </summary>
        /// <returns>Async task</returns>
        Task SaveChangesAsync();

        /// <summary>
        /// Reject all models unsaved changes
        /// </summary>
        void RejectAllChanges();

        /// <summary>
        /// Reject entity type model unsaved changes
        /// </summary>
        /// <typeparam name="TEntity">Entity type to reject changes</typeparam>
        void RejectChanges<TEntity>() where TEntity : EntityBase;
    }
}
