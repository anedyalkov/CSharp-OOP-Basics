namespace PersonsInfo
{
    using System;

    public class Person
    {
        const decimal MIN_SALARY = 460;
        const int MIN_LENGTH = 3;
        const string errorMessage = "{0} cannot contain fewer than {1} symbols!";

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName, int age, decimal salary):this(firstName,lastName,age)
        {
            Salary = salary;
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length < MIN_LENGTH)
                {
                    throw new ArgumentException(string.Format(errorMessage,value,MIN_LENGTH));
                }

                firstName = value;
            }
        }
      
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (IsNameValid(value, "Last name"))
                {
                    lastName = value;
                }
            }
        }
    
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 460)
                {
                    throw new ArgumentException($"Salary cannot be less than {MIN_SALARY} leva!");
                }
                salary = value;
            }
        }
        public bool IsNameValid(string valueAsString, string name)
        {
            if (valueAsString?.Length < 3)
            {
                throw new ArgumentException(string.Format(errorMessage,valueAsString,MIN_LENGTH));
            }
            return true;
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (Age > 30)
            {
                Salary += Salary * percentage / 100;
            }
            else
            {
                Salary += Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
