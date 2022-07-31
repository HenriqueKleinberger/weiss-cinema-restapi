using weiss_cinema_restapi.BLL;
using weiss_cinema_restapi.BLL.Interfaces;
using weiss_cinema_restapi.Clients;
using weiss_cinema_restapi.Clients.Interfaces;
using weiss_cinema_restapi.OMDB.Services.Interfaces;
using weiss_cinema_restapi.Services.OMDB;

namespace weiss_cinema_restapi.Utils
{
    public static class DependencyInjector
    {
        public static void InjectCommonDependencies(IServiceCollection services)
        {
            services.AddScoped<IMovieBLL, MovieBLL>();
            services.AddScoped<IOMDBMovieService, OMDBMovieService>();
            services.AddScoped<IOMDBService, OMDBService>();
            services.AddScoped<IOMDBClient, OMDBClient>();
        }
    }
}
