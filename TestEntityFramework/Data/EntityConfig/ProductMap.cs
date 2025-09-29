using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorialEntityFramework.Entities;


namespace TutorialEntityFramework.Data.EntityConfig
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);
            builder.Property(x => x.Price)
                .HasPrecision(38, 2);

            builder.HasOne(m => m.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(m => m.CategoryId);

            builder.Property(x => x.Description);
        }
    }
}
