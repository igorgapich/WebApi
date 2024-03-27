using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntitiesConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Set Primary Key
            builder.HasKey(x => x.Id);

            // Set property configuration
            builder.Property(x => x.Title)
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1024);

            // Set many to many relation
            builder.HasMany(x => x.Genres)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId);
        }
    }
}
