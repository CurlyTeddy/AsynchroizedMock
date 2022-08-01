using CustomReportLibrary;
using System.Collections;

namespace MockTest
{
    public class CustomReportServicesTest
    {
        private CustomReportService customReportServices = null!;

        [SetUp]
        public void Setup()
        {
            customReportServices = new CustomReportService("http://192.168.10.146:5000/api/CustomReport");
        }

        [Test, TestCaseSource(nameof(TestData))]
        public async void CustomReportPostAsyncTest(RequestContent request)
        {
            // Assign

            // Act
            ResponseContent response = await customReportServices.CustomReportPostAsync(request);

            // Assert
            Assert.That(response, Is.EqualTo(new ResponseContent { IsCompleted = true, IsFaulted = false, Signature = "10.146", Exception = "", Result = "AAAAAAAAAAAA" }));
        }

        public static IEnumerable TestData
        {
            get
            {
                yield return new RequestContent { Dtno = 0, Ftno = 0, Params = "string", AssignSpid = "string", KeyMap = "string" };
            }
        }
    }
}