public class PlanetsStatisticsAnalyzer : IPlanetsStatisticAnalyzer
{
    private readonly IPlanetsStatsUserInteractor _planetStatsUserInteractor;

    public PlanetsStatisticsAnalyzer(IPlanetsStatsUserInteractor planetStatsUserInteractor)
    {
        _planetStatsUserInteractor = planetStatsUserInteractor;
    }
    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNameToSelectorMapping =
            new Dictionary<string, Func<Planet, int?>>
            {
                ["population"] = planet => planet.Population,
                ["diameter"] = planet => planet.Diameter,
                ["surface water"] = planet => planet.SurfaceWater,
            };

        var userChoice = _planetStatsUserInteractor.
            ChooseStatisticsToBeShown(propertyNameToSelectorMapping.Keys);


        if (userChoice is null ||
            !propertyNameToSelectorMapping.ContainsKey(userChoice))
        {
            Console.WriteLine($"{userChoice} does not exist");
        }
        else
        {
            ShowStatistics(planets, userChoice,
                propertyNameToSelectorMapping[userChoice]);
        }
    }
    private static void ShowStatistics(
        IEnumerable<Planet> planets,
        string propertyName,
        Func<Planet, int?> propertySelector)
    {
        DisplayStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);

        DisplayStatistics(
            "Min",
            planets.MinBy(propertySelector),
            propertySelector,
            propertyName);


    }

    private static void DisplayStatistics(string descriptor,
        Planet selectedPlanet,
        Func<Planet, int?> propertySelector,
        string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is: " +
            $"{propertySelector(selectedPlanet)} " +
            $"planet: {selectedPlanet.Name}");
    }
}
