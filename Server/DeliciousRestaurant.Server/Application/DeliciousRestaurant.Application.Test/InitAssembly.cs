using Autofac;
using DeliciousRestaurant.IoC;
using NUnit.Framework;
namespace DeliciousRestaurant.Application.Test
{
    [SetUpFixture]
    public class InitAssembly
    {
        public static IContainer Container { get; private set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            NativeInjectorBootStrapper.RegisterServices(builder);
            Container = builder.Build();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }
    }
}
