using AutoMapper;
using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : BaseCommandHandler<IUpdateCustomerCommand>
    {
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async override Task<bool> Handle(IUpdateCustomerCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!request.IsValid())
                this.NotifyValidationErrors(request);

            Customer customer = Mapper.Map<Customer>(request);
            UnitOfWork.CustomerRepository.Update(customer);
            return await UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
