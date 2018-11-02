namespace PersonsInfo
{
    public class Person
    {
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
            set { firstName = value; }
        }
      
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
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
