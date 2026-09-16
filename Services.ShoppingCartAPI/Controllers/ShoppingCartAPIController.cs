using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ShoppingCartAPI.Data;
using Services.ShoppingCartAPI.Models;
using Services.ShoppingCartAPI.Models.Dto;
using Services.ShoppingCartAPI.Models.DTO;

namespace Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartAPIController : ControllerBase
    {

        private readonly ResponceDto _responceDto;

        private readonly IMapper _mapper;

        private readonly AppDbContext _appDbContext;

        public ShoppingCartAPIController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _responceDto = new ResponceDto();
        }

        [HttpPost("cartUpsert")]
        public async Task<ResponceDto> Upsert(CartDto cartDto)
        {

            try
            {
                var cartHeaderFromDb = _appDbContext.CartHeaders.FirstOrDefault(u => u.UserId == cartDto.CartHeader.UserId);
                if(cartHeaderFromDb == null)
                {
                    // Create new cart
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                    _appDbContext.CartHeaders.Add(cartHeader);
                    await _appDbContext.SaveChangesAsync();
                    cartDto.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.CartHeaderId;
                    _appDbContext.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.FirstOrDefault()));
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    var cartDetailsFromDb = _appDbContext.CartDetails.FirstOrDefault(u => u.ProductId == cartDto.CartDetails.FirstOrDefault().ProductId && u.CartHeaderId == cartHeaderFromDb.CartHeaderId);
                    if(cartDetailsFromDb == null)
                    {
                        // Create new cart details
                    }
                    else
                    {
                        // Update the count of existing cart details
                    }

                }
            }
            catch (Exception ex)
            {
                _responceDto.IsSuccess = false;
                _responceDto.Message = ex.Message;
            }
        }
     
    }
}
