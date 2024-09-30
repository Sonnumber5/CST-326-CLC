using Personal_Budgeting_Web_App.Models;

namespace Personal_Budgeting_Web_App.Services
{
    public class ExpenseRepo : IExpenseDatabase
    {
        static ExpenseDAO expenseDAO = new ExpenseDAO();

        public bool AddExpense(ExpenseModel expense)
        {
            return expenseDAO.AddExpense(expense);
        }

        public bool DeleteExpense(ExpenseModel expense)
        {
            return expenseDAO.DeleteExpense(expense);
        }

        public List<ExpenseModel> GetAllExpenses()
        {
            return expenseDAO.GetAllExpenses();
        }

        public List<ExpenseModel> GetExpenses(DateTime? startDate, DateTime? endDate, string? category, decimal? startPrice, decimal? endPrice, string? name)
        {
            return expenseDAO.GetExpenses(startDate, endDate, category, startPrice, endPrice, name);
        }

        public bool UpdateExpense(ExpenseModel expense)
        {
            throw new NotImplementedException();
        }
    }
}
