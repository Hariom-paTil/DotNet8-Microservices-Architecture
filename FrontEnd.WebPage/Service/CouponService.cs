using FrontEnd.WebPage.Models;
using FrontEnd.WebPage.Service.IService;

namespace FrontEnd.WebPage.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto> CreateCouponAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeleteCouponAsync(int couponId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetAllCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetCouponsAsync(string couponId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetCouponsByIdAsync(int couponId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
