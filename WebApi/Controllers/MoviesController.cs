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
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GetByID(id));
        }

        [HttpPost("Create")]
        public IActionResult Create(Movie movie)
        {
            _repository.Insert(movie);
            _repository.Save();
            return Ok();
        }

        [HttpPut("Edit")]
        public IActionResult Edit(Movie movie)
        {
            _repository.Update(movie);
            _repository.Save();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return Ok();
        }
    }
}
