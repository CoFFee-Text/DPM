using OOP_Fundamentals_Library;

internal class ProgramExample
{
    static void Main(string[] args)
    {
        var customer = new Customer
        {
            Name = "John",
            Age = 30
        };

        var employee = new Employee
        {
            Name = "Alice",
            Age = 25,
            Salary = 50000,
            Position = "Developer"
        };

        var manager = new Manager
        {
            Name = "Bob",
            Age = 40,
            Salary = 80000,
            Department = "IT"
        };

        manager.AddToTeam(employee);


        customer.PrintInfo();
        employee.PrintInfo();
        manager.PrintInfo();

        var salary = new PayrollSystem();
        salary.ProcessSalary(employee);
        salary.ProcessSalary(manager);

        employee.PrintReportInfo();
        manager.PrintReportInfo();
    }
}