namespace _01.Person
{
    using System;

    public class Person
    {
        const int MinLength = 3;
        const string NameErrorMessage = "Name's length should not be less than {0} symbols!";
        const string AgeErrorMessage = "{0} must be positive!";
        private string name;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual string Name
        {
            get { return name; }
            set
            {
                if (value.Length < MinLength)
                {
                    throw new ArgumentException(string.Format(NameErrorMessage,MinLength));
                }
                name = value;
            }
        }
        private int age;

        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(AgeErrorMessage,nameof(Age)));
                }
                age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
