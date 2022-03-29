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
        public void createRecipe()
        {
            FluentRecipe recipe = new FluentRecipe();
            List<Food> foods = new List<Food>();
            FoodManager foodManager = new FoodManager();
            List<Food> foodList = foodManager.getFoodList();
            string name = "Recipe";
            string food = "a";


            Console.WriteLine("Gib den Name des Rezepts ein");
            name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Bitte Versuche es erneut mit einem Namen.");
                return;
            }

            Console.WriteLine("Suche die benötigten Lebensmittel aus");
            foreach(var fd in foodList)
            {
                Console.WriteLine(fd.Name);
            }
            while(food != "")
            {
                food = Console.ReadLine();
                if(food != "")
                {
                    var addedFood = foodList.FirstOrDefault(f => f.Name == food);
                    foods.Add(addedFood);
                    Console.WriteLine("Gebe nichts ein, um dies Auswahl zu Beenden.");
                }
            }
            Console.WriteLine("Enter the description:");
            string desc = Console.ReadLine();
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
            FoodManager foodManager = new FoodManager();
            Food foodItem = new Food();
            List<Food> foodList = foodManager.getFoodList();
            foreach (Food food in foodList)
            {
                Console.WriteLine(count + ".:" + food.Name);
            }
            Console.WriteLine("Please enter the food name:");
            string foodName = Console.ReadLine();
            foodItem = foodList.FirstOrDefault(x => x.Name == foodName);

            recipe.Foods.Add(foodItem);
            saveRecipe(recipe);
        }

        public void addToShoppingList()
        {
            Console.WriteLine("Gib den Namen des Rezept ein:");
            string recipeName = Console.ReadLine();
            Recipe recipe = getRecipe(recipeName);

            ShoppingListManager shoppingListManager = new ShoppingListManager();
            Console.WriteLine("Gib den Namen der Einkaufsliste ein:");
            string shoppingListName = Console.ReadLine();
            ShoppingList shoppingList = shoppingListManager.getShoppingList(shoppingListName);

            foreach(var food in recipe.Foods)
            {
                shoppingList.Foods.Add(food);
            }
            shoppingListManager.saveShoppingList(shoppingList);
        }
    }
}
