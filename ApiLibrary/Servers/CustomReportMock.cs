namespace CustomReportLibrary
{
    public class CustomReportMock : ICustomReportService
    {
        private int averageTime;
        private int maxRequest;
        private int currentTaskNumber;
        public int CurrentTaskNumber => currentTaskNumber;

        public CustomReportMock(int averageTime, int maxRequest)
        {
            this.averageTime = averageTime;
            this.maxRequest = maxRequest;
        }

        public async Task<ResponseContent> CustomReportPostAsync(RequestContent content)
        {
            if (Interlocked.Increment(ref currentTaskNumber) > maxRequest)
            {
                Interlocked.Decrement(ref currentTaskNumber);
                throw new InvalidOperationException("Exceed the maximum request!");
            }
            await Task.Delay(averageTime);
            Interlocked.Decrement(ref currentTaskNumber);
            return new ResponseContent { IsCompleted = true, IsFaulted = false, Signature = "10.146", Exception = "", Result = "AAAAAAAAAAAA" };
        }
    }
}
