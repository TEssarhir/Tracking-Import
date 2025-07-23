using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Soumission
    {
        [Key]
        public int SoumissionId { get; set; }

        public int AppelId { get; set; }
        public required AppelOffre AppelOffre { get; set; }

        public int FournisseurId { get; set; }
        public required Fournisseur Fournisseur { get; set; }

        public decimal Prix { get; set; }
        public int DelaiLivraison { get; set; }
        public decimal NoteQualite { get; set; }
    }
}
