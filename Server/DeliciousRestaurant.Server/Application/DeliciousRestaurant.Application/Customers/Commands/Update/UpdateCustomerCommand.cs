namespace DeliciousRestaurant.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommand : CustomerCommand<IUpdateCustomerCommand>, IUpdateCustomerCommand
    {
        public UpdateCustomerCommand(IUpdateCustomerValidation updateCustomerValidation) : base(updateCustomerValidation)
        {

        }
    }
}