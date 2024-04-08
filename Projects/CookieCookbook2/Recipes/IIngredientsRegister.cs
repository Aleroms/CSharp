using CookieCookbook2.Recipes.Ingredients;

namespace CookieCookbook2.Recipes;

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}
