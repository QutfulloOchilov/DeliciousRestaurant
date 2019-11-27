using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DeliciousRestaurant.API.Infrastructure.AutofacModules;
using DeliciousRestaurant.Persistence.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FluentValidation;
using FluentValidation.AspNetCore;

using DeliciousRestaurant.Application.Commands;

namespace DeliciousRestaurant.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; protected set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCustomMvc();
            services.AddDbContext<DeliciousRestaurantContext>(ServiceLifetime.Scoped).AddEntityFrameworkSqlServer().AddEntityFrameworkProxies();
            // Create a Autofac container builder
            var builder = new ContainerBuilder();

            // Read service collection to Autofac
            builder.Populate(services);

            // Use and configure Autofac
            builder.RegisterModule(new ApplicationModule(Configuration["ConnectionString"], services));
            builder.Register((IContainer) => { return Container; }).As<IContainer>().SingleInstance();
            // build the Autofac container
            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    static class CustomExtensionsMethods
    {
        public static void AddCustomMvc(this IServiceCollection services)
        {
            services
                .AddMvc(option=> 
                {
                    option.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(mvc => mvc.RegisterValidatorsFromAssemblyContaining<IBaseValidation>());
        }
    }
}

