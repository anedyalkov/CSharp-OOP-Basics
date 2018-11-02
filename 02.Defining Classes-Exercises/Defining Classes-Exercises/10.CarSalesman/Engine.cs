using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model,int power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine(Displacement == 0 ? $@"    Displacement: n/a" : $"    Displacement: {Displacement}");
            sb.AppendLine(Efficiency ==  null ? $@"    Efficiency: n/a" : $"    Efficiency: {Efficiency}");
            return sb.ToString().Trim();

        }
    }
}