using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.Views
{
    public class RecipeView
    {
        ReadValues readValues = new ReadValues();
        RecipePlugin recipePlugin = new RecipePlugin();
        ShoppingListPlugin shoppingListPlugin = new ShoppingListPlugin();
        FoodPlugin foodPlugin = new FoodPlugin();
        OutputValues outputValues = new OutputValues();
        RecipeOutputs recipeOutputs = new RecipeOutputs();
        FoodOutputs foodOutputs = new FoodOutputs();
        RecipeManager recipeManager = new RecipeManager();
        public void createRecipe()
        {
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodPlugin.getFoodList();
            string food = "";
            string name = "";

            outputValues.enterNameMessage();
            name = readValues.ReadString();

            foodOutputs.chooseFoodMessage();
            foreach (var fd in foodList)
            {
                Console.WriteLine(fd.Name);
            }
            while (food != null && food != "q")
            {
                food = readValues.ReadString();
                if (food != "q" && food != null)
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
                Recipe recipe = recipeManager.createRecipe(name, foods, desc);
                recipePlugin.saveRecipe(recipe);
            }
        }

        public void readRecipe(string name = null)
        {
            if (name == null)
            {
                ReadValues readValues = new ReadValues();
                outputValues.enterNameMessage();
                name = readValues.ReadString();
            }
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
            Food addedFood = new Food();
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
                    addedFood = foodList.FirstOrDefault(f => f.Name == food);
                    if (addedFood != null)
                    {
                        recipeManager.addFood(recipe, addedFood);
                    }
                    outputValues.closeEntryMessage();
                }
            }
            recipePlugin.saveRecipe(recipe);
        }

        public void addToShoppingList(string recipeName = null, string listName = null)
        {
            if (recipeName == null)
            {
                recipeOutputs.enterRecipeNameMessage();
                recipeName = readValues.ReadString();
            }
            Recipe recipe = recipePlugin.getRecipe(recipeName);

            if (listName == null)
            {
                recipeOutputs.enterListNameMessage();
                listName = readValues.ReadString();
            }
            ShoppingList shoppingList = shoppingListPlugin.getShoppingList(listName);

            if(shoppingList != null)
            {
                shoppingList = recipeManager.addToShoppingList(recipe, shoppingList);
                shoppingListPlugin.saveShoppingList(shoppingList);
            }

        }
    }
}
