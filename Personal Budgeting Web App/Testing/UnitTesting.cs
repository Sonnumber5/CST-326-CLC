using Personal_Budgeting_Web_App.Models;
using Personal_Budgeting_Web_App.Services;
using System.Diagnostics;

namespace Personal_Budgeting_Web_App.Testing
{
    public class UnitTesting
    {
        static ExpenseRepo expenseRepo = new ExpenseRepo();

        /// <summary>
        /// Tests the Create Read Update Delete methods of CRUD
        /// Test 1: Users adding expenses to database
        /// Test 2: Users retrieving all expenses from the database
        /// Test 3: Users retrieving filtered expenses from the database
        /// Test 4: Users updating expenses in the database
        /// Test 5: Users deleting expenses from the database
        /// </summary>
        /// <returns>The test results of the</returns>
        public TestResultModel TestRepoCRUD()
        {
            TestResultModel result = new TestResultModel();
            ExpenseModel expense = new ExpenseModel { Name = "Test 1", Price = 1.5m, Category = "Test Category", Date = DateTime.Now, Description = "Just a test" };
            List<ExpenseModel> expenseList;
            bool foundInAllList;
            Random rnd = new Random();

            //
            // Test for Create in CRUD
            //
            try
            {
                Console.WriteLine("Creating in Unit Testing.");
                if (expenseRepo.AddExpense(expense))
                    result.SuccessfulTests.Add("Added new expense to repo");
                else
                    result.FailedTests.Add("Failed to add new expense to repo");
            }
            catch (Exception ex)
            {
                result.FailedTests.Add(ex.Message);
            }

            //
            // Test for Read in CRUD (All)
            //
            try
            {
                Console.WriteLine("Reading (all) in Unit Testing.");
                foundInAllList = false;
                expenseList = expenseRepo.GetAllExpenses();
                foreach (ExpenseModel expenseModel in expenseList)
                    if (expenseModel.Name == expense.Name &&
                        expenseModel.Price == expense.Price &&
                        expenseModel.Category == expense.Category &&
                        (expenseModel.Date.Year == expense.Date.Year && expenseModel.Date.Month == expense.Date.Month && expenseModel.Date.Day == expense.Date.Day) &&
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

            //
            // Test for Read in CRUD (Filtered)
            //
            try
            {
                Console.WriteLine("Reading (filtered) in Unit Testing.");
                expenseList = expenseRepo.GetExpenses(expense.Date.AddSeconds(-5), expense.Date.AddSeconds(5), expense.Category, expense.Price - 0.05m, expense.Price + 0.05m, expense.Name.Substring(1, expense.Name.Length - 2));
                foundInAllList = false;
                foreach (ExpenseModel expenseModel in expenseList)
                    if (expenseModel.Name == expense.Name &&
                        expenseModel.Price == expense.Price &&
                        expenseModel.Category == expense.Category &&
                        (expenseModel.Date.Year == expense.Date.Year && expenseModel.Date.Month == expense.Date.Month && expenseModel.Date.Day == expense.Date.Day) &&
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

            //
            // Test for Update in CRUD
            //
            try
            {
                // Update test
                Console.WriteLine("Updating in Unit Testing."); // Good idea to output this
                expense.Name = "Updated Name"; // Change all the values except id just to be thorough (not much else to do)
                expense.Price = 92.51m;
                expense.Category = "Updated Category";
                expense.Date = DateTime.Now.AddHours(-1.25);
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

            //
            // Test for Update (Read) in CRUD
            //
            try
            {
                Console.WriteLine("Updating (read) in Unit Testing.");
                expenseList = expenseRepo.GetExpenses(expense.Date.AddSeconds(-5), expense.Date.AddSeconds(5), expense.Category, expense.Price - 0.05m, expense.Price + 0.05m, expense.Name.Substring(1, expense.Name.Length - 2));
                foundInAllList = false;
                foreach (ExpenseModel expenseModel in expenseList)
                    if (expenseModel.ID == expense.ID &&
                        expenseModel.Name == expense.Name &&
                        expenseModel.Price == expense.Price &&
                        expenseModel.Category == expense.Category &&
                        (expenseModel.Date.Year == expense.Date.Year && expenseModel.Date.Month == expense.Date.Month && expenseModel.Date.Day == expense.Date.Day) &&
                        expenseModel.Description == expense.Description)
                    {
                        foundInAllList = true;
                        break;
                    }
                if (foundInAllList)
                    result.SuccessfulTests.Add("Confirmed update of the test expense");
                else
                    result.FailedTests.Add("Failed to confirm update of the test expense");
            }
            catch (Exception ex)
            {
                result.FailedTests.Add(ex.Message);
            }

            //
            // Test for Delete in CRUD
            //
            try
            {
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

        /// <summary>
        /// Adds 25 semi-randomized expenses to the database for this month under the category '!Test!'
        /// Can take some time with the connection being opened and closed 25 times
        /// </summary>
        /// <returns>The result of adding the expenses to the database</returns>
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

        /// <summary>
        /// Removes all test expenses from the database under the category '!Test!'
        /// </summary>
        /// <returns>The result of removing the test expenses from the database</returns>
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
