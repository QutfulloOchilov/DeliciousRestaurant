using DeliciousRestaurant.Application.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : BaseCommandHandler<ICustomerCommand>
    {
        public override Task<bool> Handle(ICustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
