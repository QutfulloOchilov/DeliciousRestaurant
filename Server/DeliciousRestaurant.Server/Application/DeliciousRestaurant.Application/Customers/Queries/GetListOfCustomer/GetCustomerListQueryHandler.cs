using DeliciousRestaurant.Application.Customers.Data;
using DeliciousRestaurant.Application.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Queries.GetListOfCustomer
{
    public class GetCustomerListQueryHandler : BaseQueryHandler<IGetCustomerListQuery, IEnumerable<CustomerDTO>>
    {
        public override Task<IEnumerable<CustomerDTO>> Handle(IGetCustomerListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
