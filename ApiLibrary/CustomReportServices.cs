using Newtonsoft.Json;
using System.Text;

namespace ApiLibrary
{
    public class CustomReportServices
    {
        private readonly string Target;

        public CustomReportServices(string target)
        {
            Target = target;
        }

        public async Task<ResponseContent> CustomReportPostAsync(RequestContent content)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("Post"), Target)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await httpClient.SendAsync(request);
            string respondContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseContent>(respondContent);
        }
    }
}