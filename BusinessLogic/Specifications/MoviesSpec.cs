using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public static class MoviesSpec
    {
        public class OrderedAll : Specification<Movie>
        {
            public OrderedAll()
            {
                Query
                    .OrderBy(x => x.Title)
                    .Include(x => x.Genres)
                    .ThenInclude(x => x.Genre);                    
            }
        }

        public class ById : Specification<Movie>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Genres)
                    .ThenInclude(x => x.Genre);
            }
        }

    }
}
