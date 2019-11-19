using DeliciousRestaurant.Domain.Interfaces;
using System.Collections.Generic;

namespace DeliciousRestaurant.Application.Interfaces
{
    public interface IPagedList<T> where T : IEntity
    {
        int IndexFrom { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        IList<T> Items { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}