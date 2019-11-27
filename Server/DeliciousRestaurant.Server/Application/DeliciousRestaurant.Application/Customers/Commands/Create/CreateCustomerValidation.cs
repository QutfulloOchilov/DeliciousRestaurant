using FluentValidation;

namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public class CreateCustomerValidation : CustomerValidation, ICreateCustomerValidation
    {
        public void ValidateIdentityUserId()
        {
            this.RuleFor(p => ((ICreateCustomerCommand)p).IdentityUserId).NotNull().NotEmpty();
        }
    }
}