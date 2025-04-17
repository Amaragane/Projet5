using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet5.Models;

namespace Projet5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<VoitureModel> Voitures { get; set; }
        public DbSet<UserModel> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuration spécifique pour les entités si nécessaire
            modelBuilder.Entity<VoitureModel>().HasKey(v => v.Vin);
            modelBuilder.Entity<UserModel>().HasKey(u => u.Id);
        }
    }
}
