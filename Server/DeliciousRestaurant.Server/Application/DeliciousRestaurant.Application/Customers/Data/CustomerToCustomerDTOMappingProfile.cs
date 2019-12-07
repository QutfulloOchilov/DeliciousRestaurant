using AutoMapper;
using DeliciousRestaurant.Domain.Entities;

namespace DeliciousRestaurant.Application.Customers.Data
{
    public class CustomerToCustomerDTOMappingProfile : Profile
    {
        public CustomerToCustomerDTOMappingProfile()
        {
            var mapping = CreateMap<Customer, CustomerDTO>();
            mapping.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName));
            mapping.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
            mapping.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
            mapping.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            mapping.ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
        }
    }
}