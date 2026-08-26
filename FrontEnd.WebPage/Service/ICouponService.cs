using FrontEnd.WebPage.Models;

namespace FrontEnd.WebPage.Service
{
    public interface ICouponService
    {
        Task<ResponseDto> GetAllCouponsAsync();
        Task<ResponseDto> GetCouponsAsync(string couponId);

        Task<ResponseDto> GetCouponsByIdAsync(int couponId);

        Task<ResponseDto> CreateCouponAsync(CouponDto couponDto);

        Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto);\

        Task<ResponseDto> DeleteCouponAsync(int couponId);

    }
}
