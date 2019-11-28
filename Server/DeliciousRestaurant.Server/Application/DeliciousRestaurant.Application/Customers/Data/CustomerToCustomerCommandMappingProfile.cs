using AutoMapper;
using DeliciousRestaurant.Application.Customers.Commands;
using DeliciousRestaurant.Domain.Entities;

namespace DeliciousRestaurant.Application.Customers.Data
{
    public abstract class CustomerToCustomerCommandMappingProfile<TCommand> : Profile where TCommand : ICustomerCommand
    {
        protected IMappingExpression<TCommand, Customer> Mapping;
        public CustomerToCustomerCommandMappingProfile()
        {
            Mapping = CreateMap<TCommand, Customer>();
            Mapping.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.CustomerDTO.FirstName));
            Mapping.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.CustomerDTO.LastName));
            Mapping.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.CustomerDTO.Gender));
            Mapping.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerDTO.Id));
            Mapping.ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.CustomerDTO.Image));
        }
    }
}
