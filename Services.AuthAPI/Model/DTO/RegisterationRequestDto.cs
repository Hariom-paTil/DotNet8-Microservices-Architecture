namespace Services.AuthAPI.Model.DTO
{
    public class RegisterationRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string? Role { get; set; }
}
}
