using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : BaseCommandHandler<ICreateCustomerCommand>
    {
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async override Task<bool> Handle(ICreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                this.NotifyValidationErrors(request);
            }

            var customer = new Customer
            {
                FirstName = request.CustomerDTO.FirstName,
                LastName = request.CustomerDTO.LastName,
                Gender = request.CustomerDTO.Gender,
                Image = request.CustomerDTO.Image,
                IdentityUserId = request.IdentityUserId
            };

            UnitOfWork.CustomerRepository.Add(customer);
            return await UnitOfWork.SaveEntitiesAsync();
        }
    }
}