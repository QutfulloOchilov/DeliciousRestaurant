using AutoMapper;
using DeliciousRestaurant.Application.Customers.Data;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Application.Queries;
using DeliciousRestaurant.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : BaseQueryHandler<IGetCustomerByIdQuery, CustomerDTO>
    {
        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public override Task<CustomerDTO> Handle(IGetCustomerByIdQuery request, CancellationToken cancellationToken = default)
        {
            var customer = UnitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            return MapAsync<Customer, CustomerDTO>(Mapper, customer);
        }
    }

}