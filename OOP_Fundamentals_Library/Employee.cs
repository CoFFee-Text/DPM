using _1laba;

namespace OOP_Fundamentals_Library
{
    public class Employee: BaseEmployee
    {
        private string _position;

        public string Position
        {
            get => _position;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Position can't be empty");
                _position = value;
            }
        }

        public override decimal CalculateBonus()
        {
            return Salary * 0.1m;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Employee: {Name}, {Age} years old");
        }
        public override void PrintReportInfo()
        {
            Console.WriteLine("Employee Report:");
            Console.WriteLine($" Name: {Name}");
            Console.WriteLine($" Age: {Age}");
            Console.WriteLine($" Salary: {Salary}");
        }
    }
    
}

