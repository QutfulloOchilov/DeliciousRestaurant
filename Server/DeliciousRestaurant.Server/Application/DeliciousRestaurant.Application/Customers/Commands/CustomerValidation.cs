using DeliciousRestaurant.Application.Commands;
using FluentValidation;

namespace DeliciousRestaurant.Application.Customers.Commands
{
    public abstract class CustomerValidation : BaseCommandValidation<ICustomerCommand>, ICustomerValidation
    {
        protected void ValidateName()
        {
            this.RuleFor(p => p.CustomerDTO.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("First name can not be empty. Please set first name.");
        }

        protected void ValidateLastName()
        {
            this.RuleFor(p => p.CustomerDTO.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Last name can not be empty. Please set first name.");
        }
    }

}
