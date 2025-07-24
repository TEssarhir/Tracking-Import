using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Utilisateur
    {
        [Key]
        public int UtilisateurId { get; set; }

        public string? Nom { get; set; }

        public string? Email { get; set; }

        public string? MotDePasseHash { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
