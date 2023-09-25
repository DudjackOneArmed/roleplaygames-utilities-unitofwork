using Database.UnitOfWork.Contracts.Entities;
using System.Reflection;
using Database.UnitOfWork.Contracts.Exceptions;
using Database.UnitOfWork.Contracts;

namespace Database.UnitOfWork
{
    /// <inheritdoc/>
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private Dictionary<Type, object>? _allRepositories;

        private Dictionary<Type, object> AllRepositories => _allRepositories ??= GetAllRepositories();

        ~UnitOfWorkBase()
        {
            Dispose();
        }

        /// <inheritdoc/>
        public virtual IReadOnlyRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : EntityBase
        {
            if (GetRepository(typeof(IReadOnlyRepository<TEntity>)) is IReadOnlyRepository<TEntity> repository)
            {
                return repository;
            }

            var newRepository = CreateReadOnlyRepository<TEntity>();

            AllRepositories[typeof(IReadOnlyRepository<TEntity>)] = newRepository;

            return newRepository;
        }

        /// <inheritdoc/>
        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            if (GetRepository(typeof(IRepository<TEntity>)) is IRepository<TEntity> repository)
            {
                return repository;
            }

            var newRepository = CreateRepository<TEntity>();

            AllRepositories[typeof(IRepository<TEntity>)] = newRepository;

            return newRepository;
        }

        /// <inheritdoc/>
        public virtual TRepository GetCustomRepository<TRepository>() where TRepository : class, IRepository
        {
            return GetRepository(typeof(TRepository)) is TRepository repository
                ? repository
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

        private object? GetRepository(Type repositoryType) => AllRepositories.TryGetValue(repositoryType, out var repository) ? repository : null;

        private Dictionary<Type, object> GetAllRepositories()
        {
            return GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType.IsAssignableTo(typeof(IRepository)))
                .GroupBy(x => x.PropertyType)
                .ToDictionary(x => x.Key, x => x.Last().GetValue(this));
        }
    }
}
