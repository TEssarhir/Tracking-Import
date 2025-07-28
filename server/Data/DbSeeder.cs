using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Helpers;

namespace server.Data
{
    public static class DbSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // Appliquer les migrations (si base non créée)
            context.Database.Migrate();

            // Seeder un utilisateur admin (si aucun utilisateur)
            if (!context.Utilisateurs.Any())
            {
                context.Utilisateurs.Add(new Utilisateur
                {
                    Prenom = "Yaya",
                    Nom = "Lghzala",
                    Gender = UserGender.F,
                    Email = "yaya@example.com",
                    MotDePasseHash = PasswordHelper.HashPassword("Yaya123!"),
                    Role = UserRole.Admin, // Use enum value directly
                    TwoFactorEnabled = false // No 2FA for now
                });
                context.SaveChanges();
            }

        }
    }
}
