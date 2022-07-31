
using weiss_cinema_restapi.DTO;
using weiss_cinema_restapi.OMDB.Models;

namespace weiss_cinema_restapi.Mappers.OMDB
{
    public static class MovieMapper
    {
        public static MovieDTO ToMovieDTO(this OMDBMovie omdbMovie)
        {
            MovieDTO movieDTO = new MovieDTO()
            {
                ImdbID = omdbMovie.ImdbID,
                Title = omdbMovie.Title,
                Poster = omdbMovie.Poster,
                Year = omdbMovie.Year
            };

            return movieDTO;
        }
    }
}
