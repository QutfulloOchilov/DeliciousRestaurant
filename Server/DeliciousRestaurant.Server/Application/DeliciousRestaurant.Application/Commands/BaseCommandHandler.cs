using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Commands
{
    public abstract class BaseCommandHandler<TCommand> : IRequestHandler<TCommand, bool> where TCommand : IBaseCommand
    {
        public abstract Task<bool> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
