namespace DefiningClasses
{
    using System.Text;

    public class Parent
    {
        public Parent(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        public string Name { get; set; }
        public string Birthday { get; set; }

    }
}