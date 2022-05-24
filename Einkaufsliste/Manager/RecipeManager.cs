using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Einkaufsliste
{
    public class RecipeManager : RecipeRepository
    {
        ReadValuesRepository readValues;
        RecipePluginRepository recipePlugin;
        ShoppingListPluginRepository shoppingListPlugin;
        FoodPluginRepository foodPlugin;
        OutputValuesRepository outputValues;
        RecipeOutputRepository recipeOutputs;
        FoodOutputRepository foodOutputs;        
        public RecipeManager(RecipePluginRepository recipePlugin, ReadValuesRepository readValues, 
            ShoppingListPluginRepository shoppingListPlugin, FoodPluginRepository foodPlugin, 
            OutputValuesRepository outputValues, RecipeOutputRepository recipeOutput, FoodOutputRepository foodOutput)
        {
            this.outputValues = outputValues;
            this.recipePlugin = recipePlugin;
            this.shoppingListPlugin = shoppingListPlugin;
            this.foodPlugin = foodPlugin;
            this.foodOutputs = foodOutput;
            this.recipeOutputs = recipeOutput;
            this.readValues = readValues;
        }
        public void createRecipe(string name)
        {
            FluentRecipe recipe = new FluentRecipe();
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodPlugin.getFoodList();
            string food = "";

            foodOutputs.chooseFoodMessage();
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
                    outputValues.closeEntryMessage();
                }
            }
            recipeOutputs.enterDescriptionMessage();
            string desc = readValues.ReadString();

            if(name != null && name != "")
            {
                recipe.NameOfTheRecipe(name).FoodOfTheRecipe(foods).DescOfTheRecipe(desc);
                Console.WriteLine(recipe);

                recipePlugin.saveRecipe(recipe.recipe);
            }
        }

        public void readRecipe(string name)
        {
            Recipe recipe = recipePlugin.getRecipe(name);

            recipeOutputs.foodsMessage();
            foreach (Food food in recipe.Foods)
            {
                foodOutputs.writeFood(food);
            }
        }

        public void addFood(string recipeName)
        {
            Recipe recipe = recipePlugin.getRecipe(recipeName);
            int count = 0;
            string food = "";
            Food foodItem = new Food();
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodPlugin.getFoodList();
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
                    outputValues.closeEntryMessage();
                }
            }
            recipe.Foods = foods;
            recipePlugin.saveRecipe(recipe);
        }

        public void addToShoppingList(string recipeName, string listName)
        {
            recipeOutputs.enterRecipeNameMessage();
            //string recipeName = readValues.ReadString();
            Recipe recipe = recipePlugin.getRecipe(recipeName);

            recipeOutputs.enterListNameMessage();
            ShoppingList shoppingList = shoppingListPlugin.getShoppingList(listName);

            foreach(var food in recipe.Foods)
            {
                shoppingList.Foods.Add(food);
            }
            shoppingListPlugin.saveShoppingList(shoppingList);
        }
    }
}
