using System.ComponentModel.DataAnnotations;

namespace WebApplication1.api.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]  //annotation that checks validation for email address
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
