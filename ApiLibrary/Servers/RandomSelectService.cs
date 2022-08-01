namespace CustomReportLibrary
{
    public class RandomSelectService : ICustomReportService
    {
        private readonly List<ICustomReportService> servers;
        private readonly Random random;

        public RandomSelectService(IEnumerable<ICustomReportService> servers)
        {
            this.servers = servers.ToList();
            random = new Random();
        }

        public async Task<ResponseContent> CustomReportPostAsync(RequestContent content)
        {
            return await servers.ElementAt(random.Next(0, servers.Count())).CustomReportPostAsync(content);
        }
    }
}
