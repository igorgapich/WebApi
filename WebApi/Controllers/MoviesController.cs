using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;

        public MoviesController(IRepository<Movie> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            //(includeProperties: new[] { "Genres" }).ToList()

            return Ok(await _repository.GetAsync(includeProperties: new[] { "Genres" }));
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            return Ok(await _repository.GetByIDAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Movie movie)
        {
            await _repository.InsertAsync(movie);
            await _repository.SaveAsync();
            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Movie movie)
        {
            await _repository.GetAsync();
            await _repository.GetAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task <IActionResult> Delete(int id)
        {
            await _repository.GetByIDAsync(id);
            await _repository.SaveAsync();
            return Ok();
        }
    }
}
