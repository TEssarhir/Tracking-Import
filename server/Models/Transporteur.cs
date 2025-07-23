using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Transporteur
    {
        [Key]
        public int TransporteurId { get; set; }

        public required string Nom { get; set; }

        public required string Coordonees { get; set; }

        public required string Capacites { get; set; }

        public required string Certifications { get; set; }
    }
}
