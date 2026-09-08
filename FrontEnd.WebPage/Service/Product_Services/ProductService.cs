using FrontEnd.WebPage.Models;
using FrontEnd.WebPage.Service.IService;
using static FrontEnd.WebPage.Utility.SD;

namespace FrontEnd.WebPage.Service.Product_Services
{ 
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Url = ProductAPIBase + "/api/product",
                Data = productDto
            });
        }

        public async Task<ResponseDto> DeleteProductAsync(int productId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = ProductAPIBase + "/api/product/" + productId
            });
        }

        public async Task<ResponseDto> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + "/api/product",
            });

        }

        public async Task<ResponseDto> GetProductAsync(string productId)
        {
           
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + "/api/product/GetByCode/" + productId
            });
        }

        public async Task<ResponseDto> GetProductByIdAsync(int productId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + "/api/product/" + productId
            });

        }

        public Task<ResponseDto> UpdateProductAsync(ProductDto productDto)
        {
           return _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Url = ProductAPIBase + "/api/product",
                Data = productDto
            });
        }
    }
}
