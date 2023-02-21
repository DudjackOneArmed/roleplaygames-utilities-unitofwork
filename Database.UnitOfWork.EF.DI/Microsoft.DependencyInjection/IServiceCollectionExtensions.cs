using Database.UnitOfWork.Contracts.Entities;
using Database.UnitOfWork.Contracts.Services;
using Database.UnitOfWork.EF.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds unit of work
        /// </summary>
        public static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient<IQueryableAsyncExecutor, QueryableAsyncExecutor>();
        }

        /// <summary>
        /// Adds custom unit of work
        /// </summary>
        /// <typeparam name="TUnitOfWork">Custom unit of work type</typeparam>
        public static IServiceCollection AddUnitOfWork<TUnitOfWork>(this IServiceCollection serviceCollection) where TUnitOfWork : UnitOfWork
        {
            return serviceCollection
                .AddScoped<IUnitOfWork, TUnitOfWork>()
                .AddTransient<IQueryableAsyncExecutor, QueryableAsyncExecutor>();
            ;
        }

        /// <summary>
        /// Adds repositories for entity type from unit of work
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        public static IServiceCollection AddRepository<TEntity>(this IServiceCollection serviceCollection) where TEntity : EntityBase
        {
            return serviceCollection
                .AddScoped(x => x.GetService<IUnitOfWork>()!.GetReadOnlyRepository<TEntity>())
                .AddScoped(x => x.GetService<IUnitOfWork>()!.GetRepository<TEntity>());
        }
    }
}
