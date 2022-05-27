using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.Domaine.Aggregate;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins
{
    public class RecipePlugin : RecipePluginRepository
    {
        public void saveRecipe(Recipe recipe)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Recipes\";
            using (StreamWriter streamWriter = new StreamWriter(path + recipe.Name + ".json"))
            {
                string jsonRecipe = JsonSerializer.Serialize(recipe);
                streamWriter.Write(jsonRecipe);
            }
        }
        public Recipe getRecipe(string name)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Recipes\";
            Recipe recipe = new Recipe();

            using (StreamReader streamReader = new StreamReader(path + name + ".json"))
            {
                string shoppingListString = streamReader.ReadToEnd();
                if (shoppingListString != "")
                {
                    recipe = JsonSerializer.Deserialize<Recipe>(shoppingListString);
                }
            }

            return recipe;
        }
        public void deleteRecipe(string name = null)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Recipes\";
            OutputValues outputValues = new OutputValues();
            if (name == null)
            {
                ReadValues readValues = new ReadValues();
                outputValues.enterNameMessage();
                name = readValues.ReadString();
            }
            if (name != "")
            {
                File.Delete(path + name + ".json");

                Console.WriteLine("Deleted: " + name);
            }
            else
            {
                outputValues.nameWarning();
            }
        }
    }
}
