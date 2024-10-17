using Personal_Budgeting_Web_App.Models;
using System.Data.SqlClient;

namespace Personal_Budgeting_Web_App.Services
{
    public class ExpenseDAO : IExpenseDatabase
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=budgetingdb;";

        /// <summary>
        /// Adds the given ExpenseModel to the SQL Database
        /// Does not check for duplicates and ignores given ID
        /// </summary>
        /// <param name="expense">The ExpenseModel to add to the SQL Database</param>
        /// <returns>True if an entry was added to the database</returns>
        public bool AddExpense(ExpenseModel expense)
        {
            Console.WriteLine($"Adding expense ({expense}) to db...");
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
            Console.WriteLine(success ? "Successfully added expense to db..." : "Failed to add expense to db, is the server running?");

            return success;
        }

        /// <summary>
        /// Deletes the given ExpenseModel from the SQL Database by ID
        /// Matches the ID of the ExpenseModel to an entry in the database
        /// </summary>
        /// <param name="expense">The ExpenseModel containing the ID of the entry to delete from the database</param>
        /// <returns>True if an entry was found and removed from the database</returns>
        public bool DeleteExpense(ExpenseModel expense)
        {
            Console.WriteLine($"Deleting expense (ID: {expense.ID}) from db...");
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

            Console.WriteLine(success ? "Successfully deleted expense from db..." : "Did not find matching expense to delete from db...");

            return success;
        }

        /// <summary>
        /// Returns all expenses from the database
        /// </summary>
        /// <returns>A List of ExpenseModel containing all expenses in the database</returns>
        public List<ExpenseModel> GetAllExpenses()
        {
            Console.WriteLine("Retrieving all expenses from db...");
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

            Console.WriteLine($"Retrieved {expenseList.Count} expense{(expenseList.Count != 1 ? "s" : "")}");

            return expenseList;
        }

        /// <summary>
        /// Returns a filtered list of expenses from the database
        /// </summary>
        /// <param name="startDate">The earliest date, can be null</param>
        /// <param name="endDate">The latest date, can be null</param>
        /// <param name="category">The category of the item, can be null</param>
        /// <param name="startPrice">The lowest value, can be null</param>
        /// <param name="endPrice">The highest value, can be null</param>
        /// <param name="name">Search for names containing this value, can be null</param>
        /// <returns>A List of ExpenseModel containing expenses from the database matching the filters</returns>
        public List<ExpenseModel> GetExpenses(DateTime? startDate, DateTime? endDate, string? category, decimal? startPrice, decimal? endPrice, string? name)
        {
            Console.WriteLine($"Retrieving filtered expenses from db...");
            Console.WriteLine($"Date: {(startDate.HasValue ? startDate.Value : "Any")} to {(endDate.HasValue ? endDate.Value : "Any")}");
            Console.WriteLine($"Category: {category ?? "Any"}");
            Console.WriteLine($"Price: {(startPrice.HasValue ? startPrice.Value : "Any")} to {(endPrice.HasValue ? endPrice.Value : "Any")}");
            Console.WriteLine($"Name: {name ?? "Any"}");
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

            Console.WriteLine($"Retrieved {expenseList.Count} expense{(expenseList.Count != 1 ? "s" : "")}");

            return expenseList;
        }

        /// <summary>
        /// Updates the given ExpenseModel in the SQL Database by ID
        /// </summary>
        /// <param name="expense">The ExpenseModel containing the matching ID and updated information to update in the database</param>
        /// <returns>True if an entry was found and updated in the database</returns>
        public bool UpdateExpense(ExpenseModel expense)
        {
            Console.WriteLine($"Updating expense ({expense}) in db...");
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
            Console.WriteLine(success ? "Successfully update expense in db..." : "Did not find matching expense to update in db...");

            return success;
        }

    }
}
