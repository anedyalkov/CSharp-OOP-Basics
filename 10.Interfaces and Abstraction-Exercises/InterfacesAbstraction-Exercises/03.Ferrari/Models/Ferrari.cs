using _03.Ferrari.Contracts;

namespace _03.Ferrari.Models
{
    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            Driver = driverName;
            Model = "488-Spider";
        }
        public string Driver { get; set; }
        public string Model { get; set; }

        public string PushTheGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public  string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{Model}/{UseBrakes()}/{PushTheGasPedal()}/{Driver}";
        }
    }
}
