namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public interface ICreateCustomerValidation : ICustomerValidation<ICreateCustomerCommand>
    {
        void ValidateIdentityUserId();
    }
}
