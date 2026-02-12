using _1laba;

namespace OOP_Fundamentals_Library
{
    public class PayrollSystem
    {
        public void ProcessSalary(BaseEmployee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            decimal bonus = employee.CalculateBonus();
            employee.IncreaseSalary(bonus);
            Console.WriteLine($"Processed salary for {employee.Name}: {employee.Salary}");
        }
    }
}
