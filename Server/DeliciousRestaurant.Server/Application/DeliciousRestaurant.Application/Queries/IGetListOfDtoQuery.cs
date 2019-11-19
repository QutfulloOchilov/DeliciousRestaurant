using DeliciousRestaurant.Application.Data;
using MediatR;
using System.Collections.Generic;

namespace DeliciousRestaurant.Application.Queries
{
    public interface IGetListOfDtoQuery<T> : IBaseQueryHandler<IEnumerable<T>> where T : BaseDTO
    {

    }
}
