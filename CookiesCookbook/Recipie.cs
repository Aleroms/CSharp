using CookiesCookbook;
using CookieFiles;
public class Recipie
{
    public List<List<Ingredient>> Recipies { get; set; }
    public List<Ingredient> Current { get; set; }
    private FileFormat _fileFormat {  get; init; }

    public Recipie(FileFormat format)
    {
        Recipies = Files.Read(format);
        Recipies.RemoveAll(recipie => recipie.Count == 0);
        _fileFormat = format;
    }
    public void DisplayAll()
    {
        if(Recipies.Count  == 0) return;
        Console.WriteLine("Existing recipies are:\n");
        for (int i = 0; i < Recipies.Count; i++)
        {
            Console.WriteLine($"**** {i + 1} ****");
            Display(Recipies[i]);
        }
    }
    public void DisplayCurrent()
    {
        Display(Current);
    }
    public void Display(List<Ingredient> recipie)
    {
        foreach (var ingredient in recipie)
        {
            if (ingredient is IRecipePreparation preparation)
            {
                Console.WriteLine($"{ingredient}. {preparation.Prepare()}");

            }
        }
        Console.WriteLine("");
    }
    public void Add(List<Ingredient> recipie)
    {
        Recipies.Add(recipie);
        Console.WriteLine("Recipe added:");
        Display(recipie);
        Files.Save(Recipies, _fileFormat);
    }
}
