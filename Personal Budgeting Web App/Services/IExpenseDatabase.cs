using Personal_Budgeting_Web_App.Models;

namespace Personal_Budgeting_Web_App.Services
{
    public interface IExpenseDatabase
    {
        bool AddExpense(ExpenseModel expense);

        List<ExpenseModel> GetAllExpenses();

        List<ExpenseModel> GetExpenses(DateTime? startDate, DateTime? endDate, string? category, decimal? startPrice, decimal? endPrice, string? name);

        bool UpdateExpense(ExpenseModel expense);

        bool DeleteExpense(ExpenseModel expense);
    }
}
