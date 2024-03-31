using CookieCookbook2.Recipes;

namespace CookieCookbook2.App;

public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesConsoleUserInteraction;

    public CookiesRecipesApp(
        IRecipesRepository repo,
        IRecipesUserInteraction userInteraction
        )
    {
        _recipesRepository = repo;
        _recipesConsoleUserInteraction = userInteraction;
    }
    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesConsoleUserInteraction.PrintExistingRecipes(allRecipes);
        _recipesConsoleUserInteraction.PromptToCreateRecipe();
        var ingredients = _recipesConsoleUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);

            _recipesConsoleUserInteraction.ShowMessage("Recipe added:");
            _recipesConsoleUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesConsoleUserInteraction.ShowMessage("No ingredients have been selected. "
                + "Recipe will not be saved.");
        }
        _recipesConsoleUserInteraction.Exit();
    }
}
