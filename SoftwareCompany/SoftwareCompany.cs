// Print the EmployeeID, FirstName, and all projects of employee with id 24. If the project has started during or after 2005, print that it's name is null.
// Must connect with the database first.
using System.Data.SqlClient;

public class Program
{
    static void Main()
    {
        // Create connection string using the data we connected with (try localhost instead of (LocalDb)/MSSQLLocalDB)
        string conString = @"Server=(LocalDb)\MSSQLLocalDB;Database=SoftwareCompany;Trusted_Connection=True";


        string query = @"
                SELECT Employees.EmployeeID, FirstName,
                CASE
                    WHEN Projects.StartDate >= '2005' THEN
                        NULL
                    ELSE 
                        Projects.Name
                END AS 'Project Name'
                FROM Employees
                JOIN EmployeesProjects ON Employees.EmployeeID = EmployeesProjects.EmployeeID
                JOIN Projects ON EmployeesProjects.ProjectID = Projects.ProjectID
                WHERE Employees.EmployeeID = 24;
            ";

        // Use a new connection made of the connection string.
        using (SqlConnection connection = new SqlConnection(conString))
        {
            // Create a new SQL Command using the query string.
            SqlCommand cmd = new SqlCommand(query, connection);

            // Open the connection
            connection.Open();

            // Create a new reader and use it to print everything in our database.
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Reader returns array for each row in the tables.
                while (reader.Read())
                {
                    if (reader[2].ToString().Length == 0)
                    {
                        Console.WriteLine("{0} | {1} | NULL", reader[0], reader[1]);
                    }
                    else
                    {
                        Console.WriteLine("{0} | {1} | {2}", reader[0], reader[1], reader[2]);
                    }
                }
            }
        }
    }
}