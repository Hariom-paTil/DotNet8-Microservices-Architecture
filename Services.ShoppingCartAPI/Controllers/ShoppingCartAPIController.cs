using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ShoppingCartAPI.Data;
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

        }
     
    }
}
