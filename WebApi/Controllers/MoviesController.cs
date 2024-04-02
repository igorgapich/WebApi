using Core.DTOs;
using Core.Interfaces;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _moviesService;

        public MoviesController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }

        [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //(includeProperties: new[] { "Genres" }).ToList()

            return Ok(await _moviesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await _moviesService.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMovieDto movie)
        {
            await _moviesService.CreateAsync(movie);
            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(MovieDto movie)
        {
            await _moviesService.EditAsync(movie);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _moviesService.DeleteAsync(id);
            return Ok();
        }
    }
}
