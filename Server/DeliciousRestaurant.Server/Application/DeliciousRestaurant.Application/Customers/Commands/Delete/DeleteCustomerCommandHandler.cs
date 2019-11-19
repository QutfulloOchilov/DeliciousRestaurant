using DeliciousRestaurant.Application.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : BaseCommandHandler<IDeleteCustomerCommand>
    {
        public override Task<bool> Handle(IDeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
