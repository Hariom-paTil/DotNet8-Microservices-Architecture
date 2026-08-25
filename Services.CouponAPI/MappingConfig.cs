using AutoMapper;
using Services.CouponAPI.Models;
using Services.CouponAPI.Models.DTO;   

namespace Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
           var mappingconfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
                
            });
            return mappingconfiguration;
        }
    }
}
