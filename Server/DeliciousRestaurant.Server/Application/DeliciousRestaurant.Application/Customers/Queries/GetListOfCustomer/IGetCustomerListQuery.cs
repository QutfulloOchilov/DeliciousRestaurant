using DeliciousRestaurant.Application.Customers.Data;
using DeliciousRestaurant.Application.Queries;

namespace DeliciousRestaurant.Application.Customers.Queries.GetListOfCustomer
{
    public interface IGetCustomerListQuery : IGetListOfDtoQuery<CustomerDTO>
    {
        bool OnlyActive { get; }
    }
}
