namespace server.DTOs
{
    public class LoginResponse
    {
        public required string Token { get; set; }
        public required string Nom { get; set; }
        public required string Role { get; set; }
    }
}
