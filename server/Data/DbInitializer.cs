using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // Appliquer les migrations (si base non créée)
            context.Database.Migrate();

            // Seeder les rôles (uniquement si vides)
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { RoleId = 1, Nom = "Admin" },
                    new Role { RoleId = 2, Nom = "Fournisseur" },
                    new Role { RoleId = 3, Nom = "Transitaire" },
                    new Role { RoleId = 4, Nom = "Transporteur" },
                    new Role { RoleId = 5, Nom = "Client" }
                );
                context.SaveChanges();
            }

            // Seeder un utilisateur admin (si aucun utilisateur)
            if (!context.Utilisateurs.Any())
            {
                context.Utilisateurs.Add(new Utilisateur
                {
                    Nom = "Alice Admin",
                    Email = "admin@example.com",
                    MotDePasseHash = "hashed-password", // remplace par un hash réel
                    RoleId = 1,
                    TwoFactorEnabled = true
                });
                context.SaveChanges();
            }

        }
    }
}
