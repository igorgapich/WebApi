

namespace DataAccess.Entities
{
    public class MovieGenre
    {
        //composition key MovieId + GenreId
        public Movie MovieId { get; set; }
        public Genre GenreId { get; set;}
        public Movie? Movie { get; set; }
        public Genre? Genre { get; set; }
    }
}
