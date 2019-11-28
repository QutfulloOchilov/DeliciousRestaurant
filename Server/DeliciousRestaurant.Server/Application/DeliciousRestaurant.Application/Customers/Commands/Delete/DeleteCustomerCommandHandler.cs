using AutoMapper;
using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : BaseCommandHandler<IDeleteCustomerCommand>
    {
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public override async Task<bool> Handle(IDeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                this.NotifyValidationErrors(request);
            }

            UnitOfWork.CustomerRepository.Delete(request.CustomerDTO.Id);

            return await UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
