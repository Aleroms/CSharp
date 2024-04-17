public class ConsoleUserInteractor : IUserInteractor
{
    public string? ReadFromUser()
    {
        return Console.ReadLine();
    }

    public void ShowMessage(string msg)
    {
        Console.WriteLine(msg);
    }
}
