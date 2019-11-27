using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Customers.Data;
using System.Runtime.Serialization;

namespace DeliciousRestaurant.Application.Customers.Commands
{
    [DataContract]
    public abstract class CustomerCommand : BaseCommand, ICustomerCommand
    {
        public CustomerCommand(ICustomerValidation validator) : base(validator)
        {
        }

        [DataMember]
        public CustomerDTO CustomerDTO { get; protected set; }
    }
}
