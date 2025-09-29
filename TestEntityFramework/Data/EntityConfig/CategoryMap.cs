using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorialEntityFramework.Entities;


namespace TutorialEntityFramework.Data.EntityConfig
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
        }
    }
}
