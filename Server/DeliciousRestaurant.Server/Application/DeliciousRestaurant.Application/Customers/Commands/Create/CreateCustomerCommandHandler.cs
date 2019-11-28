using AutoMapper;
using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : BaseCommandHandler<ICreateCustomerCommand>
    {
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async override Task<bool> Handle(ICreateCustomerCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!request.IsValid())
                this.NotifyValidationErrors(request);

            var customer = Mapper.Map<Customer>(request);
            UnitOfWork.CustomerRepository.Add(customer);
            return await UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}