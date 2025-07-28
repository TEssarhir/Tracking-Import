using server.Models;

namespace server.DTOs
{
    public class LoginResponse
    {
        public required string Token { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public UserGender Gender { get; set; }
        public UserRole Role { get; set; }
    }
}
