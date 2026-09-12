using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProductAPI.Data;
using Services.ProductAPI.Model;
using Services.ProductAPI.Model.DTO;

namespace Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]

    //[Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        private readonly IMapper _mapper;


        private readonly ResponceDto _response;
        public ProductAPIController(AppDbContext db, IMapper mapper)
        {
            _dbContext = db;
            _mapper = mapper;
            _response = new ResponceDto();

        }

        [HttpGet]

        public ResponceDto Get()
        {
            try
            {
                IEnumerable<Product> objProduct = _dbContext.Products.ToList();
                _response.Result= _mapper.Map<IEnumerable<ProductDto>>(objProduct);

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
        public ResponceDto Get(int id)
        {
            try
            {
                Product objProduct = _dbContext.Products.First(c => c.ProductId == id);
               _response.Result = _mapper.Map<ProductDto>(objProduct);    
            }
            catch (Exception ex)
            {
               _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
        

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResponceDto Post([FromBody] ProductDto productdto)
        {
            try
            {
                var objProduct = _mapper.Map<Product>(productdto);
                _dbContext.Add(objProduct);
                _dbContext.SaveChanges();
                _response.Result = objProduct;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ResponceDto Update([FromBody] ProductDto productdto)
        {
            try
            {
                var objProduct = _mapper.Map<Product>(productdto);
                _dbContext.Update(objProduct);
                _dbContext.SaveChanges();
                _response.Result = objProduct;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")] 
        public ResponceDto Delete(int id)
        {
            try
            {
                var objProduct = _dbContext.Products.First(u => u.ProductId == id);
                _dbContext.Remove(objProduct);
                _dbContext.SaveChanges();
                
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
