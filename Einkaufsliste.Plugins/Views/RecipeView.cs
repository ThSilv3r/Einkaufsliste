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
        UserInputs userInputs = new UserInputs();
        public void createRecipe()
        {
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodPlugin.getFoodList();
            string name = "";

            name = userInputs.getName();

            foodOutputs.chooseFoodMessage();

            foods = userInputs.chooseFoods(foodList);

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
                name = userInputs.getName();
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
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodPlugin.getFoodList();

            foods = userInputs.chooseFoods(foodList);

            foreach(Food fd in foods)
            {
                recipeManager.addFood(recipe, fd);
            }
            recipePlugin.saveRecipe(recipe);
        } 

        public void addToShoppingList(string recipeName = null, string listName = null)
        {
            if (recipeName == null)
            {
                recipeName = userInputs.getName();
            }
            Recipe recipe = recipePlugin.getRecipe(recipeName);

            if (listName == null)
            {
                listName = userInputs.getName();
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
