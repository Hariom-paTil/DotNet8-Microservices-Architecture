using Microsoft.Identity.Client;

namespace Services.AuthAPI.Model.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
