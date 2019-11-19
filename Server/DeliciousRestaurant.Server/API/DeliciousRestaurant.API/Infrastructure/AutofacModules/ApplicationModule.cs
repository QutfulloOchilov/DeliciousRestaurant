using Autofac;
using DeliciousRestaurant.API.Persistence;
using DeliciousRestaurant.IoC;
using DeliciousRestaurant.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DeliciousRestaurant.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        public ApplicationModule(string connectionString, IServiceCollection services)
        {
            ConnectionString = connectionString;
            Services = services;
        }

        public string ConnectionString { get; }
        public IServiceCollection Services { get; }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DeliciousRestaurantContextOptionBuilder>().As<BaseDeliciousRestaurantContextOptionBuilder>().SingleInstance();
            NativeInjectorBootStrapper.RegisterServices(builder);
        }
    }
}
