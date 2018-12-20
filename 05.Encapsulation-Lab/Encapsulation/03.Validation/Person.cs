namespace PersonsInfo
{
    using System;

    public class Person
    {
        const decimal MinSalary = 460;
        const int MinLength = 3;
        const string NameErrorMessage = "{0} cannot contain fewer than {1} symbols!";
        const string AgeErrorMessage = "Age cannot be zero or a negative integer!";
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
                if (value.Length < MinLength)
                {
                    throw new ArgumentException(string.Format(NameErrorMessage, value,MinLength));
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
                    throw new ArgumentException(AgeErrorMessage);
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
                throw new ArgumentException(string.Format(NameErrorMessage, valueAsString,MinLength));
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
