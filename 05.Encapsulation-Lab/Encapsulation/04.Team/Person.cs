namespace PersonsInfo
{
    using System;

    public class Person
    {
        const decimal MinSalary = 460;
        const int MinLength = 3;
        const string InvalidNameMessage = "{0} cannot contain fewer than {1} symbols!";
        const string InvalidAgeMessage = "Age cannot be zero or a negative integer!";
        const string InvalidSalaryMessage = "Salary cannot be less than {0} leva!";

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
                if (IsNameValid(value, "First name"))
                {
                    firstName = value;
                }              
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
                    throw new ArgumentException(InvalidAgeMessage);
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
                    throw new ArgumentException(string.Format(InvalidSalaryMessage,MinSalary));
                }
                salary = value;
            }
        }
        public bool IsNameValid(string valueAsString, string name)
        {
            if (valueAsString?.Length < 3)
            {
                throw new ArgumentException(string.Format(InvalidNameMessage, name, MinLength));
            }
            return true;
        }
    }
}
