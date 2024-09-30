namespace Personal_Budgeting_Web_App.Models
{
    public class TestResultModel
    {
        public List<string> FailedTests, SuccessfulTests;

        public TestResultModel()
        {
            FailedTests = new List<string>();
            SuccessfulTests = new List<string>();
        }
    }
}
