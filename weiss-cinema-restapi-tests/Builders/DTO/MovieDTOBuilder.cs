using weiss_cinema_restapi.DTO;
using System;

namespace weiss_cinema_restapi_tests.Builders.DTO
{
    public class MovieDTOBuilder
    {
        private MovieDTO _movieDTO;

        private string Title = "Movie Title";
        private string Poster = "Poster";

        public MovieDTOBuilder()
        {
            Random random = new Random();

            _movieDTO = new MovieDTO();
            _movieDTO.ImdbID = random.Next(1111, 9999).ToString();
            _movieDTO.Year = random.Next(1974, 2022).ToString();
            _movieDTO.Title = this.Title;
            _movieDTO.Poster = this.Poster;
        }

        public MovieDTOBuilder WithTitle(string title)
        {
            _movieDTO.Title = title;
            return this;
        }

        public MovieDTOBuilder WithPoster(string poster)
        {
            _movieDTO.Poster = poster;
            return this;
        }

        public MovieDTOBuilder WithYear(string year)
        {
            _movieDTO.Year = year;
            return this;
        }

        public MovieDTOBuilder WithImdbId(string imdbId)
        {
            _movieDTO.ImdbID = imdbId;
            return this;
        }

        public MovieDTO Build()
        {
            return _movieDTO;
        }
    }
}
