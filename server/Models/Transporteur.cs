using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Transporteur
    {
        [Key]
        public int TransporteurId { get; set; }

        public string? Nom { get; set; }

        public string? Coordonees { get; set; }

        public string? Capacites { get; set; }

        public string? Certifications { get; set; }
    }
}
