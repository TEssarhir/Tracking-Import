using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Client
    {
        [Key]
        public int TrackingId { get; set; }

        public int ConteneurId { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public required string Status { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
