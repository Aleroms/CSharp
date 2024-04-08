using CookieCookbook2.Recipes;
using CookieCookbook2.Recipes.Ingredients;

namespace CookieCookbook2.App;

public class IRecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public IRecipesConsoleUserInteraction(IIngredientsRegister register)
    {
        _ingredientsRegister = register;
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are:");

            
            var allRecipesAsStrings = allRecipes
                .Select((recipe, counter) =>
                Environment.NewLine + $"**** {counter + 1} ****" +
                Environment.NewLine + $"{recipe}"
                );

            Console.WriteLine(
                string.Join(Environment.NewLine, allRecipesAsStrings));

        }
    }
    public void PromptToCreateRecipe()
    {
        Console.WriteLine("\nCreate a new cookie recipe! " +
            "Available ingredients are:");

        
        Console.WriteLine(
            string.Join(Environment.NewLine, _ingredientsRegister.All));
    }
    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID, " +
                "or type anything else if finished.");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient != null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }
        return ingredients;
    }
}
