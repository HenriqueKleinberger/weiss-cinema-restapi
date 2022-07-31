using Microsoft.Extensions.Configuration;
using RestSharp;
using weiss_cinema_restapi.Clients.Interfaces;
using weiss_cinema_restapi.OMDB.Services.Interfaces;

namespace weiss_cinema_restapi.Services.OMDB
{
    public class OMDBService : IOMDBService
    {

        private IOMDBClient _omdbClient;
        private RestRequest _request;
        private string _url;

        public OMDBService(IOMDBClient restClient)
        {
            _omdbClient = restClient;
        }

        public async Task<RestResponse> GetAsync(string url)
        {
            _url = url;

            ConfigRequest();

            RestResponse restResponse = await _omdbClient.GetAsync(_request);
            return restResponse;
        }

        private void ConfigRequest() => _request = new RestRequest(_url);
    }
}
