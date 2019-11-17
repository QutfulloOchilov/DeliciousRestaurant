using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Customers.Data;

namespace DeliciousRestaurant.Application.Customers.Commands
{
    public interface ICustomerCommand : ICommand
    {
        CustomerDTO CustomerDTO { get; }
    }
}
