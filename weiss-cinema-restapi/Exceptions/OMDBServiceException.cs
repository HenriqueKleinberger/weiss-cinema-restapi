namespace weiss_cinema_restapi.Exceptions
{
    public class OMDBServiceException : Exception
    {
        public OMDBServiceException(string message)
            : base(message)
        {
        }
    }
}
