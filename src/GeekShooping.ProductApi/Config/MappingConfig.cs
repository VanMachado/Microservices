using AutoMapper;
using GeekShooping.ProductApi.DataTransfer.DataTransferObjects;
using GeekShooping.ProductApi.Model.Base;

namespace GeekShooping.ProductApi.Config
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
