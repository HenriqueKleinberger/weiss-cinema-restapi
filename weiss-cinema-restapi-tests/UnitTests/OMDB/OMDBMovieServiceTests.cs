using Microsoft.Extensions.Logging;
using Moq;
using weiss_cinema_restapi.BLL;
using weiss_cinema_restapi.OMDB.Services.Interfaces;
using weiss_cinema_restapi.DTO;
using weiss_cinema_restapi_tests.Builders.DTO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using weiss_cinema_restapi.Services.OMDB;
using RestSharp;
using weiss_cinema_restapi.OMDB.Models;
using System.Net;
using Newtonsoft.Json;
using weiss_cinema_restapi_tests.Builders.OMDB;
using System;
using System.Collections.Generic;

namespace weiss_cinema_restapi_tests.UnitTests.OMDB
{
    [TestClass]
    public class OMDBMovieServiceTests
    {
        private OMDBMovieService _omdbMovieService;
        private readonly Mock<IOMDBService> _omdbServiceMock;
        private readonly IConfiguration _configuration;
        private readonly string API_KEY = "key";

        public OMDBMovieServiceTests()
        {
            var appSettings = @"{""omdb"":{
            ""api-config"" : {
            ""api-key"" : ""key"",
            ""base-url"" : ""base-url""
            }}}";

            var builder = new ConfigurationBuilder();

            builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)));

            _configuration = builder.Build();
            _omdbServiceMock = new Mock<IOMDBService>();
        }

        [TestMethod]
        public async Task WhenGetMoviesAsyncIsCalled_ThenShouldReturnMoviesFromOMDBService()
        {

            //Arrange
            string title = "title";
            int page = 1;
            OMDBMoviesResponse mockResponse = new OMDBMoviesResponseBuilder().Build();
            MoviesResponseDTO expectedMoviesResponseDTO = new MoviesResponseDTOBuilder()
                .WithTotalResults(Int32.Parse(mockResponse.TotalResults))
                .WithMovies(
                    new List<MovieDTO>()
                    {
                        new MovieDTOBuilder()
                            .WithTitle(mockResponse.Search[0].Title)
                            .WithPoster(mockResponse.Search[0].Poster)
                            .WithYear(mockResponse.Search[0].Year)
                            .WithImdbId(mockResponse.Search[0].ImdbID)
                            .Build(),
                        new MovieDTOBuilder().WithTitle(mockResponse.Search[1].Title)
                            .WithPoster(mockResponse.Search[1].Poster)
                            .WithYear(mockResponse.Search[1].Year)
                            .WithImdbId(mockResponse.Search[1].ImdbID)
                            .Build()
                    })
                .Build();

            _omdbServiceMock
                .Setup(s => s.GetAsync($"?apikey={API_KEY}&s={title}*&page={page}"))
                .Returns(Task.FromResult(new RestResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonConvert.SerializeObject(mockResponse),
                    IsSuccessful = true
                }));

            //Act
            _omdbMovieService = new OMDBMovieService(_configuration, _omdbServiceMock.Object);
            MoviesResponseDTO actualMoviesResponseDTO = await _omdbMovieService.GetMoviesAsync(title, page);

            //Assert
            AssertEqualMoviesResponseDTO(expectedMoviesResponseDTO, actualMoviesResponseDTO);
        }

        

        private void AssertEqualMoviesResponseDTO(MoviesResponseDTO expectedMoviesResponseDTO, MoviesResponseDTO actualMoviesResponseDTO)
        {
            Assert.AreEqual(expectedMoviesResponseDTO.Message, actualMoviesResponseDTO.Message);
            Assert.AreEqual(expectedMoviesResponseDTO.IsSuccessful, actualMoviesResponseDTO.IsSuccessful);
            Assert.AreEqual(expectedMoviesResponseDTO.TotalResults, actualMoviesResponseDTO.TotalResults);

            AssertEqualMoviesDTO(expectedMoviesResponseDTO.Movies[0], actualMoviesResponseDTO.Movies[0]);
            AssertEqualMoviesDTO(expectedMoviesResponseDTO.Movies[1], actualMoviesResponseDTO.Movies[1]);
        }

        private void AssertEqualMoviesDTO(MovieDTO expectedMovieDTO, MovieDTO actualMovieDTO)
        {
            Assert.AreEqual(expectedMovieDTO.Title, actualMovieDTO.Title);
            Assert.AreEqual(expectedMovieDTO.Poster, actualMovieDTO.Poster);
            Assert.AreEqual(expectedMovieDTO.Year, actualMovieDTO.Year);
            Assert.AreEqual(expectedMovieDTO.ImdbID, actualMovieDTO.ImdbID);
        }
    }
}
