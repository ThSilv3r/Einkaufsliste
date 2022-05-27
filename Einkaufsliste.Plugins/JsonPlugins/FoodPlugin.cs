using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins
{
    public class FoodPlugin : FoodPluginRepository
    {
        //private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Foods.json";
        public void saveFoodList(List<Food> foods)
        {

            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Foods.json";

            path = path.Trim();
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string jsonFoods = JsonSerializer.Serialize(foods);
                streamWriter.Write(jsonFoods);
            }
        }
        public List<Food> getFoodList()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Foods.json";
            List<Food> foods = new List<Food>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string foodsString = streamReader.ReadToEnd();
                if (foodsString != "")
                {
                    foods = JsonSerializer.Deserialize<List<Food>>(foodsString);
                }
            }
            return foods;
        }

        public void deleteFood(string name = null)
        {
            FoodOutputs foodOutputs = new FoodOutputs();
            OutputValues outputValues = new OutputValues();
            List<Food> foods = getFoodList();
            foreach (var fd in foods)
            {
                foodOutputs.writeFood(fd);
            }
            if (name == null)
            {
                ReadValues readValues = new ReadValues();
                outputValues.enterNameMessage();
                name = readValues.ReadString();
            }

            if(name != "")
            {
                Food food = foods.Find(x => x.Name == name);
                foods.Remove(food);

                saveFoodList(foods);
                Console.WriteLine("Deleted: " + food.Name);
            }
            else
            {
                outputValues.nameWarning();
            }
        }
    }
}
