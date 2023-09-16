using Project.HELPERS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    internal class DataAccessLayer
    {
        public const string Connection_String = "Data Source=ACERNITRO5\\MSSQLSERVER01;Initial Catalog=Ado.NET;Integrated Security=True";

        public static async Task ExecuteNonQueryAsync(string command)
        {
            ThrowIfNullOrEmpty(command);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        int affectedRows = await sqlCommand.ExecuteNonQueryAsync();

                        ConsoleHelper.WriteSuccess($"Number of affected rows: {affectedRows}");
                        Console.WriteLine(affectedRows);
                    }
                }

            }
            catch (SqlException ex)
            {
                ConsoleHelper.WriteLineError($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLineError($"Something went wrong: {ex.Message}.");
            }
        }

        public static async Task<T> ExecuteQueryAsync<T>(string command, Func<SqlDataReader, T> converter)
        {
            ThrowIfNullOrEmpty(command);
            try
            {
                Console.WriteLine("salom");
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {

                     connection.Open();
                     Console.WriteLine("hello");

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        Console.WriteLine("io");
                        var dataReader = await sqlCommand.ExecuteReaderAsync();
                        Console.WriteLine("keldi");
                        return converter( dataReader);
                    }
                }
            }
            catch (SqlException ex)
            {
                ConsoleHelper.WriteLineError($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLineError($"Something went wrong: {ex.Message}.");
            }

            return default;
        }

        private static void ThrowIfNullOrEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }
        }
    }
}
