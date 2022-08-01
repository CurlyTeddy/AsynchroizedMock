namespace CustomReportLibrary
{
    public interface ICustomReportService
    {
        Task<ResponseContent> CustomReportPostAsync(RequestContent content);
    }
}
