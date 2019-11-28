using AutoMapper;
using DeliciousRestaurant.Application.Interfaces;
using Moq;
using NUnit.Framework;
using Autofac;

namespace DeliciousRestaurant.Application.Test
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void BaseSetUp()
        {
            Context = new Mock<IContext>().Object;
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            UnitOfWorkMock.Setup(u => u.Context).Returns(Context);
            UnitOfWork = UnitOfWorkMock.Object;
            Mapper = InitAssembly.Container.Resolve<IMapper>();
        }

        public IUnitOfWork UnitOfWork { get; protected set; }
        public IContext Context { get; protected set; }
        public Mock<IUnitOfWork> UnitOfWorkMock { get; protected set; }
        public IMapper Mapper { get; protected set; }
    }
}