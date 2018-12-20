using System;
using System.Text;

public abstract class Provider : Worker
{
    private const string ERROR_MESSAGE = "Provider is not registered, because of it's {0}";
    private const int energyRequiermentMinValue = 10000;

    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value <= 0 || value >= energyRequiermentMinValue)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(EnergyOutput)));
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        //var type = this.GetType().Name;
        //var endIndex = type.IndexOf("Provider");
        //type = type.Substring(0, endIndex);

        var type = this.GetType().Name;

        var sb = new StringBuilder();
        sb
            .AppendLine($"{type} - {this.Id}")
            .AppendLine($"Energy Output: {this.EnergyOutput}");

        return sb.ToString().Trim();
    }

}


