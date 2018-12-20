using System;
using System.Collections.Generic;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;

    public DraftManager()
    {
        harvesters = new Dictionary<string, Harvester>();
        providers = new Dictionary<string, Provider>();
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
            this.harvesters[newHarvester.Id] = newHarvester;

            return $"Successfully registered {typeOfHarvester} - {newHarvester.Id}";
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
            this.providers[newProvider.Id] = newProvider;

            return $"Successfully registered {typeOfProvider} - {newProvider.Id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public string Day()
    {
        return "";
    }
    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        if (mode == "Full" || mode == "Half" || mode == "Energy")
        {
            this.mode = mode;
        }
        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var searchedId = arguments[0];

        if (harvesters.ContainsKey(searchedId))
        {
            return harvesters[searchedId].ToString();
        }
        else if (providers.ContainsKey(searchedId))
        {
            return providers[searchedId].ToString();
        }
        else
        {
            return $"No element found with id - {searchedId}";
        }
    }
    public string ShutDown()
    {
        return "";
    }

}

