using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Entities;

namespace BusinessLogic.Mappers
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Genre, GenreDto>()
                .ReverseMap();
            // Map Movie into MovieDto
            CreateMap<Movie, MovieDto>()
                .ForMember(movieDto => movieDto.Genres, options => options.MapFrom(movie => movie.Genres.Select(item => item.Genre)));
            CreateMap<Movie, MovieDto>();
        }
    }
}
