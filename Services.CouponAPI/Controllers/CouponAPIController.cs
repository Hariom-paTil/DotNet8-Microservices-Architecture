using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CouponAPI.Data;
using Services.CouponAPI.Models;

namespace Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CouponAPIController(AppDbContext db)
        {
            _dbContext = db;
        }

        [HttpGet]

        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objCoupon = _dbContext.Coupons.ToList();
                return Ok(objCoupon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Invalid Request");
        }


        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon objCoupon = _dbContext.Coupons.FirstOrDefault(c => c.CouponId == id);
                if (objCoupon != null)
                {
                    return Ok(objCoupon);
                }
                else
                {
                    return NotFound($"Coupon with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
