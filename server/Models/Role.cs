using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string? Nom { get; set; }

        public ICollection<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
    }
}
