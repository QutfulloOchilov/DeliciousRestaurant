using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Queries
{
    public abstract class BaseQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IBaseQueryHandler<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
