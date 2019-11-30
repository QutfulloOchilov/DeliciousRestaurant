using DeliciousRestaurant.Application.Customers.Commands.Delete;
using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Exceptions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;

namespace DeliciousRestaurant.Application.Test.CustomerTests.Delete
{
    [TestFixture]
    public class DeleteCustomerCommandHandlerTests : TestBase
    {
        DeleteCustomerCommandHandler _deleteCustomerCommandHandler;
        IDeleteCustomerCommand _deleteCustomerCommand;

        [SetUp]
        public void SetUp()
        {
            _deleteCustomerCommandHandler = new DeleteCustomerCommandHandler(UnitOfWork, Mapper);
        }

        [Test]
        public void DeleteCustomerCommandHandler_Handle_InvalidRequest_ThrowException_Test()
        {
            var dateleCustomerCommandMock = new Mock<IDeleteCustomerCommand>() { CallBase = true };
            dateleCustomerCommandMock.Setup(m => m.IsValid()).Returns(false);
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("", "Request is invalid"));
            dateleCustomerCommandMock.Setup(m => m.ValidationResult).Returns(validationResult);
            _deleteCustomerCommand = dateleCustomerCommandMock.Object;

            Assert.ThrowsAsync<MultipleValidationFailedException>(async () => await _deleteCustomerCommandHandler.Handle(_deleteCustomerCommand));
        }

        [Test]
        public void DeleteCustomerCommandHandler_Handle_ValidRequest_ShouldNotThrowException_Test()
        {
            UnitOfWorkMock.Setup(u => u.CustomerRepository).Returns(new Mock<ICustomerRepository>().Object);
            _deleteCustomerCommandHandler = new DeleteCustomerCommandHandler(UnitOfWorkMock.Object, Mapper);
            var dateleCustomerCommandMock = new Mock<IDeleteCustomerCommand>();
            dateleCustomerCommandMock.Setup(m => m.IsValid()).Returns(true);
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("", "Request is invalid"));
            dateleCustomerCommandMock.Setup(m => m.ValidationResult).Returns(validationResult);
            _deleteCustomerCommand = dateleCustomerCommandMock.Object;

            Assert.DoesNotThrowAsync(async () => await _deleteCustomerCommandHandler.Handle(_deleteCustomerCommand));
        }

    }
}
