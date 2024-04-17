public class StarWarsPlanetsStatsApp
{

    private readonly IPlanetReader _planetsReader;
    private readonly IPlanetsStatisticAnalyzer _planetsStatisticsAnalyzer;

    public StarWarsPlanetsStatsApp(
        IPlanetReader planetsReader,
        IPlanetsStatisticAnalyzer planetsStatisticAnalyzer)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStatisticAnalyzer;
    }
    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        foreach (var planet in planets)
            Console.WriteLine(planet);

        _planetsStatisticsAnalyzer.Analyze(planets);
    }



}
