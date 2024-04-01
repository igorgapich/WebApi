using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            // Set Primary Key
            builder.HasKey(x => x.Id);

            // Set property configuration
            builder.Property(x => x.Name)
                .HasMaxLength(180)
                .IsRequired();

            // Set many to many relation
            builder.HasMany(x => x.Movies)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
