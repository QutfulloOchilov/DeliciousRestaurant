using Autofac;
using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Persistence.Database;
using DeliciousRestaurant.Persistence.Repositories;
using System;

namespace DeliciousRestaurant.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            BuildRepositories(builder);
        }

        private static void BuildRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DeliciousRestaurantContext>().As<IContext>().InstancePerLifetimeScope();
        }
    }
}
