using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Specifications;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MoviesService : IMovieService
    {
        private readonly IRepository<Movie> _repoMovie;
        private readonly IRepository<Genre> _repoGenre;
        private readonly IRepository<MovieGenre> _repoMovieGenre;
        private readonly IMapper _mapper;

        public MoviesService(IRepository<Movie> repoMovie,
                            IRepository<Genre> repoGenre,
                            IRepository<MovieGenre> repoMovieGenre,
                            IMapper mapper)
        {
            _repoMovie = repoMovie;
            _repoGenre = repoGenre;
            _repoMovieGenre = repoMovieGenre;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _repoMovie.InsertAsync(_mapper.Map<Movie>(movie));
            await _repoMovie.SaveAsync();

            // After SaveAsync we can get movie id
            if (movieDto.GenreIds != null)
            {
                foreach (var genreId in movieDto.GenreIds)
                {
                  await _repoMovieGenre.InsertAsync(new MovieGenre() { 
                      MovieId = movie.Id,
                      GenreId = genreId
                  });
                }
                await _repoMovieGenre.SaveAsync();
            }
        }

        public async Task EditAsync(MovieDto movie)
        {
            await _repoMovie.UpdateAsync(_mapper.Map<Movie>(movie));
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
            //var movies = await _repoMovie.GetAsync(includeProperties: new[] { "Genres" });
            var movies = await _repoMovie.GetListBySpec(new MoviesSpec.OrderedAll());
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<MovieDto?> GetByIdAsync(int id)
        {
            //if ((await _repoMovie.GetByIDAsync(id)) == null)
            var movie = await _repoMovie.GetItemBySpec(new MoviesSpec.ById(id));
            if (movie == null)
                throw new HttpRequestException("Not Found");
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<IEnumerable<GenreDto>> GetGenresAsync()
        {
            List<Genre> genres = (await _repoGenre.GetAsync()).ToList();
            return _mapper.Map<IEnumerable<GenreDto>>(genres);
        }
    }
}
