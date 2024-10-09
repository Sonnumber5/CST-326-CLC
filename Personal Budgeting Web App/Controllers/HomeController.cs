using Microsoft.AspNetCore.Mvc;
using Personal_Budgeting_Web_App.Models;
using Personal_Budgeting_Web_App.Services;
using Personal_Budgeting_Web_App.Testing;
using System.Diagnostics;

namespace Personal_Budgeting_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ExpenseRepo expenseRepo = new ExpenseRepo();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                     endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);

            return View("Index", new MonthlyExpenseModel(DateTime.Now, expenseRepo.GetExpenses(startDate, endDate, null, null, null, null)));
        }


        [Route("/ExpensesByDate")]
        public IActionResult ExpensesByDate(int month, int year)
		{
			DateTime startDate = new DateTime(year, month, 1),
					 endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);

			return PartialView("ExpensesByDate", new MonthlyExpenseModel(new DateTime(year, month, 1), expenseRepo.GetExpenses(startDate, endDate, null, null, null, null)));
        }

        [Route("/AddExpense")]
        public IActionResult AddExpense()
        {
            return View("AddExpense", new ExpenseModel { Date = DateTime.Now });
        }

        public IActionResult ProcessExpense(ExpenseModel expense)
        {
            expenseRepo.AddExpense(expense);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
