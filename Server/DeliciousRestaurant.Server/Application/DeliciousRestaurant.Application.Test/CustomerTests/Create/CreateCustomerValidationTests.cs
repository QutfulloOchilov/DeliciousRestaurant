using DeliciousRestaurant.Application.Customers.Commands.Create;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using System;

namespace DeliciousRestaurant.Application.Test.CustomerTests.Create
{
    [TestFixture]
    public class CreateCustomerValidationTests : TestBase
    {
        CreateCustomerValidation _createCustomerValidation;
        ICreateCustomerCommand _createCustomerCommand;

        [SetUp]
        public void SetUp()
        {
            _createCustomerValidation = new CreateCustomerValidation();
            _createCustomerValidation.ValidateIdentityUserId();
        }

        [Test]
        public void ValidateIdentityUserId_Null_ShouldHaveValiationError_Test()
        {
            var createCustomerCommandMock = new Mock<ICreateCustomerCommand>() { CallBase = true };
            createCustomerCommandMock.Setup(p => p.IdentityUserId).Returns(() => { return null; });
            _createCustomerCommand = createCustomerCommandMock.Object;
            _createCustomerValidation.ShouldHaveValidationErrorFor(c => c.IdentityUserId, _createCustomerCommand);
        }

        [Test]
        public void ValidateIdentityUserId_Empty_ShouldHaveValiationError_Test()
        {
            var createCustomerCommandMock = new Mock<ICreateCustomerCommand>() { CallBase = true };
            createCustomerCommandMock.Setup(p => p.IdentityUserId).Returns(string.Empty);
            _createCustomerCommand = createCustomerCommandMock.Object;
            _createCustomerValidation.ShouldHaveValidationErrorFor(c => c.IdentityUserId, _createCustomerCommand);
        }

        [Test]
        public void ValidateIdentityUserId_NotEmpty_ShouldHaveValiationError_Test()
        {
            var createCustomerCommandMock = new Mock<ICreateCustomerCommand>() { CallBase = true };
            createCustomerCommandMock.Setup(p => p.IdentityUserId).Returns(Guid.NewGuid().ToString());
            _createCustomerCommand = createCustomerCommandMock.Object;
            _createCustomerValidation.ShouldNotHaveValidationErrorFor(c => c.IdentityUserId, _createCustomerCommand);
        }
    }
}