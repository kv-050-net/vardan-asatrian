using System;

namespace BaseOOPCompany
{
    public abstract class Employee
    {
        private string firstName;

        private string secondName;

        private int experience;

        private decimal salary;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Name can't be empty!");
                }

                firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Second Name can't be empty!");
                }

                secondName = value;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Experience can't be negative number!");
                }

                experience = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary can't be negative number!");
                }

                salary = value;
            }
        }

        public Manager Manager { get; set; }

        public Employee(string firstName, string secondName, decimal salary, int experience, Manager manager = null)
        {
            FirstName = firstName;
            SecondName = secondName;
            Experience = experience;
            Salary = salary;
            Manager = manager;
        }

        public override string ToString()
        {
            if (Manager != null)
            {
                return $"{FirstName} {SecondName}, manager: {Manager.SecondName}, experience: {Experience}";
            }

            return $"{FirstName} {SecondName}, manager: none, experience: {Experience}";
        }
    }
}
