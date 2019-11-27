namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public class CreateCustomerCommand : CustomerCommand, ICreateCustomerCommand
    {
        public CreateCustomerCommand(ICreateCustomerValidation validator) : base(validator) { }

        public string IdentityUserId { get; set; }
    }
}