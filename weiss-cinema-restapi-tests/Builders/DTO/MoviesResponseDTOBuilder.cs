using weiss_cinema_restapi.DTO;
using System;
using System.Collections.Generic;

namespace weiss_cinema_restapi_tests.Builders.DTO
{
    public class MoviesResponseDTOBuilder
    {
        private MoviesResponseDTO _moviesResponseDTO;

        public Boolean IsSuccessful = true;
        public string? Message = null;
        public List<MovieDTO> Movies = new List<MovieDTO>()
        {
            new MovieDTOBuilder().WithTitle("Title 1").WithPoster("Poster 1").Build(),
            new MovieDTOBuilder().WithTitle("Title 2").WithPoster("Poster 2").Build()
        };
        public int TotalResults;

        public MoviesResponseDTOBuilder()
        {
            Random random = new Random();

            _moviesResponseDTO = new MoviesResponseDTO();
            _moviesResponseDTO.IsSuccessful = this.IsSuccessful;
            _moviesResponseDTO.Message = this.Message;
            _moviesResponseDTO.Movies = this.Movies;
            _moviesResponseDTO.TotalResults = random.Next(1, 999);
        }
        public MoviesResponseDTOBuilder WithError(string message)
        {
            _moviesResponseDTO.Message = message;
            _moviesResponseDTO.IsSuccessful = false;
            _moviesResponseDTO.Movies = null;
            _moviesResponseDTO.TotalResults = 0;
            return this;
        }

        public MoviesResponseDTOBuilder WithMovies(List<MovieDTO> movies)
        {
            _moviesResponseDTO.Movies = movies;
            return this;
        }

        public MoviesResponseDTO Build()
        {
            return _moviesResponseDTO;
        }
    }
}
