using Personal_Budgeting_Web_App.Models;

namespace Personal_Budgeting_Web_App.Services
{
    public class ExpenseRepo : IExpenseDatabase
    {
        static ExpenseDAO expenseDAO = new ExpenseDAO();

        /// <summary>
        /// Adds an expense to the SQL Database
        /// </summary>
        /// <param name="expense">The ExpenseModel to add to the dateabase</param>
        /// <returns>True if the operation succeeded</returns>
        public bool AddExpense(ExpenseModel expense)
        {
            return expenseDAO.AddExpense(expense);
        }

        /// <summary>
        /// Deletes an expense from the SQL Database
        /// Requires the ExpenseModel's id to match the id in the database
        /// </summary>
        /// <param name="expense">The ExpenseModel to delete from the database</param>
        /// <returns>True if an entry was removed</returns>
        public bool DeleteExpense(ExpenseModel expense)
        {
            return expenseDAO.DeleteExpense(expense);
        }

        /// <summary>
        /// Returns all expenses from the SQL Database
        /// </summary>
        /// <returns>List of ExpenseModel</returns>
        public List<ExpenseModel> GetAllExpenses()
        {
            return expenseDAO.GetAllExpenses().OrderBy(d => d.Date).ToList();
        }

        /// <summary>
        /// Returns filtered expenses from the SQL Database
        /// All fields are optional and can be skipped by passing null
        /// </summary>
        /// <param name="startDate">The start range of expenses by date</param>
        /// <param name="endDate">The end range of expenses by date</param>
        /// <param name="category">The category of expenses to retrieve</param>
        /// <param name="startPrice">The start range of prices</param>
        /// <param name="endPrice">The end range of prices</param>
        /// <param name="name">The name of expenses to retrieve. Filters by contained e.g. 'case' returns 'testcase1'</param>
        /// <returns></returns>
        public List<ExpenseModel> GetExpenses(DateTime? startDate = null, DateTime? endDate = null, string? category = null, decimal? startPrice = null, decimal? endPrice = null, string? name = null)
        {
            return expenseDAO.GetExpenses(startDate, endDate, category, startPrice, endPrice, name).OrderBy(d => d.Date).ToList();
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateExpense(ExpenseModel expense)
        {
            throw new NotImplementedException();
        }
    }
}
