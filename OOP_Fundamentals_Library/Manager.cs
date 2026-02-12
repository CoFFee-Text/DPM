using _1laba;

namespace OOP_Fundamentals_Library
{
    public class Manager:BaseEmployee
    {
        private string _department;
        private List<BaseEmployee> _team = new();

        public string Department
        {
            get => _department;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Department can't be empty");
                _department = value;
            }
        }

        public IReadOnlyList<BaseEmployee> Team => _team.AsReadOnly();

        public void AddToTeam(BaseEmployee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            if (!_team.Contains(employee))
                _team.Add(employee);
        }

        public void RemoveFromTeam(BaseEmployee employee)
        {
            _team.Remove(employee);
        }

        public void AssignTaskToEmployee(BaseEmployee emp, string task)
        {
            if (emp == null)
                throw new ArgumentNullException(nameof(emp));
            if (!_team.Contains(emp))
                throw new InvalidOperationException("Employee is not in team");

            Console.WriteLine($"Assigning task '{task}' to {emp.Name}");
        }

        public override decimal CalculateBonus()
        {
            return Salary * 0.2m;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Manager: {Name}, {Age} years old, Department: {Department}");
        }
        public override void PrintReportInfo()
        {
            Console.WriteLine("Employee Report:");
            Console.WriteLine($" Name: {Name}");
            Console.WriteLine($" Department: {Department}");
            Console.WriteLine($" Team Size: {_team.Count}");
        }
    }
}
