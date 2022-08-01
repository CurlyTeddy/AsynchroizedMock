namespace CustomReportLibrary
{
    public class ReverseProxy : ICustomReportService
    {
        private List<ServerType> servers;
        private SemaphoreSlim semaphore;
        private SynchronizedCollection<int> availableServers;
        private Random random;

        public ReverseProxy(IEnumerable<ServerType> servers)
        {
            this.servers = servers.ToList();
            availableServers = new SynchronizedCollection<int>();
            random = new Random();

            int totalServer = 0;
            for (int i = 0; i < this.servers.Count; ++i)
            {
                totalServer += this.servers[i].Limit;
                availableServers.Add(i);
            }
            semaphore = new(0, totalServer);
        }

        public async Task<ResponseContent> CustomReportPostAsync(RequestContent content)
        {
            await semaphore.WaitAsync();
            int selectedServer = random.Next(0, availableServers.Count);

            while (servers[selectedServer].Decrease() < 0)
            {
                availableServers.Remove(selectedServer);
                servers[selectedServer].Increase();
                selectedServer = random.Next(0, availableServers.Count);
            }
            
            ResponseContent response = await servers[selectedServer].Server.CustomReportPostAsync(content);
            servers[selectedServer].Increase();
            if (!availableServers.Contains(selectedServer))
            {
                availableServers.Add(selectedServer);
            }
            semaphore.Release();

            return response;
        }
    }
}
