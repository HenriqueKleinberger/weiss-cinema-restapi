using weiss_cinema_restapi.DTO;
using System;
using System.Collections.Generic;
using weiss_cinema_restapi.OMDB.Models;
using weiss_cinema_restapi.Constants.OMDB;

namespace weiss_cinema_restapi_tests.Builders.OMDB
{
    public class OMDBMoviesResponseBuilder
    {
        private OMDBMoviesResponse _omdbMoviesResponse;

        private List<OMDBMovie> Search = new List<OMDBMovie>()
        {
            new OMDBMovieBuilder().WithTitle("Title 1").WithPoster("Poster 1").Build(),
            new OMDBMovieBuilder().WithTitle("Title 2").WithPoster("Poster 2").Build()
        };
        private String TotalResults = "200";
        private String Response = OMDBRequestResponse.TRUE;
        private String Error = null;

        public OMDBMoviesResponseBuilder()
        {
            Random random = new Random();

            _omdbMoviesResponse = new OMDBMoviesResponse();
            _omdbMoviesResponse.Response = this.Response;
            _omdbMoviesResponse.Error = this.Error;
            _omdbMoviesResponse.Search = this.Search;
            _omdbMoviesResponse.TotalResults = random.Next(1, 999).ToString();
        }

        public OMDBMoviesResponseBuilder WithError(string message)
        {
            _omdbMoviesResponse.Response = OMDBRequestResponse.FALSE;
            _omdbMoviesResponse.Error = message;
            _omdbMoviesResponse.Search = null;
            _omdbMoviesResponse.TotalResults = null;
            return this;
        }

        public OMDBMoviesResponseBuilder WithSearch(List<OMDBMovie> movies)
        {
            _omdbMoviesResponse.Search = movies;
            return this;
        }

        public OMDBMoviesResponse Build()
        {
            return _omdbMoviesResponse;
        }
    }
}
