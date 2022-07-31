namespace weiss_cinema_restapi.OMDB.Models
{    public class OMDBMovieDetailsResponse : OMDBBaseResponse
    {
        public string ImdbID { get; set; }
        public String Title { get; set; }
        public String Year { get; set; }
        public String? Poster { get; set; }
        public String ReleaseDate { get; set; }
        public String Genre { get; set; }
        public String Director { get; set; }
        public String Actors { get; set; }
        public String Plot { get; set; }
        public String imdbRating { get; set; }
        public String? Website { get; set; }
    }
}

