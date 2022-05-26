using Einkaufsliste.Adapters;
using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Domaine.Aggregate;
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
        RecipeOutputs recipeOutputs = new RecipeOutputs();
        FoodOutputs foodOutputs = new FoodOutputs();
        RecipeViewAdapter recipeAdapter = new RecipeViewAdapter();
        FoodViewAdapter foodAdapter = new FoodViewAdapter();
        UserInputs userInputs = new UserInputs();
        public void createRecipe()
        {
            List<Food> foods = new List<Food>();
            List<Guid> foodIds = new List<Guid>();
            List<Food> foodList = foodPlugin.getFoodList();
            string name = "";

            name = userInputs.getName();

            foodOutputs.chooseFoodMessage();

            foods = userInputs.chooseFoods(foodList);
            foreach(Food food in foods)
            {
                foodIds.Add(food.Id);
            }

            recipeOutputs.enterDescriptionMessage();
            string desc = readValues.ReadString();

            if(name != null && name != "")
            {
                Recipe recipe = recipeAdapter.createRecipe(name, foodIds, desc);
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
            List<Food> foods = foodPlugin.getFoodList();
            recipeOutputs.foodsMessage();
            foreach (Guid foodId in recipe.Foods)
            {
                Food food = foodAdapter.getFoodById(foodId, foods);
                foodOutputs.writeFood(food);
            }
        }

        public void addFoodToRecipe(string recipeName)
        {
            Recipe recipe = recipePlugin.getRecipe(recipeName);
            List<Food> foods = new List<Food>();
            List<Food> foodList = foodPlugin.getFoodList();

            foods = userInputs.chooseFoods(foodList);

            foreach(Food fd in foods)
            {
                recipe = recipeAdapter.addFoodToRecipe(recipe, fd.Id);
            }
            recipePlugin.saveRecipe(recipe);
        } 

        public void addRecipeToShoppingList(string recipeName = null, string listName = null)
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
                shoppingList = recipeAdapter.addRecipeToShoppingList(recipe, shoppingList);
                shoppingListPlugin.saveShoppingList(shoppingList);
            }

        }
    }
}
