using Microsoft.EntityFrameworkCore;

using TutorialEntityFramework.Data.EntityConfig;
using TutorialEntityFramework.Entities;


namespace TutorialEntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            // Exemplos de configuração (opcional)
            //modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
