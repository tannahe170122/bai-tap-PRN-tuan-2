
// IEmployee.cs
public interface IEmployee
{
    int CalculateSalary();
    string GetName();
}

// Employee.cs
public abstract class Employee : IEmployee
{
    protected string name;
    protected int paymentPerHour;

    public Employee(string name, int paymentPerHour)
    {
        this.name = name;
        this.paymentPerHour = paymentPerHour;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetPaymentPerHour(int paymentPerHour)
    {
        this.paymentPerHour = paymentPerHour;
    }

    public int GetPaymentPerHour()
    {
        return paymentPerHour;
    }

    public abstract int CalculateSalary();

    public override string ToString()
    {
        return $"Employee{{name='{name}', paymentPerHour={paymentPerHour}}}";
    }
}

// PartTimeEmployee.cs
public class PartTimeEmployee : Employee
{
    private int workingHours;

    public PartTimeEmployee(string name, int paymentPerHour, int workingHours) : base(name, paymentPerHour)
    {
        this.workingHours = workingHours;
    }

    public override int CalculateSalary()
    {
        return workingHours * paymentPerHour;
    }

    public override string ToString()
    {
        return $"PartTimeEmployee{{name='{name}', paymentPerHour={paymentPerHour}, workingHours={workingHours}, salary={CalculateSalary()}}}";
    }
}

// FullTimeEmployee.cs
public class FullTimeEmployee : Employee
{
    public FullTimeEmployee(string name, int paymentPerHour) : base(name, paymentPerHour)
    {
    }

    public override int CalculateSalary()
    {
        return 8 * paymentPerHour;
    }

    public override string ToString()
    {
        return $"FullTimeEmployee{{name='{name}', paymentPerHour={paymentPerHour}, salary={CalculateSalary()}}}";
    }
}

// Main.cs
public class MainClass
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add FullTimeEmployee");
            Console.WriteLine("2. Add PartTimeEmployee");
            Console.WriteLine("3. Find Employee with highest salary");
            Console.WriteLine("4. Find Employee by name");
            Console.WriteLine("5. Exit");

            int choice = 0;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter payment per hour:");
                        int paymentPerHour = int.Parse(Console.ReadLine());
                        employees.Add(new FullTimeEmployee(name, paymentPerHour));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input, please enter valid numbers.");
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter payment per hour:");
                        int paymentPerHour = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter working hours:");
                        int workingHours = int.Parse(Console.ReadLine());
                        employees.Add(new PartTimeEmployee(name, paymentPerHour, workingHours));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input, please enter valid numbers.");
                    }
                    break;
                case 3:
                    Employee highestSalaryEmployee = null;
                    foreach (Employee employee in employees)
                    {
                        if (highestSalaryEmployee == null || employee.CalculateSalary() > highestSalaryEmployee.CalculateSalary())
                        {
                            highestSalaryEmployee = employee;
                        }
                    }
                    if (highestSalaryEmployee != null)
                    {
                        Console.WriteLine("Employee with highest salary: " + highestSalaryEmployee);
                    }
                    else
                    {
                        Console.WriteLine("No employees found.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter name to search:");
                    string searchName = Console.ReadLine();
                    bool found = false;
                    foreach (Employee employee in employees)
                    {
                        if (employee.GetName().Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Employee found: " + employee);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Employee not found.");
                    }
                    break;
                case 5:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
