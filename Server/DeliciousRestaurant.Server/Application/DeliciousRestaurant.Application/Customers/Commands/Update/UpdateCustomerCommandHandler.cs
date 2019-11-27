using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : BaseCommandHandler<IUpdateCustomerCommand>
    {
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async override Task<bool> Handle(IUpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
