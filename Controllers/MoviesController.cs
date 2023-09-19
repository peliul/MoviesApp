using Microsoft.AspNetCore.Mvc;
using MoviesListApi.DTO;
using MoviesListApi.Interfaces;
using System.Reflection;

namespace MoviesListApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _moviesRepository.GetMoviesAsync();

            return Ok(movies);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesByCategory([FromQuery] string category)
        {
            var movies = await _moviesRepository.GetMoviesByCategoryAsync(category);

            return Ok(movies);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies([FromQuery] string tag)
        {
            var movies = await _moviesRepository.GetMoviesByTagAsync(tag);

            return Ok(movies);
        }
    }
}
