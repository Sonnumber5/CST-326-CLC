using Microsoft.AspNetCore.Mvc;
using Personal_Budgeting_Web_App.Models;
using Personal_Budgeting_Web_App.Services;
using Personal_Budgeting_Web_App.Testing;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return View("Index", new MonthlyExpenseModel(DateTime.Now, expenseRepo.GetExpenses(DateTime.Now)));
        }

        //TODO: Add filters by other properties
        //This currently only filters by category and essential status
        public IActionResult FilterExpenses(ExpenseModel expense)
        {
            return View("Index", new MonthlyExpenseModel(DateTime.Now, expenseRepo.GetExpenses(DateTime.Now, expense.Category, null, null, null, expense.Essential)));
        }


        [Route("/ExpensesByDate")]
        public IActionResult ExpensesByDate(int month, int year)
        {
            var expenses = expenseRepo.GetExpenses(new DateTime(year, month, 1));
            var monthlyExpenses = new MonthlyExpenseModel(new DateTime(year, month, 1), expenses);

            // Calculate total expenses for the month
            //monthlyExpenses.TotalMonthlyExpenses = expenses.Sum(expense => expense.Price); // Performed in constructor given the expense list

            return PartialView("ExpensesByDate", monthlyExpenses);
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
