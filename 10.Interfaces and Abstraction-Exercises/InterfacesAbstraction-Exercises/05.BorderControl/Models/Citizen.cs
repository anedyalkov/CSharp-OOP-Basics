namespace _05.BorderControl.Models
{
    using _05.BorderControl.Contracts;

    public class Citizen : IInhabitant
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
