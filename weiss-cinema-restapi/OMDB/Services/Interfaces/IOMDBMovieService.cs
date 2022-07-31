using weiss_cinema_restapi.DTO;

namespace weiss_cinema_restapi.OMDB.Services.Interfaces
{
    public interface IOMDBMovieService
    {
        public Task<MoviesResponseDTO> GetMoviesAsync(String name, int page);

        public Task<MovieDetailsResponseDTO> GetMovieDetailsAsync(String imdbId);
    }
}
