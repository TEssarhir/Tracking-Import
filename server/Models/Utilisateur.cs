using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Utilisateur
    {
        [Key]
        public int UtilisateurId { get; set; }

        public required string Nom { get; set; }

        public required string Email { get; set; }

        public required string MotDePasseHash { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int RoleId { get; set; }
        public required Role Role { get; set; }
    }
}
