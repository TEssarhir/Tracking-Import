using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs;
using server.Helpers;

namespace server.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var user = _context.Utilisateurs
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null || user.MotDePasseHash == null || !PasswordHelper.VerifyPassword(user.MotDePasseHash, request.MotDePasse))
                throw new UnauthorizedAccessException("Identifiants invalides");

            var token = JwtHelper.GenerateJwtToken(user, _config["Jwt:Key"] ?? string.Empty);

            return new LoginResponse
            {
                Token = token,
                Nom = user.Nom ?? string.Empty,
                Role = user.Role?.Nom ?? string.Empty,
            };
        }
    }
}
