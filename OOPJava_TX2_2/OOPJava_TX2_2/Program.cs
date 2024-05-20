using System;
using System.Collections.Generic;

// Abstract class Person
abstract class Person
{
    private string name;
    private string address;

    public Person(string name, string address)
    {
        this.name = name;
        this.address = address;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetAddress(string address)
    {
        this.address = address;
    }

    public string GetAddress()
    {
        return address;
    }

    public abstract void Display();
}

// Class Employee
class Employee : Person
{
    private int salary;

    public Employee(string name, string address, int salary)
        : base(name, address)
    {
        this.salary = salary;
    }

    public void SetSalary(int salary)
    {
        this.salary = salary;
    }

    public int GetSalary()
    {
        return salary;
    }

    public override void Display()
    {
        Console.WriteLine($"Employee Name: {GetName()}");
        Console.WriteLine($"Employee Address: {GetAddress()}");
        Console.WriteLine($"Employee Salary: {salary}");
    }
}

// Class Customer
class Customer : Person
{
    private int balance;

    public Customer(string name, string address, int balance)
        : base(name, address)
    {
        this.balance = balance;
    }

    public void SetBalance(int balance)
    {
        this.balance = balance;
    }

    public int GetBalance()
    {
        return balance;
    }

    public override void Display()
    {
        Console.WriteLine($"Customer Name: {GetName()}");
        Console.WriteLine($"Customer Address: {GetAddress()}");
        Console.WriteLine($"Customer Balance: {balance}");
    }
}

// Main class
class MainClass
{
    private static List<Employee> employees = new List<Employee>(); // List to manage employees
    private static List<Customer> customers = new List<Customer>(); // List to manage customers

    public static void Main(string[] args)
    {
        int choice;
        do
        {
            ShowMenu();
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    AddCustomer();
                    break;
                case 3:
                    DisplayHighestSalaryEmployee();
                    break;
                case 4:
                    DisplayLowestBalanceCustomer();
                    break;
                case 5:
                    FindEmployeeByName();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 6);
    }

    // Show menu
    private static void ShowMenu()
    {
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Add Customer");
        Console.WriteLine("3. Display Employee with Highest Salary");
        Console.WriteLine("4. Display Customer with Lowest Balance");
        Console.WriteLine("5. Find Employee by Name");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
    }

    // Add a new employee
    private static void AddEmployee()
    {
        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter salary: ");
            int salary = int.Parse(Console.ReadLine());

            employees.Add(new Employee(name, address, salary));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter correct data.");
        }
    }

    // Add a new customer
    private static void AddCustomer()
    {
        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter balance: ");
            int balance = int.Parse(Console.ReadLine());

            customers.Add(new Customer(name, address, balance));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter correct data.");
        }
    }

    // Display employee with the highest salary
    private static void DisplayHighestSalaryEmployee()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees available.");
            return;
        }

        Employee highestSalaryEmployee = employees[0];
        foreach (var employee in employees)
        {
            if (employee.GetSalary() > highestSalaryEmployee.GetSalary())
            {
                highestSalaryEmployee = employee;
            }
        }

        Console.WriteLine("Employee with the highest salary:");
        highestSalaryEmployee.Display();
    }

    // Display customer with the lowest balance
    private static void DisplayLowestBalanceCustomer()
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers available.");
            return;
        }

        Customer lowestBalanceCustomer = customers[0];
        foreach (var customer in customers)
        {
            if (customer.GetBalance() < lowestBalanceCustomer.GetBalance())
            {
                lowestBalanceCustomer = customer;
            }
        }

        Console.WriteLine("Customer with the lowest balance:");
        lowestBalanceCustomer.Display();
    }

    // Find employee by name
    private static void FindEmployeeByName()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        foreach (var employee in employees)
        {
            if (employee.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Employee found:");
                employee.Display();
                return;
            }
        }

        Console.WriteLine("Employee not found.");
    }
}
