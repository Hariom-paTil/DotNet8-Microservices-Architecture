using FrontEnd.WebPage.Models;
using FrontEnd.WebPage.Service.IService;
using static FrontEnd.WebPage.Utility.SD;

namespace FrontEnd.WebPage.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = CouponAPIBase + "/api/coupon",
                Data = couponDto
            });
        }

        public async Task<ResponseDto> DeleteCouponAsync(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = CouponAPIBase + "/api/coupon/" + couponId
            });
        }

        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/coupon",
            });

        }

        public async Task<ResponseDto> GetCouponsAsync(string couponId)
        {
           
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/coupon/GetByCode/" + couponId
            });
        }

        public async Task<ResponseDto> GetCouponsByIdAsync(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = CouponAPIBase + "/api/coupon/" + couponId
            });

        }

        public Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto)
        {
           return _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Url = CouponAPIBase + "/api/coupon",
                Data = couponDto
            });
        }
    }
}
