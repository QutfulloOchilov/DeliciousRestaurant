using DeliciousRestaurant.Application.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : BaseCommandHandler<IUpdateCustomerCommand>
    {
        public override Task<bool> Handle(IUpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
