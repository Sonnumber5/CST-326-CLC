namespace Personal_Budgeting_Web_App.Models
{
    public class MonthlyExpenseModel
    {
        public DateTime Date;
        public List<ExpenseModel> Expenses;

        public MonthlyExpenseModel(DateTime date, List<ExpenseModel> expenses)
        {
            Date = date;
            Expenses = expenses;
        }
    }
}
