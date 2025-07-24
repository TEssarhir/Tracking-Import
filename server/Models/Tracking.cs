using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Tracking
    {
        [Key]
        public int TrackingId { get; set; }

        public string? ConteneurId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateHeure { get; set; } = DateTime.UtcNow;
        public string? Statut { get; set; }
    }
}
