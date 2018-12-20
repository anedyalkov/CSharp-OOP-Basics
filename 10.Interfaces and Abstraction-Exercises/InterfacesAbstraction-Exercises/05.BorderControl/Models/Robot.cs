namespace _05.BorderControl.Models
{
    using _05.BorderControl.Contracts;

    public class Robot : IInhabitant
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }
    }
}
