using AutoMapper;
using GeekShopping.CartAPI.DataTransfer.DataTransferObjects;
using GeekShopping.CartAPI.Model;

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
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailDto, CartDetail>()
                    .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product)).ReverseMap() 
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)).ReverseMap();                    
                config.CreateMap<CartDto, Cart>().ReverseMap();
                config.CreateMap<CategoryDto, Category>().ReverseMap();                
            });

            return mappingConfig;
        }
    }
}
