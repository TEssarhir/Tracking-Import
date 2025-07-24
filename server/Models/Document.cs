using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        public string? Type { get; set; }

        public string? NomFichier { get; set; }
        public string? UrlFichier { get; set; }

        public DateTime DateAjout { get; set; } = DateTime.UtcNow;

        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }
    }
}
