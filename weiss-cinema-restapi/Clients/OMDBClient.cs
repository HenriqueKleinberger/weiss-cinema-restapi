//using FonotradeInvoiceControl.Clients.Interface;
//using FonotradeInvoiceControl.Constants.VHSYS;
using weiss_cinema_restapi.Constants.OMDB;
using RestSharp;
using weiss_cinema_restapi.Clients.Interfaces;

namespace weiss_cinema_restapi.Clients
{
    public class OMDBClient : IOMDBClient
    {
        private RestClient _restClient;

        public OMDBClient(IConfiguration config) => _restClient = new RestClient(config.GetValue<string>(OMDBConfiguration.BASE_URL));

        public async Task<RestResponse> GetAsync(RestRequest request) => await _restClient.GetAsync(request);
    }
}