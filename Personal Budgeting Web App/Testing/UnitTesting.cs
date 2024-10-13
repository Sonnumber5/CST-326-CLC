using Personal_Budgeting_Web_App.Models;
using Personal_Budgeting_Web_App.Services;
using System.Diagnostics;

namespace Personal_Budgeting_Web_App.Testing
{
    public class UnitTesting
    {
        static ExpenseRepo expenseRepo = new ExpenseRepo();

        public TestResultModel TestExpenseDAO()
        {
            TestResultModel result = new TestResultModel();
            ExpenseModel expense = new ExpenseModel { Name = "Test 1", Price = 1.5m, Category = "Test Category", Date = DateTime.Now, Description = "Just a test" };
            List<ExpenseModel> expenseList;
            bool foundInAllList;

            try
            {
                // Add test
                if (expenseRepo.AddExpense(expense))
                    result.SuccessfulTests.Add("Added new expense to repo");
                else
                    result.FailedTests.Add("Failed to add new expense to repo");
            }
            catch (Exception ex)
            {
                result.FailedTests.Add(ex.Message);
            }

            try
            {
                // Read (from all) test
                foundInAllList = false;
                expenseList = expenseRepo.GetAllExpenses();
                foreach (ExpenseModel expenseModel in expenseList)
                    if (expenseModel.Name == expense.Name &&
                        expenseModel.Price == expense.Price &&
                        expenseModel.Category == expense.Category &&
                        expenseModel.Description == expense.Description)
                    {
                        foundInAllList = true;
                        expense.ID = expenseModel.ID;
                        break;
                    }
                if (foundInAllList)
                    result.SuccessfulTests.Add("Found new expense in list of all expenses");
                else
                    result.FailedTests.Add("Failed to find new expense in list of all expenses");
            }
            catch (Exception ex)
            {
                result.FailedTests.Add(ex.Message);
            }

            try
            {
                // Read (filtered) test
                expenseList = expenseRepo.GetExpenses(expense.Date.AddSeconds(-5), expense.Date.AddSeconds(5), expense.Category, expense.Price - 0.05m, expense.Price + 0.05m, expense.Name.Substring(1, expense.Name.Length - 2));
                foundInAllList = false;
                foreach (ExpenseModel expenseModel in expenseList)
                    if (expenseModel.Name == expense.Name &&
                        expenseModel.Price == expense.Price &&
                        expenseModel.Category == expense.Category &&
                        expenseModel.Description == expense.Description)
                    {
                        foundInAllList = true;
                        expense.ID = expenseModel.ID;
                        break;
                    }
                if (foundInAllList)
                    result.SuccessfulTests.Add("Found new expense in filtered expenses");
                else
                    result.FailedTests.Add("Failed to find new expense in filtered expenses");
            }
            catch (Exception ex)
            {
                result.FailedTests.Add(ex.Message);
            }

            try
            {
                // Update test
                Console.WriteLine("Updating in Unit Testing.");
                expense.Description = "Updated description";
                if (expenseRepo.UpdateExpense(expense))
                    result.SuccessfulTests.Add("Updated expense successfully"); 
                else
                    result.FailedTests.Add("Failed to update expense");
            }
            catch (Exception ex)
            {
                result.FailedTests.Add(ex.Message);
            }

            try
            {
                // Delete test
                if (expenseRepo.DeleteExpense(expense))
                    result.SuccessfulTests.Add("Deleted new expense from repo");
                else
                    result.FailedTests.Add("Failed to delete new expense from repo");
            }
            catch (Exception ex)
            {
                result.FailedTests.Add(ex.Message);
            }

            return result;
        }

        public TestResultModel TestAddExpenses()
        {
            TestResultModel result = new TestResultModel();
            Random rnd = new Random();

            int count = 0;

            for (int i = 1; i <= 25; i++)
            {
                if (expenseRepo.AddExpense(new ExpenseModel
                {
                    Category = "!Test!",
                    Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, rnd.Next(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) + 1, rnd.Next(24), rnd.Next(60), rnd.Next(60)),
                    Name = $"Test Expense {i}",
                    Price = (decimal)(rnd.Next(1000) + rnd.NextDouble() + 1),
                    Description = "A randomly generated expense for testing purposes!"
                }))
                    count++;
            }

            if (count > 0)
                result.SuccessfulTests.Add($"Added {count} random expenses to the database for this month");
            else
                result.FailedTests.Add("Failed to add any expenses to the database");

            return result;
        }

        public TestResultModel RemoveTestExpenses()
        {
            TestResultModel result = new TestResultModel();

            List<ExpenseModel> expenseModels = expenseRepo.GetExpenses(null, null, "!Test!");

            int count = 0;

            foreach (ExpenseModel expense in expenseModels)
            {
                if (expenseRepo.DeleteExpense(expense))
                    count++;
            }

            if (count > 0)
                result.SuccessfulTests.Add($"Removed {count} test expenses from the database");
            else if (expenseModels.Count > 0)
                result.FailedTests.Add($"Failed to remove {expenseModels.Count} test expenses from the database");
            else
                result.FailedTests.Add("Failed to find test expenses to remove from the database. There may be none to find.");

            return result;
        }
    }
}
