using System;
using System.Text;

public abstract class Harvester : Worker
{
    private const string ERROR_MESSAGE = "Harvester is not registered, because of it's {0}";
    private const int energyRequiermentMaxValue = 20000;

    private double oreOutput;

    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(OreOutput)));
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > energyRequiermentMaxValue)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE,nameof(EnergyRequirement)));
            }
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var type = this.GetType().Name;

        var sb = new StringBuilder();
        sb
            .AppendLine($"{type} - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }

}

