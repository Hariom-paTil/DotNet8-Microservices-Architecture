namespace Services.AuthAPI.Model.DTO
{
    public class LoginResponceDto
    {
        public UserDTO? User { get; set; }

        public string? Token { get; set; }
    }
}
