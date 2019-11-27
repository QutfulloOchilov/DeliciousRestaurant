namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public interface ICreateCustomerCommand : ICustomerCommand
    {
        string IdentityUserId { get; set; }
    }
}
