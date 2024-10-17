using Microsoft.AspNetCore.Mvc;
using Personal_Budgeting_Web_App.Testing;

namespace Personal_Budgeting_Web_App.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View("TestHome");
        }

        [Route("/test/expensedao")]
        public IActionResult ExpenseDAO()
        {
            UnitTesting unitTesting = new UnitTesting();

            return PartialView("TestResult", unitTesting.TestRepoCRUD());
        }

        [Route("/test/addtestexpenses")]
        public IActionResult AddTestExpenses()
        {
            UnitTesting unitTesting = new UnitTesting();

            return PartialView("TestResult", unitTesting.TestAddExpenses());
        }

        [Route("/test/removetestexpenses")]
        public IActionResult RemoveTestExpenses()
        {
            UnitTesting unitTesting = new UnitTesting();

            return PartialView("TestResult", unitTesting.RemoveTestExpenses());
        }
    }
}
