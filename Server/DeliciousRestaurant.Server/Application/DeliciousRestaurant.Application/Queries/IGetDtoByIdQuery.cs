using DeliciousRestaurant.Application.Data;
using MediatR;

namespace DeliciousRestaurant.Application.Queries
{
    public interface IGetDtoByIdQuery<T> : IBaseQueryHandler<T> where T : BaseDTO
    {

    }
}
