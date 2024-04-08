namespace CookieCookbook2.Recipes.Ingredients;

public class Cinnamon : Spice
{
    public override int Id => 7;
    public override string Name => "Cinnamon";
    public override string PreparationInstructions =>
        $"Take half a teaspoon. {base.PreparationInstructions}";
}
