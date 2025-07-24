namespace server.DTOs
{
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string MotDePasse { get; set; }
    }
}
