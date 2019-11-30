using Autofac;
using AutoMapper;
using DeliciousRestaurant.Application.AutoMapper;
using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Persistence.Database;
using DeliciousRestaurant.Persistence.Repositories;

namespace DeliciousRestaurant.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            RegisterMaps(builder);
            BuildRepositories(builder);
        }

        /// <summary>
        /// Registers the AutoMapper profile 
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void RegisterMaps(ContainerBuilder builder)
        {
            builder.Register(c => AutoMapperConfig.RegisterMappings()).As<IMapper>().InstancePerLifetimeScope();
        }

        private static void BuildRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DeliciousRestaurantContext>().As<IContext>().InstancePerLifetimeScope();
        }
    }
}
