using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Customers.Data;
using System.Runtime.Serialization;

namespace DeliciousRestaurant.Application.Customers.Commands
{
    [DataContract]
    public abstract class CustomerCommand<TCommand> : BaseCommand, ICustomerCommand where TCommand : ICustomerCommand
    {
        public CustomerCommand(ICustomerValidation<TCommand> validation) : base(validation) { }

        [DataMember]
        public CustomerDTO CustomerDTO { get; protected set; }
    }
}