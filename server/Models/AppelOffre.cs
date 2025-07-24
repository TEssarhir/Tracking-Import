using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class AppelOffre
    {
        [Key]
        public int AppelId { get; set; }

        public string? Titre { get; set; }
        public string? Description { get; set; }
        public string? Criteres { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public string? Statut { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
