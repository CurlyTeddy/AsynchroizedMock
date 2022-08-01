namespace CustomReportLibrary
{
    public class RequestContent
    {
        public long Dtno { get; set; }
        public long Ftno { get; set; }
        public string Params { get; set; } = null!;
        public string AssignSpid { get; set; } = null!;
        public string KeyMap { get; set; } = null!;
    }
}
