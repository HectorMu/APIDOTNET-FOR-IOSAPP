namespace iosClientsAPI.Models
{
    public class HttpJsonResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public HttpJsonResponse(string message, bool status)
        {
            Status = status;
            Message = message;
        }
    }
}
