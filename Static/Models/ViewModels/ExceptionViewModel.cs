namespace Static.Models.ViewModels
{
    public class ExceptionViewModel
    {
        public string Title { get; set; } = "Internal Server Error";
        public string Description { get; set; } = "Something Went Wrong!";
        public string? RequestId { get; set; }
    }
}