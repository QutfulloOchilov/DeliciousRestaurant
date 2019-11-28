using DeliciousRestaurant.Application.Customers.Data;

namespace DeliciousRestaurant.Application.Customers.Commands.Create
{
    public class CustomerToCreateCustomerCommandMappingProfile : CustomerToCustomerCommandMappingProfile<ICreateCustomerCommand>
    {
        public CustomerToCreateCustomerCommandMappingProfile() : base()
        {
            Mapping.ForMember(dest => dest.IdentityUserId, opt => opt.MapFrom(src => src.IdentityUserId));
        }
    }
}