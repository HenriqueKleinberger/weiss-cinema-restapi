using RestSharp;


namespace weiss_cinema_restapi.Clients.Interfaces
{
    public interface IOMDBClient
    {
        Task<RestResponse> GetAsync(RestRequest request);
    }
}