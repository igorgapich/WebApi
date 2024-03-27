

namespace DataAccess.Entities
{
    public class MovieGenre
    {
        //composition key MovieId + GenreId
        public int MovieId { get; set; }
        public int GenreId { get; set;}
        public Movie? Movie { get; set; }
        public Genre? Genre { get; set; }
    }
}
