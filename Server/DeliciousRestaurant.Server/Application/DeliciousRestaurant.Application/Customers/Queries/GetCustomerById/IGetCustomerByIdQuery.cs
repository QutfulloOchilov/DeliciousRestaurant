using DeliciousRestaurant.Application.Customers.Data;
using DeliciousRestaurant.Application.Queries;
using System;

namespace DeliciousRestaurant.Application.Customers.Queries.GetCustomerById
{
    public interface IGetCustomerByIdQuery : IGetDtoByIdQuery<CustomerDTO>
    {
        Guid Id { get; }
    }
}
