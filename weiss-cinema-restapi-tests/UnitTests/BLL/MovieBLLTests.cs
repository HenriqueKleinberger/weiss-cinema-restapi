using Microsoft.Extensions.Logging;
using Moq;
using weiss_cinema_restapi.BLL;
using weiss_cinema_restapi.OMDB.Services.Interfaces;
using weiss_cinema_restapi.DTO;
using weiss_cinema_restapi_tests.Builders.DTO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace weiss_cinema_restapi_tests.UnitTests.BLL
{
    [TestClass]
    public class OMDBMovieServiceTests
    {
        private MovieBLL _movieBLL;

        private readonly Mock<ILogger<MovieBLL>> _loggerMock;
        private readonly Mock<IOMDBMovieService> _omdbMovieServiceMock;

        public OMDBMovieServiceTests()
        {
            _loggerMock = new Mock<ILogger<MovieBLL>>();
            _omdbMovieServiceMock = new Mock<IOMDBMovieService>();
        }

        [TestMethod]
        public async Task WhenGetMoviesAsyncIsCalled_ThenShouldReturnMoviesFromOMDBService()
        {
            //Arrange
            string title = "Title";
            int page = 1;
            MoviesResponseDTO expectedMoviesResponseDTO = new MoviesResponseDTOBuilder().Build();

            _omdbMovieServiceMock
                .Setup(s => s.GetMoviesAsync(title, page))
                .Returns(Task.FromResult(expectedMoviesResponseDTO));

            //Act
            _movieBLL = new MovieBLL(_loggerMock.Object, _omdbMovieServiceMock.Object);
            MoviesResponseDTO actualMoviesResponseDTO = await _movieBLL.GetMoviesAsync(title, page);

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
