using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Transitaire
    {
        [Key]
        public int TransitaireId { get; set; }

        public required string Nom { get; set; }
        public required string Licences { get; set; }
        public required string ZonesOperation { get; set; }
    }
}
