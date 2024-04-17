using StarWarsApi2.DTOs;
using StarWarsPlanetsStats.ApiDataAccess;
using System.Text.Json;

public class PlanetsFromApiReader : IPlanetReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _fallbackDataReader;

    public PlanetsFromApiReader(IApiDataReader first,
        IApiDataReader second)
    {
        _apiDataReader = first;
        _fallbackDataReader = second;
    }
    public async Task<IEnumerable<Planet>> Read()
    {
        string? json = null;

        try
        {
            json = await _apiDataReader.Read(
                "https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API request was unsuccessful." +
                "Exceptiuon message: " + ex.Message);
        }
        json ??= await _fallbackDataReader.Read(
                "https://swapi.dev/", "api/planets");
        var root = JsonSerializer.Deserialize<Root>(json);
        return ToPlanets(root);
    }
    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
            throw new ArgumentNullException(nameof(root));

        var planets = new List<Planet>();

        return root.results.Select(
            planetDto => (Planet)planetDto);
    }
}