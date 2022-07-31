using RestSharp;

namespace weiss_cinema_restapi.OMDB.Services.Interfaces
{
    public interface IOMDBService
    {
        public Task<RestResponse> GetAsync(string url);
    }
}
