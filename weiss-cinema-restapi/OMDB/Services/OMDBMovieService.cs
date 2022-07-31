using Newtonsoft.Json;
using RestSharp;
using weiss_cinema_restapi.Constants.OMDB;
using weiss_cinema_restapi.DTO;
using weiss_cinema_restapi.Exceptions;
using weiss_cinema_restapi.Mappers.OMDB;
using weiss_cinema_restapi.OMDB.Models;
using weiss_cinema_restapi.OMDB.Services.Interfaces;

namespace weiss_cinema_restapi.Services.OMDB
{
    public class OMDBMovieService : IOMDBMovieService
    {

        private readonly IOMDBService _omdbService;
        private readonly string _apiKey;
        private RestResponse _response;

        public OMDBMovieService(IConfiguration configuration, IOMDBService omdbService)
        {
            _omdbService = omdbService;
            _apiKey = configuration.GetValue<string>(OMDBConfiguration.API_KEY);
        }

        public async Task<MovieDetailsResponseDTO> GetMovieDetailsAsync(string imdbId)
        {
            _response = await _omdbService.GetAsync($"?apikey={_apiKey}&i={imdbId}");
            OMDBMovieDetailsResponse movieDetails = ParseResponse<OMDBMovieDetailsResponse>();
            return movieDetails.ToMovieDetailsResponseDTO();
                
        }

        public async Task<MoviesResponseDTO> GetMoviesAsync(string title, int page)
        {
            _response = await _omdbService.GetAsync($"?apikey={_apiKey}&s={title}*&page={page}");
            OMDBMovieResponse omdbResponse = ParseResponse<OMDBMovieResponse>();
            return omdbResponse.ToMovieResponseDTO();
        }

        private void ValidateResponse()
        {
            if (_response == null || !_response.IsSuccessful)
                throw new OMDBServiceException("Error integrating with OMDB");
        }

        private T ParseResponse<T>()
        {
            ValidateResponse();
            return JsonConvert.DeserializeObject<T>(_response.Content);
        }
    }
}
