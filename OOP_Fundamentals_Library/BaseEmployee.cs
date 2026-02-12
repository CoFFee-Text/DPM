using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba
{
    public abstract class BaseEmployee:Person
    {
        private decimal _salary;

        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary can't be below 0");
                _salary = value;
            }
        }

        public abstract decimal CalculateBonus();

        public virtual void ProcessPayroll()
        {
            Console.WriteLine($"Processing salary for {Name}: {Salary}");
        }

        public void IncreaseSalary(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Sum of salary can't be ");
            Salary += amount;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($" Salary: {Salary}");
        }

        public abstract void PrintReportInfo();
    }
}
