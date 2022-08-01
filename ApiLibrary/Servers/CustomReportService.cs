using Newtonsoft.Json;
using System.Text;

namespace CustomReportLibrary
{
    public class CustomReportService : ICustomReportService
    {
        private readonly string Target;

        public CustomReportService(string target)
        {
            Target = target;
        }

        public async Task<ResponseContent> CustomReportPostAsync(RequestContent content)
        {
            HttpClient httpClient = new();
            HttpRequestMessage request = new(new HttpMethod("Post"), Target)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await httpClient.SendAsync(request);
            string respondContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseContent>(respondContent)!;
        }
    }
}