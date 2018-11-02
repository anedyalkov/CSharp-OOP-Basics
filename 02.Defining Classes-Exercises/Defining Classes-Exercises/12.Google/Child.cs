namespace DefiningClasses
{
    public class Child
    {
        public Child(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}