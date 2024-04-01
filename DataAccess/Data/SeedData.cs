using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Drama"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Crime"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Action"
                },
                new Genre()
                {
                    Id = 4,
                    Name = "Adventure"
                },
                new Genre()
                {
                    Id = 5,
                    Name = "History"
                },
                new Genre()
                {
                    Id = 6,
                    Name = "Mistery"
                },
                new Genre()
                {
                    Id = 7,
                    Name = "Triller"
                }
            });
        }
        public static void SeedMovies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new Movie[] {
                new Movie(){
                    Id = 1,
                    Title = "Dune",
                    Year = 2021,
                    Description = "Dune is a 2021 American epic science fiction film directed by Denis Villeneuve, who co-wrote the screenplay with Jon Spaihts and Eric Roth",
                    Duration = new TimeSpan(2,35,0)
                },
                new Movie(){
                    Id = 2,
                    Title = "Main on Fire",
                    Year = 2004,
                    Description = "John, an ex-CIA officer, is entrusted with the responsibility of safeguarding an entrepreneur's daughter. When the girl gets kidnapped, John vows to seek revenge.",
                    Duration = new TimeSpan(2,26,00)
                },
                new Movie(){
                    Id = 3,
                    Title = "Gladiator",
                    Year = 2000,
                    Description = "Commodus takes over power and demotes Maximus, one of the preferred generals of his father, Emperor Marcus Aurelius. As a result, Maximus is relegated to fighting till death as a gladiator.",
                    Duration = new TimeSpan(2,35,00)
                },
                new Movie(){
                    Id = 4,
                    Title = "Only the Brave",
                    Year = 2017,
                    Description = "When a group of firefighters from California ignores a warning by Superintendent Eric Marsh about a wildfire, he decides to get his crew certified as wildfire hotshots.",
                    Duration = new TimeSpan(2,13,00)
                },
                new Movie(){
                    Id = 5,
                    Title = "Serenity",
                    Year = 2019,
                    Description = "Baker Dill is a fishing boat captain who leads tours off of the tranquil enclave of Plymouth Island. His peaceful life is soon shattered when his ex-wife Karen tracks him down. Desperate for help, Karen begs Baker to save her -- and their young son -- from her abusive husband. She wants him to take the brute out for a fishing excursion -- then throw him overboard to the sharks. Thrust back into a life that he wanted to forget, Baker now finds himself struggling to choose between right and wrong.",
                    Duration = new TimeSpan(1,46,00)
                },
                new Movie(){
                    Id = 6,
                    Title = "Unstoppable",
                    Year = 2010,
                    Description = "An unmanned, half-mile-long freight train hurtles towards a town at breakneck speed. An engineer and a young conductor, who happen to be on the same route, must race against time to try and stop it.",
                    Duration = new TimeSpan(1,38,00)
                },
            });
        }
        public static void SeedMovieGenre(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre[]
            {
                new MovieGenre(){ MovieId = 1, GenreId = 1 },
                new MovieGenre(){ MovieId = 1, GenreId = 2 },
                new MovieGenre(){ MovieId = 1, GenreId = 3 },

                new MovieGenre(){ MovieId = 2, GenreId = 1 },
                new MovieGenre(){ MovieId = 2, GenreId = 3 },
                new MovieGenre(){ MovieId = 2, GenreId = 7 },

                new MovieGenre(){ MovieId = 3, GenreId = 1 },
                new MovieGenre(){ MovieId = 3, GenreId = 3 },
                new MovieGenre(){ MovieId = 3, GenreId = 5 },

                new MovieGenre(){ MovieId = 4, GenreId = 1 },
                new MovieGenre(){ MovieId = 4, GenreId = 7 },
               
                new MovieGenre(){ MovieId = 5, GenreId = 1 },
                new MovieGenre(){ MovieId = 5, GenreId = 7 },

                new MovieGenre(){ MovieId = 6, GenreId = 1 },
                new MovieGenre(){ MovieId = 6, GenreId = 3 },
            });
        }
    }
}