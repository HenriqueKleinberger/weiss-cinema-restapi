using weiss_cinema_restapi.DTO;
using System;
using weiss_cinema_restapi.OMDB.Models;

namespace weiss_cinema_restapi_tests.Builders.OMDB
{
    public class OMDBMovieBuilder
    {
        private OMDBMovie _OMDBMovie;

        private string Title = "Movie Title";
        private string Poster = "Poster";

        public OMDBMovieBuilder()
        {
            Random random = new Random();

            _OMDBMovie = new OMDBMovie();
            _OMDBMovie.ImdbID = random.Next(1111, 9999).ToString();
            _OMDBMovie.Year = random.Next(1974, 2022).ToString();
            _OMDBMovie.Title = this.Title;
            _OMDBMovie.Poster = this.Poster;
        }

        public OMDBMovieBuilder WithTitle(string title)
        {
            _OMDBMovie.Title = title;
            return this;
        }

        public OMDBMovieBuilder WithPoster(string poster)
        {
            _OMDBMovie.Poster = poster;
            return this;
        }

        public OMDBMovie Build()
        {
            return _OMDBMovie;
        }
    }
}
