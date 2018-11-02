namespace DefiningClasses
{
    public class Pokemon
    {
        public Pokemon(string name,string type)
        {
            Name = name;
            Type = type;
        }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}