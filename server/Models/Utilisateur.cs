using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public enum UserRole
    {
        Admin,
        Fournisseur,
        Transitaire,
        Transporteur,
        Client
    }

    public enum UserGender
    {
        M,
        F,
    }

    public class Utilisateur
    {
        [Key]
        public int UtilisateurId { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public UserGender Gender { get; set; }

        public string? Email { get; set; }

        public string? MotDePasseHash { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public UserRole Role { get; set; }
    }
}
