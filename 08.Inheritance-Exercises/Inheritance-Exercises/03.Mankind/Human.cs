namespace _03.Mankind
{
    using System;
    using System.Text;

    public class Human
    {
        const int FIRST_NAME_MIN_LENGTH = 3;
        const int LAST_NAME_MIN_LENGTH = 2;

        protected string firstName;
        protected string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName
        {
            get { return firstName; }
            protected set
            {
                char firstNameFirstLetter = value[0];
                if (!char.IsUpper(firstNameFirstLetter))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                if (value.Length <= FIRST_NAME_MIN_LENGTH)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                firstName = value;
            }
        }
        

        public string LastName
        {
            get { return lastName; }
            protected set
            {
                char lastNameFirstLetter = value[0];
                if (!char.IsUpper(lastNameFirstLetter))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                if (value.Length <= LAST_NAME_MIN_LENGTH)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                lastName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {FirstName}")
                .Append($"Last Name: {LastName}");

            return sb.ToString();
        }
    }
}
