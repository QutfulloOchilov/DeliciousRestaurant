using AutoMapper;

namespace DeliciousRestaurant.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                
            });
            return mappingConfig.CreateMapper();
        }
    }
}
