// A CEO of a small company has asked you to create an application that allows him to input employees and the following data about them:
// Name, salary, job, department, e-mail address (optional), and age (optional). 
// The application must show him which department has the highest average salary and what it is and list the employees working in it after sorting them based on their salary.
// If the e-mail is missing, it must print "N/A". If the age is missing, it must not print anything.
// Round up the average salary to two digits after the floating point.

using System.Text.RegularExpressions;

class Employee
{
    // Required.
    public string Name;
    public float Salary;
    public string Job;
    public string Department;

    // Optional.
    public string Email;
    public byte? Age;
}

class Department
{
    public string Name;
    public byte EmployeeCount = 1;
    public float TotalSalary = 0;

    // A constructor to add the salary of the first employee.
    public Department(float firstEmployeeSalary)
    {
        TotalSalary = firstEmployeeSalary;
    }
}

class Program
{
    static void Main ()
    {
        // Prompt the user to input the employees' count.
        Console.Write("How many employees are there?\n");
        byte count = Byte.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();
        string[] input;

        Dictionary <string, Department> departments = new Dictionary<string, Department> ();

        // Show the user how to input data for each employee.
        Console.WriteLine("Employee [X]: Name, Salary, Job, Department, E-mail (Optional), Age (Optional)");
        for (byte i = 0; i < count; i++)
        {
            Employee currentEmployee = new Employee();
            try
            {
                // Prompt the user to input each employee's data.
                Console.Write($"> Employee [{i}]: ");
                input = Regex.Split(Console.ReadLine(), ", ");

                currentEmployee.Name = input[0];
                currentEmployee.Salary = Single.Parse(input[1]);
                currentEmployee.Job = input[2];
                currentEmployee.Department = input[3];

                // Update the departments dictionary.
                if (departments.ContainsKey(currentEmployee.Department))
                {
                    departments[currentEmployee.Department].EmployeeCount += 1;
                    departments[currentEmployee.Department].TotalSalary += currentEmployee.Salary;
                }
                else
                {
                    departments.Add(currentEmployee.Department, new Department(currentEmployee.Salary));
                }

                // Check if the user inputted the optional fields and whether they are inputted properly.
                if (input.Length > 4)
                {
                    if (Regex.IsMatch(input[4], @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    {
                        currentEmployee.Email = input[4];
                    }
                    else
                    {
                        // Return error if the email is not formatted properly.
                        throw new FormatException();
                    }

                    // Check if the user inputted the optional age or only the e-mail.
                    if (input.Length > 5)
                    {
                        currentEmployee.Age = Byte.Parse(input[5]);
                    }
                }
                else
                {
                    // If the user did not input an email, set it to N/A.
                    currentEmployee.Email = "N/A";
                }

                employees.Add(currentEmployee);
            }
            catch (Exception)
            {
                Console.WriteLine("You did not input the employee's required data correctly! Please follow the format.");
                // Repeat the iteration.
                i--;
            }
        }

        // Order employees by salary.
        employees.OrderByDescending(x => x.Salary);

        // Find the department with the highest average salary.
        Department? highestSalary = null;
        foreach (KeyValuePair<string, Department> dep in departments)
        {
            if (highestSalary == null || (float)(dep.Value.TotalSalary / dep.Value.EmployeeCount) > (float)(highestSalary.TotalSalary / highestSalary.EmployeeCount))
            {
                highestSalary = dep.Value;
                highestSalary.Name = dep.Key;
            }
        }

        Console.WriteLine($"\nHighest Average Salary: {highestSalary.Name} ({Math.Round( (float)(highestSalary.TotalSalary / highestSalary.EmployeeCount), 2)}$)");

        // Print all employees in this department.
        foreach (Employee employee in employees)
        {
            if (employee.Department == highestSalary.Name)
            {
                Console.Write($"{employee.Name}, {employee.Salary}, {employee.Job}, {employee.Department}, {employee.Email}, ");
                Console.WriteLine(employee.Age == null ? "" : employee.Age);
            }
        }
    }
}
