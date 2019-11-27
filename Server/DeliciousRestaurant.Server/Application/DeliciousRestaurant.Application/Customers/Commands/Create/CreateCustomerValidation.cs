using FluentValidation;

namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public class CreateCustomerValidation : CustomerValidation<ICreateCustomerCommand>, ICreateCustomerValidation
    {
        public void ValidateIdentityUserId()
        {
            this.RuleFor(p => p.IdentityUserId).NotNull().NotEmpty();
        }
    }
}