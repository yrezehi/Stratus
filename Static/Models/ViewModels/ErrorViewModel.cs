namespace Static.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string Type { get; set; } = "Internal Server Error";
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}