using FrontEnd.WebPage.Models;

namespace FrontEnd.WebPage.Service.Product_Services
{
    public interface IProductService
    {

        Task<ResponseDto> GetAllProductAsync();
        Task<ResponseDto> GetProductAsync(string productId);

        Task<ResponseDto> GetProductByIdAsync(int productId);

        Task<ResponseDto> CreateProductAsync(ProductDto productDto);
        Task<ResponseDto> UpdateProductAsync(ProductDto productDto);

        Task<ResponseDto> DeleteProductAsync(int productId);
    }
}
