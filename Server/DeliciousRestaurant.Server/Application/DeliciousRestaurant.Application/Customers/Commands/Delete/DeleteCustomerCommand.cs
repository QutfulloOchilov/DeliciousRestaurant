namespace DeliciousRestaurant.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : CustomerCommand, IDeleteCustomerCommand
    {
        public DeleteCustomerCommand(IDeleteCustomerValidation deleteCustomerValidation) : base(deleteCustomerValidation)
        {
        }
    }
}