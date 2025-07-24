using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Transitaire
    {
        [Key]
        public int TransitaireId { get; set; }

        public string? Nom { get; set; }
        public string? Licences { get; set; }
        public string? ZonesOperation { get; set; }
    }
}
