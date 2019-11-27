using DeliciousRestaurant.Application.Interfaces;
using Moq;
using NUnit.Framework;
namespace DeliciousRestaurant.Application.Test
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void BaseSetUp()
        {
            Context = new Mock<IContext>().Object;
        }

        public IContext Context { get; protected set; }
    }
}