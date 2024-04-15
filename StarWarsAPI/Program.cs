using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

ConsoleUserInteraction consoleUserInteraction = new();

try
{
    await new StarWarsAPI(
    consoleUserInteraction,
    new ApiDataReader()).Start();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

consoleUserInteraction.End();
public class StarWarsAPI
{
    private readonly IUserInteraction _userInteraction;
    private readonly IApiDataReader _apiDataReader;

    private readonly string _baseAddress = "https://swapi.dev/api/";

    private string _requestUri { get; set; }

    public StarWarsAPI(IUserInteraction userInteraction, IApiDataReader apiDataReader)
    {

        _userInteraction = userInteraction;
        _apiDataReader = apiDataReader;
        _requestUri = "planets/";

    }
    public async Task Start()
    {
        // make request to API
        var json = await _apiDataReader.Read(_baseAddress, _requestUri);
        var root = JsonSerializer.Deserialize<Root>(json);

        // send data to display
        _userInteraction.DisplayData(root);
        _userInteraction.Analyze(root);

    }

}

public interface IUserInteraction
{
    void End();
    void DisplayData(Root? root);
    void Analyze(Root? root);
}
public class ConsoleUserInteraction : IUserInteraction
{

    public void DisplayData(Root? root)
    {
        if (root == null)
            throw new ArgumentNullException(nameof(root));

        var line = "+-----------------------------------------------------------------------+";
        var tableHeader = string.Format("| {0,-15} | {1,-15} | {2,-15} | {3,-15} |", "Name", "Population", "Diameter", "Surface Water");
        Console.WriteLine($"{line}\n{tableHeader}\n{line}");

        var tableRows = root.results
            .Select(row =>
            string.Format("| {0,-15} | {1,-15} | {2,-15} | {3,-15} |",
                row.name, row.population, row.diameter, row.surface_water));

        Console.WriteLine(string.Join("\n", tableRows));
        Console.WriteLine(line + "\n");

    }
    public void End()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
    public void Analyze(Root? root)
    {
        if (root == null)
            throw new ArgumentNullException(nameof(root));

        Console.WriteLine("Select the statistics you are interested in:\n" +
            "population\ndiameter\nsurface water");
        var userInput = Console.ReadLine();

        Func<Result, string> getPropertyFunc;

        switch (userInput)
        {
            case "population":
                getPropertyFunc = result => result.population;
                break;
            case "diameter":
                getPropertyFunc = result => result.diameter;
                break;
            case "surface_water":
                getPropertyFunc = result => result.surface_water;
                break;
            default:
                throw new ArgumentException("Invalid user input");
        }

        GetMinMax(root.results.ToList(), getPropertyFunc, userInput);

    }
    public void GetMinMax(List<Result> results, Func<Result, string> getPropertyFunc, string userInput)
    {
        var populations = results
        .Select(row => int.TryParse(getPropertyFunc(row), out int pop) ? (int?)pop : null)
        .Where(pop => pop.HasValue)
        .ToList();

        int? max = populations.Max();
        int? min = populations.Min();

        Console.WriteLine($"Max {userInput} is {max}");
        Console.WriteLine($"Min {userInput} is {min}");
    }

}

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}
public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(requestUri);
        return await response.Content.ReadAsStringAsync();
    }
}




public record Result(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("rotation_period")] string rotation_period,
    [property: JsonPropertyName("orbital_period")] string orbital_period,
    [property: JsonPropertyName("diameter")] string diameter,
    [property: JsonPropertyName("climate")] string climate,
    [property: JsonPropertyName("gravity")] string gravity,
    [property: JsonPropertyName("terrain")] string terrain,
    [property: JsonPropertyName("surface_water")] string surface_water,
    [property: JsonPropertyName("population")] string population,
    [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
    [property: JsonPropertyName("films")] IReadOnlyList<string> films,
    [property: JsonPropertyName("created")] DateTime created,
    [property: JsonPropertyName("edited")] DateTime edited,
    [property: JsonPropertyName("url")] string url
);

public record Root(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] object previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Result> results
);

/*
 try
        {
            int? max;
            int? min;
            if (userInput == "population")
            {

                var populations = root.results
                    .Select(row => int.TryParse(row.population, out int pop) ? pop : (int?)null)
                    .Where(pop => pop.HasValue)
                    .ToList();

                max = populations.Max();
                min = populations.Min();
            }
            else if( userInput == "diameter")
            {
                var populations = root.results
                    .Select(row => int.TryParse(row.diameter, out int pop) ? pop : (int?)null)
                    .Where(pop => pop.HasValue)
                    .ToList();

                max = populations.Max();
                min = populations.Min();
            }
            else
            {
                var populations = root.results
                    .Select(row => int.TryParse(row.surface_water, out int pop) ? pop : (int?)null)
                    .Where(pop => pop.HasValue)
                    .ToList();

                max = populations.Max();
                min = populations.Min();
                
            }

            Console.WriteLine($"Max {userInput} is {max}");
            Console.WriteLine($"Min {userInput} is {min}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not verify input.");
        }

 */