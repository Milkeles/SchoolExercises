// Console App to connect with SQL Server Database
// View -> Server Explorer (Ctrl + Alt + S)
// DataConnections (RMB) -> Add Connection -> Server Name (LocalDb)\MSSQLLocalDB -> Database Name -> OK

//Be sure you have System.Data.SqlClient installed (Project -> Manage NuGet Packages)
using System;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static void Main()
    {
        // Create connection string using the data we connected with (try localhost instead of (LocalDb)/MSSQLLocalDB)
        string conString = @"Server=(LocalDb)\MSSQLLocalDB;Database=TestDatabase;Trusted_Connection=True";

        // Optionally create our query command.
        string query = "SELECT FirstName, LastName, English, Math, ComputerScience  FROM Students JOIN Grades ON Students.Id = Grades.StudentId";

        // Use a new connection made of the connection string.
        using (SqlConnection connection = new SqlConnection(conString))
        {
            // Create a new SQL Command using the query string.
            SqlCommand cmd = new SqlCommand(query, connection);

            // Open the connection
            connection.Open();

            // Check the status of our connection.
            Console.WriteLine("State: {0}", connection.State);

            // Create a new reader and use it to print everything in our database.
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Reader returns array for each row in the tables.
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
            }
        }
        Console.WriteLine("Success!");
    }
}



