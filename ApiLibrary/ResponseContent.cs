namespace ApiLibrary
{
    public class ResponseContent
    {
        public bool IsCompleted { get; set; }
        public bool IsFaulted { get; set; }
        public string Signature { get; set; }
        public string Exception { get; set; }
        public string Result { get; set; }
    }
}
