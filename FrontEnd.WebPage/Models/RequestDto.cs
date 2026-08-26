using static FrontEnd.WebPage.Utility.SD;

namespace FrontEnd.WebPage.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; } = string.Empty;

        public object? Data { get; set; } = null;

        public string? AccessToken { get; set; } = string.Empty;
    }
}
