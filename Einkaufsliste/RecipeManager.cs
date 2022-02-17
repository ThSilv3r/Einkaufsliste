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
            Recipe recipe = new Recipe();
            List<Food> foods = new List<Food>();
            string name = "List";

            Console.WriteLine("Gib den Name der Einkaufsliste ein");
            name = Console.ReadLine();
            recipe.Name = name;
            recipe.Foods = foods;

            saveRecipe(recipe);
        }
        public void saveRecipe(Recipe recipe)
        {
            using (StreamWriter streamWriter = new StreamWriter(path + recipe.Name + ".json"))
            {
                string jsonRecipe = JsonSerializer.Serialize(recipe);
                streamWriter.Write(jsonRecipe);
            }
        }
        public Recipe GetRecipe(string name)
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
        public void deleteRecipe(string name)
        {
            File.Delete(path + name + ".json");
        }
        public void addFood(string recipeName)
        {
            Recipe recipe = GetRecipe(recipeName);
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
            Recipe recipe = GetRecipe(recipeName);

            ShoppingListManager shoppingListManager = new ShoppingListManager();
            Console.WriteLine("Gib den Namen der Einkaufsliste ein:");
            string shoppingListName = Console.ReadLine();
            ShoppingList shoppingList = shoppingListManager.GetShoppingList(shoppingListName);

            foreach(var food in recipe.Foods)
            {
                shoppingList.Foods.Add(food);
            }
            shoppingListManager.saveShoppingList(shoppingList);
        }
    }
}
