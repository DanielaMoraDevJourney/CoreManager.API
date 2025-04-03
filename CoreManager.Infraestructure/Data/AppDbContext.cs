using CoreManager.API.CoreManager.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoreManager.API.CoreManager.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Phone).IsRequired().HasMaxLength(20);
                entity.Property(u => u.BirthDate).IsRequired();
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Username).IsRequired().HasMaxLength(50);
                entity.Property(a => a.Email).IsRequired().HasMaxLength(100);
                entity.Property(a => a.PasswordHash).IsRequired();
            });
        }

        public static async Task SeedAsync(AppDbContext context, IConfiguration config)
        {
            Console.WriteLine("🚀 Ejecutando SeedAsync...");

            var username = config["DefaultAdmin:Username"];
            var email = config["DefaultAdmin:Email"];
            var password = config["DefaultAdmin:Password"];

            Console.WriteLine($"🔍 Configuración leída: Username={username}, Email={email}");

            if (!await context.AdminUsers.AnyAsync(u => u.Username == username))
            {
                Console.WriteLine("🟢 No se encontró admin existente, creando uno...");

                var hasher = new PasswordHasher<AdminUser>();
                var admin = new AdminUser
                {
                    Id = Guid.NewGuid(),
                    Username = username!,
                    Email = email!
                };
                admin.PasswordHash = hasher.HashPassword(admin, password!);

                context.AdminUsers.Add(admin);
                await context.SaveChangesAsync();

                Console.WriteLine("✅ Admin creado correctamente.");
            }
            else
            {
                Console.WriteLine("⚠️ Ya existe un admin con ese username, no se creó uno nuevo.");
            }
        }



    }
}
