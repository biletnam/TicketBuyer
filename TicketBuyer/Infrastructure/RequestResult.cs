namespace TicketBuyer.ViewModels
{
    public class RequestResult
    {
        public RequestState State { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
