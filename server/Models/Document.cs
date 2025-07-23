using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        public required string Type { get; set; }

        public required string NomFichier { get; set; }
        public required string UrlFichier { get; set; }

        public DateTime DateAjout { get; set; } = DateTime.UtcNow;

        public required int UtilisateurId { get; set; }
        public required Utilisateur Utilisateur { get; set; }
    }
}
