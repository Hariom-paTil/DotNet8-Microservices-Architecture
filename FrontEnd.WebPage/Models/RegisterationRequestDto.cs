using System.ComponentModel.DataAnnotations;

namespace FrontEnd.WebPage.Models
{
    public class RegisterationRequestDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        
        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string? Role { get; set; }
}
}
