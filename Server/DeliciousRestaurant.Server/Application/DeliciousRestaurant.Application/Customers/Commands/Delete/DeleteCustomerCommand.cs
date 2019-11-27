namespace DeliciousRestaurant.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : CustomerCommand<IDeleteCustomerCommand>, IDeleteCustomerCommand
    {
        public DeleteCustomerCommand(IDeleteCustomerValidation deleteCustomerValidation) : base(deleteCustomerValidation)
        {
        }
    }
}