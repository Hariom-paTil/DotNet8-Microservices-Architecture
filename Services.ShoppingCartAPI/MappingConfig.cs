using AutoMapper;
using Services.ShoppingCartAPI.Models;
using Services.ShoppingCartAPI.Models.Dto;



namespace Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
           var mappingconfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();

            });
            return mappingconfiguration;
        }
    }
}
