using FrontEnd.WebPage.Models;

namespace FrontEnd.WebPage.Service.IService
{

    // This interface defines a contract for a base service that can send HTTP requests and receive responses.
    /// <summary>
    /// This Was the Common Interface for all the Services to implement the SendAsync method which will be used to send HTTP requests and receive responses.
    /// </summary>
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
