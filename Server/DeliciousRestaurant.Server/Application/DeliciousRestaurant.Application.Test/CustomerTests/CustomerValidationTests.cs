using DeliciousRestaurant.Application.Customers.Commands;
using DeliciousRestaurant.Application.Customers.Data;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;

namespace DeliciousRestaurant.Application.Test.CustomerTests
{
    [TestFixture]
    public class CustomerValidationTests : TestBase
    {
        CustomerValidation<ICustomerCommand> _customerValidation;
        Mock<ICustomerCommand> _customerComandMock;
        CustomerDTO _customerDTO;
        [SetUp]
        public void SetUp()
        {
            _customerValidation = new Mock<CustomerValidation<ICustomerCommand>>() { CallBase = true }.Object;
            _customerComandMock = new Mock<ICustomerCommand>();
            _customerDTO = new CustomerDTO { };
        }

        [Test]
        public void ValidateFirstName_Null_ShouldHaveValidationError_Test()
        {
            _customerValidation.ValidateFirstName();
            _customerDTO.FirstName = null;
            _customerComandMock.Setup(c => c.CustomerDTO).Returns(_customerDTO);
            var customerCommand = _customerComandMock.Object;
            _customerValidation.ShouldHaveValidationErrorFor(c => c.CustomerDTO.FirstName, customerCommand);
        }

        [Test]
        public void ValidateFirstName_Empty_ShouldHaveValidationError_Test()
        {
            _customerValidation.ValidateFirstName();
            _customerDTO.FirstName = string.Empty;
            _customerComandMock.Setup(c => c.CustomerDTO).Returns(_customerDTO);
            var customerCommand = _customerComandMock.Object;
            _customerValidation.ShouldHaveValidationErrorFor(c => c.CustomerDTO.FirstName, customerCommand);
        }

        [Test]
        public void ValidateLastName_Null_ShouldHaveValidationError_Test()
        {
            _customerValidation.ValidateLastName();
            _customerDTO.LastName = null;
            _customerComandMock.Setup(c => c.CustomerDTO).Returns(_customerDTO);
            var customerCommand = _customerComandMock.Object;
            _customerValidation.ShouldHaveValidationErrorFor(c => c.CustomerDTO.LastName, customerCommand);
        }

        [Test]
        public void ValidateLastName_Empty_ShouldHaveValidationError_Test()
        {
            _customerValidation.ValidateLastName();
            _customerDTO.LastName = string.Empty;
            _customerComandMock.Setup(c => c.CustomerDTO).Returns(_customerDTO);
            var customerCommand = _customerComandMock.Object;
            _customerValidation.ShouldHaveValidationErrorFor(c => c.CustomerDTO.LastName, customerCommand);
        }
    }
}