
using weiss_cinema_restapi.DTO;
using weiss_cinema_restapi.OMDB.Models;

namespace weiss_cinema_restapi.Mappers.OMDB
{
    public static class MovieDetailsResponseMapper
    {
        public static MovieDetailsResponseDTO ToMovieDetailsResponseDTO(this OMDBMovieDetailsResponse omdbMovieDetails)
        {
            if (omdbMovieDetails.IsSuccessful())
            {
                MovieDetailsResponseDTO movieDetailsResponseDTO = new MovieDetailsResponseDTO()
                {
                    Actors = omdbMovieDetails.Actors,
                    Director = omdbMovieDetails.Director,
                    Genre = omdbMovieDetails.Genre,
                    ImdbRating = omdbMovieDetails.imdbRating,
                    Plot = omdbMovieDetails.Plot,
                    ReleaseDate = omdbMovieDetails.ReleaseDate,
                    Website = "https://www.globo.com/",
                    ImdbID = omdbMovieDetails.ImdbID,
                    Poster = omdbMovieDetails.Poster,
                    Title = omdbMovieDetails.Title,
                    Year = omdbMovieDetails.Year,
                    IsSuccessful = true
                };
                return movieDetailsResponseDTO;
            } else
            {
                MovieDetailsResponseDTO movieDetailsResponseDTO = new MovieDetailsResponseDTO()
                {
                    Message = omdbMovieDetails.Error,
                    IsSuccessful = false
                };
                return movieDetailsResponseDTO;
            }

        }
    }
}
