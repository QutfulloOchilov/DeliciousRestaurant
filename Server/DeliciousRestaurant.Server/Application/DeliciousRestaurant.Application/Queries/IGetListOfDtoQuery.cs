using DeliciousRestaurant.Application.Data;
using System.Collections.Generic;

namespace DeliciousRestaurant.Application.Queries
{
    public interface IGetListOfDtoQuery<T> : IBaseQueryHandler<IEnumerable<T>> where T : BaseDTO
    {

    }
}
