using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Fournisseur
    {
        [Key]
        public int FournisseurId { get; set; }

        public string? Nom { get; set; }

        public string? Catalogues { get; set; }

        public string? Accreditations { get; set; }
    }
}
