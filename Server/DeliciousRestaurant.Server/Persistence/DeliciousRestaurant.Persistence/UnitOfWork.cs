using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IContext Context { get; }

        public UnitOfWork(IContext context,
            ICustomerRepository customerRepository)
        {
            Context = context;
            CustomerRepository = customerRepository;
        }

        public ICustomerRepository CustomerRepository { get; }

        public int? CommandTimeout
        {
            get => Context.CommandTimeout;
            set => Context.CommandTimeout = value;
        }

        public virtual int SaveChanges() => Context.SaveChanges();

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        [Obsolete]
        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Context.ExecuteSqlCommand(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await Context.ExecuteSqlCommandAsync(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return await Context.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public virtual void Rollback()
        {
            Context.UndoChanges();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}