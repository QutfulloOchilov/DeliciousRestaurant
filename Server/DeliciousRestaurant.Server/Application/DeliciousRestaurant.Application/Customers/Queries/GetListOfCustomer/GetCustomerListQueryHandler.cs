using AutoMapper;
using DeliciousRestaurant.Application.Customers.Data;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Application.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Queries.GetListOfCustomer
{
    public class GetCustomerListQueryHandler : BaseQueryHandler<IGetCustomerListQuery, IEnumerable<CustomerDTO>>
    {
        public GetCustomerListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public override Task<IEnumerable<CustomerDTO>> Handle(IGetCustomerListQuery request, CancellationToken cancellationToken = default)
        {
            var customer = UnitOfWork.CustomerRepository.GetByIdAsync(;
            return MapAsync<Customer, CustomerDTO>(Mapper, customer);
        }
    }
}
