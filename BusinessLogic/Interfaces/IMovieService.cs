using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<Movie>? GetByIdAsync(int id);
        Task CreateAsync(Movie movie);
        Task EditAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}
