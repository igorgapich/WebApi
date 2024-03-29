using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public TimeSpan Duraction { get; set; }
        public IEnumerable<int>? GenreIds { get; set; }
    }
}
