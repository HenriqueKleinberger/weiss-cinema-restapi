namespace weiss_cinema_restapi.DTO
{
    public class MoviesResponseDTO : BaseResponseDTO
    {
        public List<MovieDTO> Movies { get; set; }
        public int TotalResults { get; set; }
    }

    public class MovieDTO
    {
        public string ImdbID { get; set; }
        public String Title { get; set; }
        public String Year { get; set; }
        public String? Poster { get; set; }
    }
}

