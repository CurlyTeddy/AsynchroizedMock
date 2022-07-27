using ApiLibrary;
using Newtonsoft.Json;

namespace ApiUser
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            CustomReportServices user = new CustomReportServices("http://192.168.10.146:5000/api/CustomReport");
            RequestContent request = new RequestContent
            {
                Dtno = 0,
                Ftno = 0,
                Params = "string",
                AssignSpid = "string",
                KeyMap = "string"
            };
            ResponseContent content = await user.CustomReportPostAsync(request);
            Console.WriteLine(JsonConvert.SerializeObject(content));
            Console.ReadLine();
        }
    }
}