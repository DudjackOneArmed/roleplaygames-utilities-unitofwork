using Autofac;
using Database.UnitOfWork.Contracts.Services;

namespace Database.UnitOfWork.EF.DI.Autofac
{
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Register services for unit of work
        /// </summary>
        public static ContainerBuilder RegisterUnitOfWorkServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<Services.UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            return containerBuilder.RegisterRepositories();
        }

        /// <summary>
        /// Register services for custom unit of work
        /// </summary>
        /// <typeparam name="TUnitOfWork">Custom unit of work type</typeparam>
        public static ContainerBuilder RegisterUnitOfWorkServices<TUnitOfWork>(this ContainerBuilder containerBuilder) where TUnitOfWork : Services.UnitOfWork
        {
            containerBuilder
                .RegisterType<TUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            return containerBuilder.RegisterRepositories();
        }

        /// <summary>
        /// Register repositories from unit of work
        /// </summary>
        private static ContainerBuilder RegisterRepositories(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric((context, types, parameters) =>
            {
                if (types.Length != 1)
                    throw new InvalidOperationException($"Cannot get read only repository for not single generic type (count = {types.Length}).");

                var type = types.First();
                var unitOfWork = context.Resolve<IUnitOfWork>();
                var method = unitOfWork.GetType().GetMethod("GetReadOnlyRepository")?.MakeGenericMethod(type);

                return method?.Invoke(unitOfWork, null) ?? throw new InvalidOperationException($"Unit of work cannot get read only repository for {type}.");
            }).As(typeof(IReadOnlyRepository<>)).InstancePerRequest();

            containerBuilder.RegisterGeneric((context, types, parameters) =>
            {
                if (types.Length != 1)
                    throw new InvalidOperationException($"Cannot get repository for not single generic type (count = {types.Length}).");

                var type = types.First();
                var unitOfWork = context.Resolve<IUnitOfWork>();
                var method = unitOfWork.GetType().GetMethod("GetRepository")?.MakeGenericMethod(type);

                return method?.Invoke(unitOfWork, null) ?? throw new InvalidOperationException($"Unit of work cannot get repository for {type}.");
            }).As(typeof(IRepository<>)).InstancePerRequest();

            return containerBuilder;
        }
    }
}
