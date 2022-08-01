namespace weiss_cinema_restapi.OMDB.Models
{
    public class OMDBMoviesResponse : OMDBBaseResponse
    {
        public List<OMDBMovie> Search { get; set; }
        public String TotalResults { get; set; }
    }

    public class OMDBMovie
    {
        public string ImdbID { get; set; }
        public String Title { get; set; }
        public String Year { get; set; }
        public String? Poster { get; set; }
    }
}

