using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class RecipeManager
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Recipes\";
        private ReadValues readValues = new ReadValues();
        public void createRecipe()
        {
            FluentRecipe recipe = new FluentRecipe();
            List<Food> foods = new List<Food>();
            FoodManager foodManager = new FoodManager();
            List<Food> foodList = foodManager.getFoodList();
            string name = "Recipe";
            string food = "a";


            Console.WriteLine("Gib den Name des Rezepts ein");
            name = readValues.ReadString();

            Console.WriteLine("Suche die benötigten Lebensmittel aus");
            foreach(var fd in foodList)
            {
                Console.WriteLine(fd.Name);
            }
            while(food != "")
            {
                food = readValues.ReadString();
                if(food != "")
                {
                    var addedFood = foodList.FirstOrDefault(f => f.Name == food);
                    foods.Add(addedFood);
                    Console.WriteLine("Gebe nichts ein, um dies Auswahl zu Beenden.");
                }
            }
            Console.WriteLine("Enter the description:");
            string desc = readValues.ReadString();
            recipe.NameOfTheRecipe(name).FoodOfTheRecipe(foods).DescOfTheRecipe(desc);
            Console.WriteLine(recipe);

            saveRecipe(recipe.recipe);
        }
        public void saveRecipe(Recipe recipe)
        {
            using (StreamWriter streamWriter = new StreamWriter(path + recipe.Name + ".json"))
            {
                string jsonRecipe = JsonSerializer.Serialize(recipe);
                streamWriter.Write(jsonRecipe);
            }
        }
        public Recipe getRecipe(string name)
        {
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

        public void readRecipe(string name)
        {
            Recipe recipe = getRecipe(name);

            Console.WriteLine("Zutaten:");
            foreach (Food food in recipe.Foods)
            {
                Console.WriteLine("Name: " + food.Name + " Gewicht: " + food.Weight);
            }
        }
        public void deleteRecipe(string name)
        {
            File.Delete(path + name + ".json");
        }

        public void addFood(string recipeName)
        {
            Recipe recipe = getRecipe(recipeName);
            int count = 0;
            string food = "a";
            FoodManager foodManager = new FoodManager();
            Food foodItem = new Food();
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodManager.getFoodList();
            foreach (var fd in foodList)
            {
                Console.WriteLine(fd.Name);
            }
            while (food != "")
            {
                food = readValues.ReadString();
                if (food != "")
                {
                    var addedFood = foodList.FirstOrDefault(f => f.Name == food);
                    foods.Add(addedFood);
                    Console.WriteLine("Gebe nichts ein, um dies Auswahl zu Beenden.");
                }
            }
            recipe.Foods = foods;
            saveRecipe(recipe);
        }

        public void addToShoppingList()
        {
            Console.WriteLine("Gib den Namen des Rezept ein:");
            string recipeName = readValues.ReadString();
            Recipe recipe = getRecipe(recipeName);

            ShoppingListManager shoppingListManager = new ShoppingListManager();
            Console.WriteLine("Gib den Namen der Einkaufsliste ein:");
            string shoppingListName = readValues.ReadString();
            ShoppingList shoppingList = shoppingListManager.getShoppingList(shoppingListName);

            foreach(var food in recipe.Foods)
            {
                shoppingList.Foods.Add(food);
            }
            shoppingListManager.saveShoppingList(shoppingList);
        }
    }
}
