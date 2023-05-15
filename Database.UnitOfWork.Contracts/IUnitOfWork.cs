using Database.UnitOfWork.Contracts.Entities;

namespace Database.UnitOfWork.Contracts
{
    /// <summary>
    /// Manages work with database
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets read only repository for entity type
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Read only repository</returns>
        IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : EntityBase;

        /// <summary>
        /// Gets repository for entity type
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Repository</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;

        /// <summary>
        /// Gets custom repository from fields
        /// </summary>
        /// <typeparam name="TRepository">Repository type</typeparam>
        /// <returns>Repository filed</returns>
        TRepository GetCustomRepository<TRepository>() where TRepository : class, IRepository;

        /// <summary>
        /// Saves all models changes to DB
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Saves all models changes to DB async
        /// </summary>
        /// <returns>Async task</returns>
        Task SaveChangesAsync();

        /// <summary>
        /// Rejects all models unsaved changes
        /// </summary>
        void RejectAllChanges();

        /// <summary>
        /// Rejects entity type model unsaved changes
        /// </summary>
        /// <typeparam name="TEntity">Entity type to reject changes</typeparam>
        void RejectChanges<TEntity>() where TEntity : EntityBase;
    }
}
