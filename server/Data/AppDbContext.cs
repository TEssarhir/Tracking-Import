using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Transporteur> Transporteurs { get; set; }
        public DbSet<Transitaire> Transitaires { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AppelOffre> AppelsOffres { get; set; }
        public DbSet<Soumission> Soumissions { get; set; }
        public DbSet<Tracking> Trackings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Utilisateur>()
                .Property(u => u.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Utilisateur>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Relation AppelOffre - Client
            modelBuilder.Entity<AppelOffre>()
                .HasOne(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation Soumission - AppelOffre / Fournisseur
            modelBuilder.Entity<Soumission>()
                .HasOne(s => s.AppelOffre)
                .WithMany()
                .HasForeignKey(s => s.AppelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Soumission>()
                .HasOne(s => s.Fournisseur)
                .WithMany()
                .HasForeignKey(s => s.FournisseurId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation Document - Utilisateur
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Utilisateur)
                .WithMany()
                .HasForeignKey(d => d.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
