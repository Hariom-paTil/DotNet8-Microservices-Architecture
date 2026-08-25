using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CouponAPI.Data;
using Services.CouponAPI.Models;
using Services.CouponAPI.Models.DTO;

namespace Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _dbContext;







        // This ResponseDto class is used to return a response from the API.
        // It contains three properties: Result, IsSuccess, and Message.\
        // The Result property is used to return the result of the API call,
        // the IsSuccess property is used to indicate whether the API call was successful or not,
        // and the Message property is used to return any error messages that may have occurred during the API call.


        //SimplyMeans :: Every Http request will return 
        // CouponResponceDto object which will contain Result, IsSuccess and Message properties.
        // Frontend will check IsSuccess property to know whether the request is successful or not.

        private readonly CouponResponceDto _response;
        public CouponAPIController(AppDbContext db)
        {
            _dbContext = db;
            _response = new CouponResponceDto();

        }

        [HttpGet]

        public CouponResponceDto Get()
        {
            try
            {
                IEnumerable<Coupon> objCoupon = _dbContext.Coupons.ToList();
                _response.Result= objCoupon;
               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
       }


        [HttpGet]
        [Route("{id:int}")]
        public CouponResponceDto Get(int id)
        {
            try
            {
                Coupon objCoupon = _dbContext.Coupons.First(c => c.CouponId == id);
               _response.Result = objCoupon;
            }
            catch (Exception ex)
            {
               _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
