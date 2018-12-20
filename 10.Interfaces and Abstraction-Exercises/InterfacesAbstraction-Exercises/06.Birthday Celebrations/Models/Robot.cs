using _06.Birthday_Celebrations.Contracts;

namespace _06.Birthday_Celebrations.Models
{
    public class Robot : IInhabitant
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}
