using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using CookiesCookbook;
namespace CookieFiles
{
    public enum FileFormat { JSON, TXT };

    public static class Files
    {
        public static void Save(List<Ingredient> payload, FileFormat format)
        {
            if (FileFormat.JSON == format)
                SaveAsJson(payload);
            else if (FileFormat.TXT == format)
                SaveAsText(payload);

        }
        public static List<Ingredient> Read(FileFormat format)
        {
            return FileFormat.JSON == format ? ReadAsJson() : ReadAsText();
        }

        private static List<Ingredient> ReadAsText()
        {
            var temp = File.ReadAllText("recipies.text").Split(Environment.NewLine);
            var result = new List<Ingredient>();
            foreach (var line in temp)
            {
                if (int.TryParse(line, out var id))
                {
                    result.Add(IdToItem.GetIngredient((IngredientType)id));
                }
            }
            Console.WriteLine(temp);
            return result;
        }

        private static List<Ingredient> ReadAsJson()
        {
            throw new NotImplementedException();
        }

        private static void SaveAsJson(List<Ingredient> payload)
        {
            var path = "recipies.json";
            var allIds = new List<string>();
            foreach (var ingredient in payload)
            {
                allIds.Add(ingredient.Id.ToString());
            }

            File.AppendAllText(path, JsonSerializer.Serialize(allIds));

        }
        private static void SaveAsText(List<Ingredient> payload)
        {
            var path = "recipies.text";
            var allIds = new List<int>();
            foreach (var ingredient in payload)
            {
                allIds.Add((int)ingredient.Id);
            }
            string recipiesAsString = string.Join(",", allIds);
            Console.WriteLine(recipiesAsString);

            File.AppendAllText(path, recipiesAsString + Environment.NewLine);
        }
    }
}

/*
 * 
                    var asJson = JsonSerializer.Serialize(payload);
                    Console.WriteLine(asJson);

                    File.WriteAllText(path, asJson);
  */