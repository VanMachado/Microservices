using AutoMapper;
using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;
using GeekShopping.CartAPI.Model.Base;

namespace GeekShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>()
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)).ReverseMap();                
                config.CreateMap<CategoryDto, Category>().ReverseMap();                
            });

            return mappingConfig;
        }
    }
}
