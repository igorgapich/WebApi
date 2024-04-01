using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Microsoft.Extensions.Options;

namespace Core.Mappers
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Genre, GenreDto>().ReverseMap();
            // Map Movie into MovieDto
            CreateMap<Movie, MovieDto>()
                .ForMember(movieDto => movieDto.Genres, options => options.MapFrom(movie => movie.Genres.Select(i => i.Genre)));
            CreateMap<MovieDto, Movie>();
            CreateMap<CreateMovieDto, Movie>();
        }                
    }
}