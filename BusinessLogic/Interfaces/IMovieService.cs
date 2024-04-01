using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<IEnumerable<GenreDto>> GetGenresAsync();
        Task<MovieDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateMovieDto movie);
        Task EditAsync(MovieDto movie);
        Task DeleteAsync(int id);
    }
}
