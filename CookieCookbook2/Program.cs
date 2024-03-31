//Santiago Morales
using CookieCookbook2.App;
using CookieCookbook2.DataAccess;
using CookieCookbook2.FileAccess;
using CookieCookbook2.Recipes;
using CookieCookbook2.Recipes.Ingredients;


const FileFormat Format = FileFormat.JSON;

IStringsRepository stringsRepository = Format == FileFormat.JSON ?
    new StringsJsonRepository() :
    new StringsTextualRepository();

const string FileName = "recipes";

var fileMetaData = new FileMetaData(FileName,Format);
var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(stringsRepository, ingredientsRegister),
    new IRecipesConsoleUserInteraction(
        ingredientsRegister)
    );

cookiesRecipesApp.Run(fileMetaData.ToPath());