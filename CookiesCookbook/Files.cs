using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using CookiesCookbook;
namespace CookieFiles
{
    public enum FileFormat { JSON, TXT };

    public static class Files
    {
        private static readonly string _textPath = "recipies.text";
        private static readonly string _jsonPath = "recipies.json";
        public static void Save(List<List<Ingredient>> payload, FileFormat format)
        {
            if (FileFormat.JSON == format)
                SaveAsJson(payload);
            else if (FileFormat.TXT == format)
                SaveAsText(payload);

        }
        public static List<List<Ingredient>> Read(FileFormat format)
        {
            return FileFormat.JSON == format ? ReadAsJson() : ReadAsText();
        }

        public static List<string> LoadRecipies()
        {
            return new List<string>();
        }

        private static List<List<Ingredient>> ReadAsText()
        {
            if (File.Exists(_textPath))
            {
                var temp = File.ReadAllText(_textPath).Split(Environment.NewLine);

                var result = new List<List<Ingredient>>();
                foreach (var line in temp)
                {
                    
                    var recipieLine = line.Split(',');
                    var recipieArr = new List<Ingredient>();
                    foreach (var ingredient in recipieLine)
                    {
                        if (int.TryParse(ingredient, out var id))
                        {
                            recipieArr.Add(IdToItem.GetIngredient((IngredientType)id));
                        }
                    }
                    result.Add(recipieArr);
                }
                
                return result;
            }
            return new List<List<Ingredient>>();

        }

        private static List<List<Ingredient>> ReadAsJson()
        {
            throw new NotImplementedException();
        }

        private static void SaveAsJson(List<List<Ingredient>> payload)
        {
            /*var path = "recipies.json";
            var allIds = new List<string>();
            foreach (var ingredient in payload)
            {
                allIds.Add(ingredient.Id.ToString());
            }

            File.AppendAllText(path, JsonSerializer.Serialize(allIds));*/

        }
        private static void SaveAsText(List<List<Ingredient>> payload)
        {
            string recipiesAsString = "";
            foreach(var recipe in payload)
            {

                var allIds = new List<int>();
                foreach(var ingredient in recipe)
                {
                    allIds.Add((int)ingredient.Id);
                }
                recipiesAsString += string.Join(',', allIds) + Environment.NewLine;

            }
            
            Console.WriteLine(recipiesAsString);
            File.WriteAllText(_textPath, recipiesAsString);
        }

    }
}
