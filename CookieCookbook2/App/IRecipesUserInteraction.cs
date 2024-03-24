

using CookieCookbook2.Recipes.Ingredients;
using CookieCookbook2.Recipes;

namespace CookieCookbook2.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}
