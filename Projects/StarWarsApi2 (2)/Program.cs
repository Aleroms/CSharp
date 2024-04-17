using StarWarsApi2.ApiDataAccess;
using StarWarsPlanetsStats.ApiDataAccess;
using System.Numerics;
using System.Text.Json;

try
{

    await new StarWarsPlanetsStatsApp(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader()),
        new PlanetsStatisticsAnalyzer(
            new PlanetsStatsUserInteractor(
                new ConsoleUserInteractor()))
        ).Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. " +
        "Exception message: " + ex.Message);
}


Console.WriteLine("Press any key to close.");
Console.ReadKey();
