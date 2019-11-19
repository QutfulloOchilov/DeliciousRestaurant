using MediatR;

namespace DeliciousRestaurant.Application.Queries
{
    public interface IBaseQueryHandler<TResponse> : IRequest<TResponse>
    {

    }
}
