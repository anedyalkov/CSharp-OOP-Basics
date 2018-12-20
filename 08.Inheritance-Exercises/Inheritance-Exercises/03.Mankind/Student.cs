namespace _03.Mankind
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student:Human
    {
        const string FacultyNumberError = "Invalid faculty number!";
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber):base(firstName,lastName)
        {
            FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            protected set
            {
                if (!Regex.IsMatch(value, @"^\w{5,10}$"))
                {
                    throw new ArgumentException(FacultyNumberError);
                }
                facultyNumber = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Faculty number: {FacultyNumber}");

            return sb.ToString();
        }
    }
}
