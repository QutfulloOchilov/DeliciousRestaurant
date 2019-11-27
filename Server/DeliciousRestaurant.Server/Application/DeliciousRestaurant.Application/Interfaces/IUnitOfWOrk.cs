using DeliciousRestaurant.Application.Customers.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        int? CommandTimeout { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int ExecuteSqlCommand(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters);
        void Rollback();
    }
}