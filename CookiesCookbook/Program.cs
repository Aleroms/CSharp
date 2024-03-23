using CookiesCookbook;
using CookieFiles;
using System.Collections.Generic;

FileFormat format = FileFormat.TXT;
var ingredients_list = new List<Ingredient>()
{
    new Wheat(), new Coconut(), new Butter(),
    new Chocolate(), new Sugar(), new Cardamom(),
    new Cinnamon(), new Cocoa()
};
var currentRecipies = new List<Ingredient>();
var recipies = new Recipie(format);
recipies.DisplayAll();


Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
foreach (Ingredient ingredient in ingredients_list)
{
    Console.WriteLine($"{(int)ingredient.Id + 1}.  {ingredient}");
}
bool continueSelecting = false;
do
{
    Console.WriteLine("Add an ingredient by it's Id or type anything else if finished.");
    int recipeId;
    string userInput = Console.ReadLine();
    continueSelecting = int.TryParse(userInput, out recipeId);
    
    recipeId--;
    if (Enum.IsDefined(typeof(IngredientType), recipeId)) 
        currentRecipies.Add(IdToItem.GetIngredient((IngredientType)recipeId));
    


} while (continueSelecting);
recipies.Add(currentRecipies);
//Files.Save(recipies, format);
