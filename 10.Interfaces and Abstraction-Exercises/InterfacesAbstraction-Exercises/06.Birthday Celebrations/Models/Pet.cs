using _06.Birthday_Celebrations.Contracts;

namespace _06.Birthday_Celebrations.Models
{
    public class Pet : IInhabitant, IBirthable
    { 
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}
