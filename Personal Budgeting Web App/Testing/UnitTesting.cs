using Personal_Budgeting_Web_App.Models;
using Personal_Budgeting_Web_App.Services;

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
    }
}
