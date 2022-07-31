using Microsoft.AspNetCore.Mvc;
using weiss_cinema_restapi.BLL.Interfaces;
using weiss_cinema_restapi.DTO;

namespace weiss_cinema_restapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieBLL _movieBLL;

        public MovieController(ILogger<MovieController> logger, IMovieBLL movieBLL)
        {
            _logger = logger;
            _movieBLL = movieBLL;
        }

        /// <summary>
        /// Get movies from OMDB database
        /// </summary>
        /// <remarks>
        /// 
        /// Get movies from OMDB database with pagination
        ///     
        /// </remarks>
        /// <param name="title">Movie title to search</param>
        /// <param name="page">Number of the page to search</param>
        /// <response code="200">Success</response>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesResponseDTO))]
        public async Task<IActionResult> Get(String title, int page)
        {
            MoviesResponseDTO response = await _movieBLL.GetMoviesAsync(title, page);
            return Ok(response);

        }

        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MoviesResponseDTO))]
        public async Task<IActionResult> GetDetails(String imdbId)
        {
            MovieDetailsResponseDTO response = await _movieBLL.GetMovieDetailsAsync(imdbId);
            return Ok(response);

        }
    }
}