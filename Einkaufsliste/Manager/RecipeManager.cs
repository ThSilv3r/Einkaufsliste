using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class RecipeManager : IRecipeManager
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Recipes\";
        private ReadValues readValues = new ReadValues();
        IFoodManager foodManager = new FoodManager();
        public void createRecipe()
        {
            FluentRecipe recipe = new FluentRecipe();
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodManager.getFoodList();
            string name = "Recipe";
            string food = "";


            Console.WriteLine("Enter the name of the recipe.");
            name = readValues.ReadString();

            Console.WriteLine("Enter the needed foods.");
            foreach(var fd in foodList)
            {
                Console.WriteLine(fd.Name);
            }
            while(food != null && food != "q")
            {
                food = readValues.ReadString();
                if(food != "q" && food != null)
                {
                    var addedFood = foodList.FirstOrDefault(f => f.Name == food);
                    foods.Add(addedFood);
                    Console.WriteLine("Enter q to finish.");
                }
            }
            Console.WriteLine("Enter the description:");
            string desc = readValues.ReadString();

            if(name != null)
            {
                recipe.NameOfTheRecipe(name).FoodOfTheRecipe(foods).DescOfTheRecipe(desc);
                Console.WriteLine(recipe);

                saveRecipe(recipe.recipe);
            }
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

            Console.WriteLine("Foods:");
            foreach (Food food in recipe.Foods)
            {
                Console.WriteLine("Name: " + food.Name + " weight: " + food.Weight);
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
            string food = "";
            Food foodItem = new Food();
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodManager.getFoodList();
            foreach (var fd in foodList)
            {
                Console.WriteLine(fd.Name);
            }
            while (food != null && food != "q")
            {
                food = readValues.ReadString();
                if (food != null && food != "q")
                {
                    var addedFood = foodList.FirstOrDefault(f => f.Name == food);
                    foods.Add(addedFood);
                    Console.WriteLine("Enter q to finish.");
                }
            }
            recipe.Foods = foods;
            saveRecipe(recipe);
        }

        public void addToShoppingList()
        {
            Console.WriteLine("Enter the recipe name:");
            string recipeName = readValues.ReadString();
            string shoppingListName = "";
            Recipe recipe = getRecipe(recipeName);

            IShoppingListManager shoppingListManager = new ShoppingListManager();
            Console.WriteLine("Enter the name of the shoppinglist");
            while (shoppingListName != null)
            {
                shoppingListName = readValues.ReadString();
            }
            ShoppingList shoppingList = shoppingListManager.getShoppingList(shoppingListName);

            foreach(var food in recipe.Foods)
            {
                shoppingList.Foods.Add(food);
            }
            shoppingListManager.saveShoppingList(shoppingList);
        }
    }
}
