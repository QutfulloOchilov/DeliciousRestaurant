using AutoMapper;
using DeliciousRestaurant.Application.Customers.Commands.Create;
using DeliciousRestaurant.Application.Customers.Commands.Delete;
using DeliciousRestaurant.Application.Customers.Commands.Update;
using DeliciousRestaurant.Application.Customers.Data;

namespace DeliciousRestaurant.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerToCreateCustomerCommandMappingProfile());
                cfg.AddProfile(new CustomerToDeleteCustomerCommandMappingProfile());
                cfg.AddProfile(new CustomerToUpdateCustomerCommandMappingProfile());
                cfg.AddProfile(new CustomerToCustomerDTOMappingProfile());
            });
            return mappingConfig.CreateMapper();
        }
    }
}