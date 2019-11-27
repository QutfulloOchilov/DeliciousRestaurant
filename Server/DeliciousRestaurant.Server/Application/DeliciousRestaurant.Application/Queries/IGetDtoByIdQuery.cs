using DeliciousRestaurant.Application.Data;

namespace DeliciousRestaurant.Application.Queries
{
    public interface IGetDtoByIdQuery<T> : IBaseQueryHandler<T> where T : BaseDTO
    {

    }
}
