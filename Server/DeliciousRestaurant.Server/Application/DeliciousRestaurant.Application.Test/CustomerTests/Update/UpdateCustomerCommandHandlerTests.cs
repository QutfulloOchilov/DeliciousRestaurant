using DeliciousRestaurant.Application.Customers.Commands.Update;
using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Exceptions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;

namespace DeliciousRestaurant.Application.Test.CustomerTests.Update
{
    public class UpdateCustomerCommandHandlerTests : TestBase
    {
        UpdateCustomerCommandHandler _updateCustomerCommandHandler;
        IUpdateCustomerCommand _updateCustomerCommand;

        [SetUp]
        public void SetUp()
        {
            _updateCustomerCommandHandler = new UpdateCustomerCommandHandler(UnitOfWork, Mapper);
        }

        [Test]
        public void UpdateCustomerCommandHandler_Handle_InvalidRequest_ThrowException_Test()
        {
            var updateCustomerCommandMock = new Mock<IUpdateCustomerCommand>() { CallBase = true };
            updateCustomerCommandMock.Setup(m => m.IsValid()).Returns(false);
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("", "Request is invalid"));
            updateCustomerCommandMock.Setup(m => m.ValidationResult).Returns(validationResult);
            _updateCustomerCommand = updateCustomerCommandMock.Object;

            Assert.ThrowsAsync<MultipleValidationFailedException>(async () => await _updateCustomerCommandHandler.Handle(_updateCustomerCommand));
        }

        [Test]
        public void UpdateCustomerCommandHandler_Handle_ValidRequest_ShouldNotThrowException_Test()
        {
            UnitOfWorkMock.Setup(u => u.CustomerRepository).Returns(new Mock<ICustomerRepository>().Object);
            _updateCustomerCommandHandler = new UpdateCustomerCommandHandler(UnitOfWorkMock.Object, Mapper);
            var updateCustomerCommandMock = new Mock<IUpdateCustomerCommand>();
            updateCustomerCommandMock.Setup(m => m.IsValid()).Returns(true);
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("", "Request is invalid"));
            updateCustomerCommandMock.Setup(m => m.ValidationResult).Returns(validationResult);
            _updateCustomerCommand = updateCustomerCommandMock.Object;

            Assert.DoesNotThrowAsync(async () => await _updateCustomerCommandHandler.Handle(_updateCustomerCommand));
        }

    }
}
