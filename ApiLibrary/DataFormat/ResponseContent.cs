namespace CustomReportLibrary
{
    public class ResponseContent
    {
        public bool IsCompleted { get; set; }
        public bool IsFaulted { get; set; }
        public string Signature { get; set; } = null!;
        public string Exception { get; set; } = null!;
        public string Result { get; set; } = null!;
    }
}
