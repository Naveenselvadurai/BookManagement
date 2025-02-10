using BookManagement.API.Enums;

namespace BookManagement.API.Models
{
    public class APIResult
    {
        public APIResult(APIResultStatus status,
            string message,
            dynamic? data = null,
            dynamic? exception = null)
        {
            Status = status;
            Message = message;
            Data = data;
            Exception = exception;
        }
        public dynamic? Data { get; set; }
        public dynamic? Exception { get; set; }
        public APIResultStatus Status { get; set; }
        public string Message { get; }
    }
}
