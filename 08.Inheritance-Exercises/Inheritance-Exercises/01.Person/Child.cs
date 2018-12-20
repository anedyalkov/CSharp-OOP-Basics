namespace _01.Person
{
    using System;

    public class Child:Person
    {
        const int MaxAge = 15;
        const string AgeErrorMessage = "Child's age must be less than {0}!";

        public Child(string name, int age) : base(name, age)
        {

        }

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > MaxAge)
                {
                    throw new ArgumentException(string.Format(AgeErrorMessage,MaxAge));
                }
                base.Age = value;
            }
        }

       
    }
}
