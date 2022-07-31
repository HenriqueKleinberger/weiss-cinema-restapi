using weiss_cinema_restapi.DTO;

namespace weiss_cinema_restapi.BLL.Interfaces
{
    public interface IMovieBLL
    {
        public Task<MoviesResponseDTO> GetMoviesAsync(String name, int page);

        public Task<MovieDetailsResponseDTO> GetMovieDetailsAsync(String imdbId);
    }
}
