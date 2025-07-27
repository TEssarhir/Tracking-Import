using System.ComponentModel.DataAnnotations;

namespace server.DTOs
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string MotDePasse { get; set; } = string.Empty;
    }
}
