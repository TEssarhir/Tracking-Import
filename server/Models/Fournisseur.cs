using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Fournisseur
    {
        [Key]
        public int FournisseurId { get; set; }

        public required string Nom { get; set; }

        public required string Catalogues { get; set; }

        public required string Accreditations { get; set; }
    }
}
