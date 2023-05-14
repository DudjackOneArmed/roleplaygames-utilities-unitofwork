using Database.UnitOfWork.Contracts.Entities;
using Database.UnitOfWork.Contracts.Services;
using System.Reflection;
using Database.UnitOfWork.Contracts.Exceptions;

namespace Database.UnitOfWork
{
    /// <inheritdoc/>
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        ~UnitOfWorkBase()
        {
            Dispose();
        }

        /// <inheritdoc/>
        public virtual IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : EntityBase
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.GetValue(this))
                .OfType<IReadOnlyRepository<TEntity>>()
                .ToList();

            return properties.Any()
                ? (properties.Count == 1
                    ? properties.First()
                    : throw new MoreThanOneRepositoriesFoundException(typeof(IReadOnlyRepository<TEntity>), GetType()))
                : CreateReadOnlyRepository<TEntity>();
        }

        /// <inheritdoc/>
        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.GetValue(this))
                .OfType<IRepository<TEntity>>()
                .ToList();

            return properties.Any()
                ? (properties.Count == 1
                    ? properties.First()
                    : throw new MoreThanOneRepositoriesFoundException(typeof(IRepository<TEntity>), GetType()))
                : CreateRepository<TEntity>();
        }

        /// <inheritdoc/>
        public virtual TRepository GetCustomRepository<TRepository>() where TRepository : class, IRepository
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.GetValue(this))
                .OfType<TRepository>()
                .ToList();

            return properties.Any()
                ? (properties.Count == 1
                    ? properties.First()
                    : throw new MoreThanOneRepositoriesFoundException(typeof(TRepository), GetType()))
                : throw new CustomRepositoryNotFoundException(typeof(TRepository), GetType());
        }

        /// <inheritdoc/>
        public abstract void SaveChanges();

        /// <inheritdoc/>
        public abstract Task SaveChangesAsync();

        /// <inheritdoc/>
        public abstract void RejectAllChanges();

        /// <inheritdoc/>
        public abstract void RejectChanges<TEntity>() where TEntity : EntityBase;

        /// <inheritdoc/>
        public abstract void Dispose();

        /// <summary>
        /// Creates new readonly repository
        /// </summary>
        /// <typeparam name="TEntity">Repository entity type</typeparam>
        /// <returns>Readonly repository</returns>
        protected abstract IReadOnlyRepository<TEntity> CreateReadOnlyRepository<TEntity>() where TEntity : EntityBase;

        /// <summary>
        /// Creates new repository
        /// </summary>
        /// <typeparam name="TEntity">Repository entity type</typeparam>
        /// <returns>Repository</returns>
        protected abstract IRepository<TEntity> CreateRepository<TEntity>() where TEntity : EntityBase;
    }
}
