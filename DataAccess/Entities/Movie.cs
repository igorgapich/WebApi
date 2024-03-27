

namespace DataAccess.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<MovieGenre>? Genres { get; }
    }
}
