using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Tracking
    {
        [Key]
        public int TrackingId { get; set; }

        public required string ConteneurId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateHeure { get; set; } = DateTime.UtcNow;
        public required string Statut { get; set; }
    }
}
