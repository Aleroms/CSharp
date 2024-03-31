
using System.Text.Json;

namespace CookieCookbook2.DataAccess;

public class StringsJsonRepository : StringsRepository
{

    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }
}
