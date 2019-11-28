using AutoMapper;
using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : BaseCommandHandler<IUpdateCustomerCommand>
    {
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async override Task<bool> Handle(IUpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
