using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs;
using server.Helpers;
using server.Models;

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
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null || user.MotDePasseHash == null || !PasswordHelper.VerifyPassword(user.MotDePasseHash, request.MotDePasse))
                throw new UnauthorizedAccessException("Identifiants invalides");

            var token = JwtHelper.GenerateJwtToken(user, _config["Jwt:Key"] ?? string.Empty);

            return new LoginResponse
            {
                Token = token,
                Nom = user.Nom ?? string.Empty,
                Prenom = user.Prenom ?? string.Empty,
                Gender = user.Gender,
                Role = user.Role,
            };
        }

        public void Register(RegisterRequest request)
        {
            // Check if email already exists
            if (_context.Utilisateurs.Any(u => u.Email == request.Email))
                throw new InvalidOperationException("Un utilisateur avec cet email existe déjà");

            // Validate role exists
            if (!Enum.IsDefined(typeof(UserRole), request.Role))
                throw new InvalidOperationException("Le rôle spécifié n'existe pas");

            // Create new user
            var user = new Utilisateur
            {
                Nom = request.Nom,
                Prenom = request.Prenom,
                Gender = request.Gender,
                Email = request.Email,
                MotDePasseHash = PasswordHelper.HashPassword(request.MotDePasse),
                Role = request.Role, // Use enum directly
                TwoFactorEnabled = false
            };

            _context.Utilisateurs.Add(user);
            _context.SaveChanges();
        }
    }
}
