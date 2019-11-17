using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;

        public UnitOfWork(IContext context,
            ICustomerRepository customerRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
        }

        public ICustomerRepository CustomerRepository { get; }

        public int? CommandTimeout
        {
            get => _context.CommandTimeout;
            set => _context.CommandTimeout = value;
        }

        public virtual int SaveChanges() => _context.SaveChanges();

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        [Obsolete]
        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _context.ExecuteSqlCommand(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _context.ExecuteSqlCommandAsync(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return await _context.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public virtual void Rollback()
        {
            _context.UndoChanges();
        }
    }
}