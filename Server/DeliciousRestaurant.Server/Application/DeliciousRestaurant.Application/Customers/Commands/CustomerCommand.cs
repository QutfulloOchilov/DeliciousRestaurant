using DeliciousRestaurant.Application.Commands;
using DeliciousRestaurant.Application.Customers.Data;
using System.Runtime.Serialization;

namespace DeliciousRestaurant.Application.Customers.Commands
{
    [DataContract]
    public abstract class CustomerCommand : Command, ICustomerCommand
    {
        [DataMember]
        public CustomerDTO CustomerDTO { get; protected set; }
    }
}
