namespace FrontEnd.WebPage.Service.TokenProviderService
{
    public interface ITokenProvider
    {
        void SetToken(string token);
        string? GetToken();

        void ClearToken();
    }
}
