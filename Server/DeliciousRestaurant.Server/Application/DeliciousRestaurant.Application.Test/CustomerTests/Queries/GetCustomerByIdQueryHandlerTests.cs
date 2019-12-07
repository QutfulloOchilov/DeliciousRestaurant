using DeliciousRestaurant.Application.Customers.Data;
using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Customers.Queries.GetCustomerById;
using DeliciousRestaurant.Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Test.CustomerTests.Queries
{
    [TestFixture]
    public class GetCustomerByIdQueryHandlerTests : TestBase
    {
        [Test]
        public async Task GetCustomerByIdQueryHandler_Handler_EmptyGuid_ShouldBeNull_Test()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var getCustomerByIdQueryMock = new Mock<IGetCustomerByIdQuery>();

            customerRepositoryMock.Setup(c => c.GetByIdAsync(Guid.Empty, default)).ReturnsAsync(default(Customer));
            UnitOfWorkMock.Setup(u => u.CustomerRepository).Returns(customerRepositoryMock.Object);
            getCustomerByIdQueryMock.Setup(q => q.Id).Returns(Guid.Empty);

            var getCustomerByIdQuery = getCustomerByIdQueryMock.Object;
            var getCustomerByIdQueryHandler = new GetCustomerByIdQueryHandler(UnitOfWork, Mapper);

            Assert.AreEqual(null, await getCustomerByIdQueryHandler.Handle(getCustomerByIdQuery));
        }

        [Test]
        public async Task GetCustomerByIdQueryHandler_Handler_WrongId_ShouldBeNull_Test()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var getCustomerByIdQueryMock = new Mock<IGetCustomerByIdQuery>();
            var notExistCustomerId = Guid.NewGuid();

            customerRepositoryMock.Setup(c => c.GetByIdAsync(notExistCustomerId, default)).ReturnsAsync(default(Customer));
            UnitOfWorkMock.Setup(u => u.CustomerRepository).Returns(customerRepositoryMock.Object);
            getCustomerByIdQueryMock.Setup(q => q.Id).Returns(notExistCustomerId);

            var getCustomerByIdQuery = getCustomerByIdQueryMock.Object;
            var getCustomerByIdQueryHandler = new GetCustomerByIdQueryHandler(UnitOfWork, Mapper);

            Assert.AreEqual(null, await getCustomerByIdQueryHandler.Handle(getCustomerByIdQuery));
        }

        [Test]
        public async Task GetCustomerByIdQueryHandler_Handler_Correct_ShouldBeCustomer_Test()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var getCustomerByIdQueryMock = new Mock<IGetCustomerByIdQuery>();
            var customerId = Guid.NewGuid();
            var customer = new Customer();
            var customerDTO = Mapper.Map<CustomerDTO>(customer);

            customerRepositoryMock.Setup(c => c.GetByIdAsync(customerId, default)).ReturnsAsync(customer);
            UnitOfWorkMock.Setup(u => u.CustomerRepository).Returns(customerRepositoryMock.Object);
            getCustomerByIdQueryMock.Setup(q => q.Id).Returns(customerId);

            var getCustomerByIdQuery = getCustomerByIdQueryMock.Object;
            var getCustomerByIdQueryHandler = new GetCustomerByIdQueryHandler(UnitOfWork, Mapper);
            Assert.NotNull(await getCustomerByIdQueryHandler.Handle(getCustomerByIdQuery));
        }
    }
}