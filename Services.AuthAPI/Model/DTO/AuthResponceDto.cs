namespace Services.AuthAPI.Model.DTO
{
    public class AuthResponceDto
    {
        public object? Result { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string? Message { get; set; } = string.Empty;


    }
}
