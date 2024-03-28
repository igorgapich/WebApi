using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repoMovie;
        private readonly IRepository<Genre> _repoGenre;
        private readonly IMapper _mapper; 

        public MovieService(IRepository<Movie> repoMovie,
                            IRepository<Genre> repoGenre,
                            IMapper mapper)
        {
            _repoMovie = repoMovie;
            _repoGenre = repoGenre;
            _mapper = mapper;
        }

        public async Task CreateAsync(MovieDto movieDto)
        {
            await _repoMovie.InsertAsync(_mapper.Map<Movie>(movieDto));
            await _repoMovie.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (_repoMovie.GetByIDAsync(id) == null)
                return;
            await _repoMovie.DeleteAsync(id);
            await _repoMovie.SaveAsync();
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var result = await _repoMovie.GetAsync(includeProperties: new[] { "Genres" });
            return _mapper.Map<IEnumerable<MovieDto>>(result);
        }

        public async Task<MovieDto>? GetByIdAsync(int id)
        {
            if (_repoMovie.GetByIDAsync(id) == null)
                throw new HttpRequestException("Not Found");
            return _mapper.Map<MovieDto>(await _repoMovie.GetByIDAsync(id));
        }

        public async Task EditAsync(MovieDto movieDto)
        {
            await _repoMovie.UpdateAsync(_mapper.Map<Movie>(movieDto));
            await _repoMovie.SaveAsync();
        }

        public async Task<IEnumerable<GenreDto>> GetGenresAsync()
        {
            return _mapper.Map<IEnumerable<GenreDto>>(await _repoGenre.GetAsync());
        }
    }
}
