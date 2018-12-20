namespace _03.Mankind
{
    using System;
    using System.Text;

    public class Worker:Human
    {
        const decimal MinWeekSalary = 10;
        const int MinHours = 1;
        const int MaxHours = 12;

        private decimal weekSalary;
        private decimal workingHours;

        public Worker(string firstName, string lastName, decimal weeksalary, decimal workingHours):base(firstName,lastName)
        {
            WeekSalary = weeksalary;
            WorkingHours = workingHours;
        }

        public decimal  WeekSalary
        {
            get { return weekSalary; }
            protected set
            {
                if (value <= MinWeekSalary)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
                }
                weekSalary = value;
            }
        }

        public decimal WorkingHours
        {
            get { return workingHours; }
            protected set
            {
                if (value < MinHours || value > MaxHours)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }
                workingHours = value;
            }
        }

        private decimal GetSalaryPerHour()
        {
            return WeekSalary / (WorkingHours * 5);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Week Salary: {WeekSalary:F2}")
                .AppendLine($"Hours per day: {WorkingHours:F2}")
                .AppendLine($"Salary per hour: {GetSalaryPerHour():F2}");

            return sb.ToString();
            
        }
    }
}
