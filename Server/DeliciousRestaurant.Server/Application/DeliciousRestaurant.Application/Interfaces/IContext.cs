using DeliciousRestaurant.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Interfaces
{
    public interface IContext
    {
        int? CommandTimeout { get; set; }
        IQueryable<T> Set<T>() where T : class, IEntity;
        void Update<T>(Guid id, T entity) where T : class, IEntity;
        void Delete<T>(T entity) where T : class, IEntity;
        T Get<T>(Guid guid) where T : class, IEntity;
        bool HasChange();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        void UndoChanges();
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
