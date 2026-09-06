using FrontEnd.WebPage.Models;
using FrontEnd.WebPage.Service.IService;
using System.Text;
using Newtonsoft.Json;
using static FrontEnd.WebPage.Utility.SD;
using System.Net;
using FrontEnd.WebPage.Service.TokenProviderService;

namespace FrontEnd.WebPage.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClient, ITokenProvider tokenProvider)
        {
            _httpClient = httpClient;
            _tokenProvider = tokenProvider;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearerToken)
        {
            HttpClient client = _httpClient.CreateClient("HttpAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            if (withBearerToken)
            {
                var token =  _tokenProvider.GetToken();
                message.Headers.Add("Authorization", $"Bearer {token}");

            }


            
            message.RequestUri = new Uri(requestDto.Url);
            if(requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? httpResponse = null;

            switch(requestDto.ApiType)
            {
                case ApiType.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    break;
            }

            httpResponse = await client.SendAsync(message);

            switch(httpResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        Message = "Resource not found."
                    };
                    case HttpStatusCode.InternalServerError:
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        Message = "Internal server error."
                    };
                    case HttpStatusCode.BadRequest:
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        Message = "Bad request."
                    };

                    default:
                    var apiContent = await httpResponse.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponse;
            }

        }
    }
}
