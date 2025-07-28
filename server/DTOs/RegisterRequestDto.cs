using System.ComponentModel.DataAnnotations;
using server.Models;

namespace server.DTOs
{
    public class RegisterRequest
    {
        [Required]
        public string Nom { get; set; } = string.Empty;

        [Required]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        public UserGender Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string MotDePasse { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; } = UserRole.Client; // Default to Client
    }
}
