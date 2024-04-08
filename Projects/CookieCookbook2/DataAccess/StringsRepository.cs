namespace CookieCookbook2.DataAccess;

public abstract class StringsRepository : IStringsRepository
{

    public List<string> Read(string path)
    {
        if (File.Exists(path))
        {
            var fileContents = File.ReadAllText(path);
            return TextToStrings(fileContents);

        }
        return new List<string>();
    }
    protected abstract List<string> TextToStrings(string fileContents);
    public void Write(string path, List<string> strings)
    {
        File.WriteAllText(path, StringsToText(strings));
    }
    protected abstract string StringsToText(List<string> strings);
}
