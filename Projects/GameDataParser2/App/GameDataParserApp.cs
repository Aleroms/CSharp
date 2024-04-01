public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IVideoGamesDeserializer _videoGamesDeserializer;
    private readonly IFileReader _reader;

    public GameDataParserApp(
        IGamesPrinter gamesPrinter,
        IUserInteractor userInteractor,
        IVideoGamesDeserializer videoGamesDeserializer,
        IFileReader reader)
    {
        _gamesPrinter = gamesPrinter;
        _userInteractor = userInteractor;
        _videoGamesDeserializer = videoGamesDeserializer;
        _reader = reader;
    }


    public void Run()
    {
        string fileName = _userInteractor.ReadValidFilePath();
        var fileContents = _reader.Read(fileName);
        var videoGames = _videoGamesDeserializer.DeserializeFrom(
            fileName, fileContents);
        _gamesPrinter.Print(videoGames);
    }

}
