namespace BookManagement.API.Enums
{
    public enum APIResultStatus
    {
        Success = 200,
        ValidationError = 400,
        Error = 500,
        ServerError = 503,
        NotFound = 404
    }
}
