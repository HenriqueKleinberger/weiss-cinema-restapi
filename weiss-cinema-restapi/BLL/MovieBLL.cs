using weiss_cinema_restapi.BLL.Interfaces;
using weiss_cinema_restapi.DTO;
using weiss_cinema_restapi.Exceptions;
using weiss_cinema_restapi.OMDB.Services.Interfaces;

namespace weiss_cinema_restapi.BLL
{
    public class MovieBLL : IMovieBLL
    {
        private readonly ILogger<MovieBLL> _logger;
        private readonly IOMDBMovieService _omdbMovieService;

        public MovieBLL(ILogger<MovieBLL> logger, IOMDBMovieService omdbMovieService)
        {
            _logger = logger;
            _omdbMovieService = omdbMovieService;
        }

        public async Task<MovieDetailsResponseDTO> GetMovieDetailsAsync(string imdbId)
        {
            try
            {
                _logger.LogInformation("### STARTING GetMovieDetailsAsync ###");
                MovieDetailsResponseDTO movieDetailsDTO = await _omdbMovieService.GetMovieDetailsAsync(imdbId);
                _logger.LogInformation("### ENDING GetMovieDetailsAsync ###");
                return movieDetailsDTO;
            }
            catch (OMDBServiceException exception)
            {
                return new MovieDetailsResponseDTO()
                {
                    IsSuccessful = false,
                    Message = exception.Message                    
                };
            }
        }

        public async Task<MoviesResponseDTO> GetMoviesAsync(String title, int page)
        {
            try
            {
                _logger.LogInformation("### STARTING GetMoviesAsync ###");
                MoviesResponseDTO moviesResponseDTO = await _omdbMovieService.GetMoviesAsync(title, page);
                _logger.LogInformation("### ENDING GetMoviesAsync ###");
                return moviesResponseDTO;
            } catch (OMDBServiceException exception)
            {
                return new MoviesResponseDTO()
                {
                    IsSuccessful = false,
                    Message = exception.Message
                };
            }
        }

    }
}
