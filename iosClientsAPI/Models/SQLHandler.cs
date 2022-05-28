namespace iosClientsAPI.Models
{
    public class SQLHandler
    {
        public string Message { get; set; } = "";
        public string SuccessMessage { get; set; } = "";
        public bool Status { get; set; } = false;

        public SQLHandler(string message)
        {
            Message = message;
            Status = false;
        }
        public SQLHandler(string message, bool onSuccess)
        {
            Message = message;
            Status = onSuccess;
        }
    }
}
