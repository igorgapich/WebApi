using DataAccess.Entities;
using DataAccess.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedMovies();
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
        public DbSet<Movie> Movies { get; set; }
    }
}