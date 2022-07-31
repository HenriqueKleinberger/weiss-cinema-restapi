
using weiss_cinema_restapi.DTO;
using weiss_cinema_restapi.OMDB.Models;

namespace weiss_cinema_restapi.Mappers.OMDB
{
    public static class MovieResponseMapper
    {
        public static MoviesResponseDTO ToMovieResponseDTO(this OMDBMovieResponse omdbMovieResponse)
        {
            if (omdbMovieResponse.IsSuccessful()) {
                MoviesResponseDTO movieResponseDTO = new MoviesResponseDTO()
                {
                    IsSuccessful = true,
                    Movies = omdbMovieResponse.Search.ConvertAll(m => m.ToMovieDTO()),
                    Message = null,
                    TotalResults = Int32.Parse(omdbMovieResponse.TotalResults)
                };
                return movieResponseDTO;
            } else
            {
                MoviesResponseDTO movieResponseDTO = new MoviesResponseDTO()
                {
                    IsSuccessful = false,
                    Movies = new List<MovieDTO>(),
                    Message = omdbMovieResponse.Error
                };
                return movieResponseDTO;
            }

        }
    }
}
