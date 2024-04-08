

var userInteractor = new ConsoleUserInteractor();
var app = new GameDataParserApp(
    new GamesPrinter(userInteractor),
    userInteractor, 
    new VideoGamesDeserializer(userInteractor),
    new LocalFileReader());

var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application has experienced an unexpected error " +
        "and will have to be closed.");
    logger.Log(ex);
}



Console.ReadKey();
