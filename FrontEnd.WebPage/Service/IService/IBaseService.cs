using FrontEnd.WebPage.Models;

namespace FrontEnd.WebPage.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
