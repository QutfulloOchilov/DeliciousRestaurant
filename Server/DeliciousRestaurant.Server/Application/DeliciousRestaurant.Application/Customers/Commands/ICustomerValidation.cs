using DeliciousRestaurant.Application.Commands;

namespace DeliciousRestaurant.Application.Customers.Commands
{
    public interface ICustomerValidation<TCommand> : IBaseCommandValidation<TCommand> where TCommand : ICustomerCommand
    {
    }
}
