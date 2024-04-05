using CookieCookbook2.DataAccess;
using CookieCookbook2.Recipes.Ingredients;

namespace CookieCookbook2.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        return _stringsRepository.Read(filePath)
            .Select(stringsRepository => RecipeFromString(stringsRepository))
            .ToList();

    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var ingredients = recipeFromFile.Split(Separator)
            .Select(int.Parse)
            .Select(_ingredientsRegister.GetById);

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = allRecipes
            .Select(recipe =>
            {
                var allIds = recipe.Ingredients
                .Select(ingredient => ingredient.Id);
                return string.Join(Separator, allIds);
            });

        _stringsRepository.Write(filePath, recipesAsStrings.ToList());
    }
}
