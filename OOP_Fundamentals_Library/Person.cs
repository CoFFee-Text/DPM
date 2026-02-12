using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba
{
    public abstract class Person
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name can't be empty");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentException("Incorrect age");
                _age = value;
            }
        }

        public abstract void PrintInfo();
    }
}
