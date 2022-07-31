using weiss_cinema_restapi.Constants.OMDB;

namespace weiss_cinema_restapi.OMDB.Models
{
    public abstract class OMDBBaseResponse
    {
        public String Response { get; set; }
        public String Error { get; set; }

        public bool IsSuccessful() => Response == OMDBRequestResponse.TRUE;
    }
}