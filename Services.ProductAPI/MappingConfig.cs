using AutoMapper;
using Services.ProductAPI.Model;
using Services.ProductAPI.Model.DTO;


namespace Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
           var mappingconfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();
                
            });
            return mappingconfiguration;
        }
    }
}
