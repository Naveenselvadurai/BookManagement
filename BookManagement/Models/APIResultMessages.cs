using BookManagement.API.Enums;

namespace BookManagement.API.Models
{
    public static class APIResultMessages
    {
        public static string GetMessage(APIResultStatus status)
        {
            return status switch
            {
                APIResultStatus.Success => "Operation Successful.",
                APIResultStatus.Error => "An error occurred while processing your request.",
                APIResultStatus.ValidationError => "Invalid input data.",
                APIResultStatus.NotFound => "Not Found.",
                _ => "Unknown error"
            };
        }
    }
}
