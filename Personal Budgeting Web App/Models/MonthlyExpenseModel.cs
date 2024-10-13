namespace Personal_Budgeting_Web_App.Models
{
    public class MonthlyExpenseModel
    {
        public DateTime Date { get; set; }
        public List<ExpenseModel> Expenses { get; set; }
        public decimal TotalMonthlyExpenses { get; set; }

        public MonthlyExpenseModel(DateTime date, List<ExpenseModel> expenses)
        {
            Date = date;
            Expenses = expenses;
            TotalMonthlyExpenses = expenses.Sum(expense => expense.Price);
        }
    }
}
