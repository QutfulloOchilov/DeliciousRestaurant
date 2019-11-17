using DeliciousRestaurant.Application.Customers.Interfaces;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Domain.Entities;

namespace DeliciousRestaurant.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }
    }
}
