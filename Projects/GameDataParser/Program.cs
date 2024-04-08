using System.Text.Json;
var userInteraction = new ConsoleUserInteraction();
var GameApplication = new GameApplication(
    userInteraction, new JsonDataParser());

try
{
    GameApplication.Run();
}
catch (JsonDataException e)
{
    userInteraction.DisplayMessage("Sorry! The application has experienced an unexpected error and will have to be closed.");
    File.AppendAllText("log.txt", e.ToString());
}
userInteraction.Close();
public class GameApplication
{
    private IUserInteraction _userInput { get; init; }
    private IDataParser _dataParser { get; init; }

    public GameApplication(IUserInteraction userInput, IDataParser dataParser)
    {
        _userInput = userInput;
        _dataParser = dataParser;
    }
    public void Run()
    {
        var fileName = _userInput.GetFileName();

        List<GameData> data = new List<GameData>();
        try
        {
            while (!_dataParser.TryParse(fileName, out data))
            {
                _userInput.DisplayMessage("File Does not Exist");
                fileName = _userInput.GetFileName();
            }
        }
        catch (JsonDataException ex)
        {
            var msg = $"JSON in {fileName} is not valid format. JSON body:";
            _userInput.ErrorMessage(msg, ex.Data);
            _userInput.DisplayMessage("Sorry! The application has experienced an unexpected error and will have to be closed.");
            File.AppendAllText("log.txt", ex.ToString());
            return;
        }


        try
        {
            _userInput.DisplayGameData(data);
        }
        catch (ArgumentException ex)
        {
            _userInput.DisplayMessage(ex.Message);
        }


    }
}
public class JsonDataException : Exception
{
    public string Data { get; init; }
    public JsonDataException(string message, string data) : base(message)
    {
        Data = data;
    }
}
public class GameData
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public float Rating { get; set; }
    public GameData(string title, int releaseYear, float rating)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
    }
    public override string ToString() => $"{Title}, released in {ReleaseYear}, rating: {Rating}";
}

public interface IUserInteraction
{
    void Close();
    void DisplayGameData(List<GameData> d);
    void DisplayMessage(string v);
    void ErrorMessage(string v, string d);
    string GetFileName();
}
public class ConsoleUserInteraction : IUserInteraction
{

    public string GetFileName()
    {
        var prompt = "Enter the name of the file you want to read:";
        Console.WriteLine(prompt);
        var userInput = Console.ReadLine();
        while (userInput is null || userInput.Length == 0)
        {
            var errorPrompt = userInput is null ? "null" : "empty";
            Console.WriteLine($"File cannot be {errorPrompt}");
            Console.WriteLine(prompt);
            userInput = Console.ReadLine();
        }
        return userInput;

    }
    public void DisplayMessage(string msg) => Console.WriteLine(msg);

    public void DisplayGameData(List<GameData> d)
    {
        if (d.Count == 0 || d is null) throw new ArgumentException("No games are present in the input file.");

        Console.WriteLine("Loaded games are:");
        foreach (var item in d)
        {
            Console.WriteLine(item);
        }


    }

    public void Close()
    {
        Console.WriteLine("Press any key to close...");
        Console.ReadKey();
    }

    public void ErrorMessage(string v, string d)
    {
        // Set foreground color to red
        Console.ForegroundColor = ConsoleColor.Red;

        // Write error message
        Console.WriteLine(v);

        // Optionally, write additional data (if needed)
        Console.WriteLine(d);

        // Reset foreground color to default
        Console.ResetColor();
    }
}
public interface IDataParser
{
    bool TryParse(string fileName, out List<GameData> data);
}
public abstract class DataParser
{
    protected bool FileExists(string filename) => File.Exists(filename);
}
public class JsonDataParser : DataParser, IDataParser
{


    public bool TryParse(string fileName, out List<GameData> data)
    {
        if (!FileExists(fileName))
        {
            data = new List<GameData>();
            return false;
        }

        var json = File.ReadAllText(fileName);
        try
        {
            data = JsonSerializer.Deserialize<List<GameData>>(json);
            return true;
        }
        catch
        {
            throw new JsonDataException("Sorry! The application has experienced an unexpected" +
                "error and will have to be closed.", json);
        }

    }
}
public interface IDataLog
{

}
public interface ConsoleDataLog : IDataLog
{

}