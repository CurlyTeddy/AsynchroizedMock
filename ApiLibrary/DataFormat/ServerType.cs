namespace CustomReportLibrary
{
    public class ServerType
    {
        private int limit;
        public ICustomReportService Server { get; }
        public int Limit => limit;

        public ServerType(ICustomReportService server, int limit)
        {
            Server = server;
            this.limit = limit;
        }

        public int Increase()
        {
            return Interlocked.Increment(ref limit);
        }

        public int Decrease()
        {
            return Interlocked.Decrement(ref limit);
        }
    }
}
