using System.Collections.Concurrent;

namespace CustomReportLibrary
{
    public class ReverseProxy : ICustomReportService
    {
        private List<ServerType> servers;
        private ConcurrentQueue<ICustomReportService> serviceQueue;
        private SemaphoreSlim semaphore;
        private Random random;

        public ReverseProxy(IEnumerable<ServerType> servers)
        {
            this.servers = servers.ToList();
            random = new Random();

            int totalServer = this.servers.Select(server => server.Limit).Sum();
            List<ICustomReportService> serverResource = servers.SelectMany(server => Enumerable.Repeat(server.Server, server.Limit))
                .OrderBy(_ => random.Next()).ToList();
            serviceQueue = new ConcurrentQueue<ICustomReportService>(serverResource);
            semaphore = new(0, totalServer);
        }

        public async Task<ResponseContent> CustomReportPostAsync(RequestContent content)
        {
            await semaphore.WaitAsync();
            serviceQueue.TryDequeue(out ICustomReportService? service);
            ResponseContent response = await service!.CustomReportPostAsync(content);
            serviceQueue.Enqueue(service);
            semaphore.Release();

            return response;
        }
    }
}
