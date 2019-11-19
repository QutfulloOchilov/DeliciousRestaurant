using DeliciousRestaurant.Application.Customers.Data;
using DeliciousRestaurant.Application.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : BaseQueryHandler<IGetCustomerByIdQuery, CustomerDTO>
    {
        public override Task<CustomerDTO> Handle(IGetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
