using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        harvesters = new List<Harvester>();
        providers = new List<Provider>();
        this.totalMinedOre = 0;
        this.totalStoredEnergy = 0;
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)     
    {
        var typeOfHarvester = arguments[0];
        var id = arguments[1];

        try
        {
            var newHarvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(newHarvester);

            return $"Successfully registered {typeOfHarvester} Harvester - {newHarvester.Id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public string RegisterProvider(List<string> arguments)
    {
        var typeOfProvider = arguments[0];
        var id = arguments[1];

        try
        {
            var newProvider = ProviderFactory.CreateProvider(arguments);
            this.providers.Add(newProvider);

            return $"Successfully registered {typeOfProvider} Provider - {newProvider.Id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public string Day()
    {
        var dailyStoredEnergy = providers.Sum(p => p.EnergyOutput);
        var dailyRequirementEnergy = harvesters.Sum(h => h.EnergyRequirement);

        totalStoredEnergy += dailyStoredEnergy;

        var dailyMinedOre = 0.0;

        if (this.mode == "Full")
        {
            if (totalStoredEnergy >= dailyRequirementEnergy)
            {
                dailyMinedOre += harvesters.Sum(h => h.OreOutput);
                totalStoredEnergy -= dailyRequirementEnergy;
            }

            totalMinedOre += dailyMinedOre;
        }
        else if (this.mode == "Half")
        {
            dailyRequirementEnergy = dailyRequirementEnergy * 60 / 100;

            if (totalStoredEnergy >= dailyRequirementEnergy)
            {
                dailyMinedOre += harvesters.Sum(h => h.OreOutput) * 50 / 100;
                totalStoredEnergy -= dailyRequirementEnergy;
            }

            totalMinedOre += dailyMinedOre;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {dailyStoredEnergy}")
            .AppendLine($"Plumbus Ore Mined: {dailyMinedOre}");
        var result = sb.ToString().Trim();
        return result;
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var searchedId = arguments[0];

        var harvester = harvesters.FirstOrDefault(h => h.Id == searchedId);
        var provider = providers.FirstOrDefault(p => p.Id == searchedId);

        if (harvester != null)
        {
            return harvester.ToString();
        }
        else if (provider != null)
        {
            return provider.ToString();
        }
        else
        {
            return $"No element found with id - {searchedId}";
        }
    }
    public string ShutDown()
    {

        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: { totalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: { totalMinedOre}");
        var result = sb.ToString().Trim();
        return result;
    }

}

