using DeliciousRestaurant.Application.Customers.Commands.Create;
using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Exceptions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;

namespace DeliciousRestaurant.Application.Test.CustomerTests.Create
{
    public class CreateCustomerCommandHandlerTests : TestBase
    {
        CreateCustomerCommandHandler _createCustomerCommandHandler;
        ICreateCustomerCommand _createCustomerCommand;

        [SetUp]
        public void SetUp()
        {
            _createCustomerCommandHandler = new CreateCustomerCommandHandler(UnitOfWork, Mapper);
        }

        [Test]
        public void CreateCustomerCommandHandler_Handle_InvalidRequest_ThrowException_Test()
        {
            var createCustomerCommandMock = new Mock<ICreateCustomerCommand>() { CallBase = true };
            createCustomerCommandMock.Setup(m => m.IsValid()).Returns(false);
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("", "Request is invalid"));
            createCustomerCommandMock.Setup(m => m.ValidationResult).Returns(validationResult);
            _createCustomerCommand = createCustomerCommandMock.Object;
            
            Assert.ThrowsAsync<MultipleValidationFailedException>(async () => await _createCustomerCommandHandler.Handle(_createCustomerCommand));
        }

        [Test]
        public void CreateCustomerCommandHandler_Handle_ValidRequest_ShouldNotThrowException_Test()
        {
            UnitOfWorkMock.Setup(u => u.CustomerRepository).Returns(new Mock<ICustomerRepository>().Object);
            _createCustomerCommandHandler = new CreateCustomerCommandHandler(UnitOfWorkMock.Object, Mapper);
            var createCustomerCommandMock = new Mock<ICreateCustomerCommand>();
            createCustomerCommandMock.Setup(m => m.IsValid()).Returns(true);
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("", "Request is invalid"));
            createCustomerCommandMock.Setup(m => m.ValidationResult).Returns(validationResult);
            _createCustomerCommand = createCustomerCommandMock.Object;

            Assert.DoesNotThrowAsync(async () => await _createCustomerCommandHandler.Handle(_createCustomerCommand));
        }

    }
}