namespace DefiningClasses
{
    using System;
    using System.Text;

    public class Company
    {
        public Company(string name, string department, decimal salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Name} {Department} {Salary:F2}");
            return sb.ToString().Trim();
        }
    }

}