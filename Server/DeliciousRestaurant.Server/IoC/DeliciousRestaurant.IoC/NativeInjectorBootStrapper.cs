using Autofac;
using DeliciousRestaurant.Application.Customers.Interfaces;
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
            builder.RegisterType<ICustomerRepository>().As<CustomerRepository>().InstancePerDependency();
        }
    }
}
