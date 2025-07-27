using System.ComponentModel.DataAnnotations;

namespace server.DTOs
{
    public class RegisterRequest
    {
        [Required]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string MotDePasse { get; set; } = string.Empty;

        [Required]
        public int RoleId { get; set; }
    }
}
