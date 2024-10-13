using Personal_Budgeting_Web_App.Models;
using System.Data.SqlClient;

namespace Personal_Budgeting_Web_App.Services
{
    public class ExpenseDAO : IExpenseDatabase
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=budgetingdb;";

        public bool AddExpense(ExpenseModel expense)
        {
            Console.WriteLine("Adding expense to db...");
            bool success = false;

            string sqlStatement = $"INSERT INTO dbo.expenses (name, price, category, date, description) VALUES (@name, @price, @category, @date, @description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 45).Value = expense.Name;
                    command.Parameters.Add("@price", System.Data.SqlDbType.Decimal, 18).Value = expense.Price;
                    command.Parameters.Add("@category", System.Data.SqlDbType.NVarChar, 45).Value = expense.Category;
                    command.Parameters.Add("@date", System.Data.SqlDbType.DateTime, 45).Value = expense.Date;
                    command.Parameters.Add("@description", System.Data.SqlDbType.NVarChar, 1024).Value = expense.Description;

                    success = command.ExecuteNonQuery() > 0;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

        public bool DeleteExpense(ExpenseModel expense)
        {
            Console.WriteLine("Deleting expense from db...");
            if (expense.ID <= 0) return false;

            bool success = false;

            string sqlStatement = $"DELETE FROM dbo.expenses WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = expense.ID;

                    success = command.ExecuteNonQuery() > 0;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

        public List<ExpenseModel> GetAllExpenses()
        {
            Console.WriteLine("Retrieving expenses from db...");
            List<ExpenseModel> expenseList = new List<ExpenseModel>();

            string sqlStatement = $"SELECT * FROM dbo.expenses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //name, price, category, date, description
                        ExpenseModel expense = new ExpenseModel
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Category = reader.GetString(3),
                            Date = reader.GetDateTime(4),
                            Description = reader.GetString(5)
                        };
                        expenseList.Add(expense);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return expenseList;
        }

        public List<ExpenseModel> GetExpenses(DateTime? startDate, DateTime? endDate, string? category, decimal? startPrice, decimal? endPrice, string? name)
        {
            Console.WriteLine("Retrieving expenses from db...");
            List<ExpenseModel> expenseList = new List<ExpenseModel>();

            string sqlStatement = $"SELECT * FROM dbo.expenses";

            List<string> filters = new List<string>();
            if (startDate != null) filters.Add("date >= @startdate");
            if (endDate != null) filters.Add("date <= @enddate");
            if (category != null && category.Length > 0) filters.Add("category = @category");
            if (startPrice != null) filters.Add("price >= @startprice");
            if (endPrice != null) filters.Add("price <= @endprice");
            if (name != null && name.Length > 0) filters.Add($"name LIKE '%{name}%'");

            if (filters.Count > 0) sqlStatement += $" WHERE {String.Join(" AND ", filters)}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    if (startDate != null) command.Parameters.Add("@startdate", System.Data.SqlDbType.DateTime).Value = startDate;
                    if (endDate != null) command.Parameters.Add("@enddate", System.Data.SqlDbType.DateTime).Value = endDate;
                    if (category != null && category.Length > 0) command.Parameters.Add("@category", System.Data.SqlDbType.NVarChar, 45).Value = category;
                    if (startPrice != null) command.Parameters.Add("@startprice", System.Data.SqlDbType.Decimal, 18).Value = startPrice;
                    if (endPrice != null) command.Parameters.Add("@endprice", System.Data.SqlDbType.Decimal, 18).Value = endPrice;
                    //if (name != null && name.Length > 0) command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 45).Value = $"'%{name}%'";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //name, price, category, date, description
                        ExpenseModel expense = new ExpenseModel
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Category = reader.GetString(3),
                            Date = reader.GetDateTime(4),
                            Description = reader.GetString(5)
                        };
                        expenseList.Add(expense);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return expenseList;
        }

        public bool UpdateExpense(ExpenseModel expense)
        {
            Console.WriteLine("Updating expense in db...");
            bool success = false;

            string sqlStatement = @"UPDATE dbo.expenses 
                            SET name = @name, 
                                price = @price, 
                                category = @category, 
                                date = @date, 
                                description = @description 
                            WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlStatement, connection);

                    command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = expense.ID;
                    command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 45).Value = expense.Name;
                    command.Parameters.Add("@price", System.Data.SqlDbType.Decimal, 18).Value = expense.Price;
                    command.Parameters.Add("@category", System.Data.SqlDbType.NVarChar, 45).Value = expense.Category;
                    command.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = expense.Date;
                    command.Parameters.Add("@description", System.Data.SqlDbType.NVarChar, 1024).Value = expense.Description;

                    success = command.ExecuteNonQuery() > 0;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

    }
}
