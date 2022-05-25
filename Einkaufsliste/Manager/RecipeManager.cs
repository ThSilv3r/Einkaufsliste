using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class RecipeManager : RecipeRepository
    {
        //ReadValuesRepository readValues;
        //RecipePluginRepository recipePlugin;
        //ShoppingListPluginRepository shoppingListPlugin;
        //FoodPluginRepository foodPlugin;
        //OutputValuesRepository outputValues;
        //RecipeOutputRepository recipeOutputs;
        //FoodOutputRepository foodOutputs;        
        //public RecipeManager(RecipePluginRepository recipePlugin, ReadValuesRepository readValues, 
        //    ShoppingListPluginRepository shoppingListPlugin, FoodPluginRepository foodPlugin, 
        //    OutputValuesRepository outputValues, RecipeOutputRepository recipeOutput, FoodOutputRepository foodOutput)
        //{
        //    this.outputValues = outputValues;
        //    this.recipePlugin = recipePlugin;
        //    this.shoppingListPlugin = shoppingListPlugin;
        //    this.foodPlugin = foodPlugin;
        //    this.foodOutputs = foodOutput;
        //    this.recipeOutputs = recipeOutput;
        //    this.readValues = readValues;
        //}
        RecipeBuilder recipeBuilder;
        RecipeEngineer recipeEngineer;
        Recipe recipe;
        public Recipe createRecipe(string name, List<Food> foods, string description)
        {
            RecipeBuilder recipeBuilder = new RecipeBuilder();
            RecipeEngineer recipeEngineer = new RecipeEngineer(recipeBuilder);
            Recipe recipe = new Recipe();
            //List<Food> foods = new List<Food>();
            //List<Food> foodList = foodPlugin.getFoodList();
            //string food = "";

            //foodOutputs.chooseFoodMessage();
            //foreach(var fd in foodList)
            //{
            //    Console.WriteLine(fd.Name);
            //}
            //while(food != null && food != "q")
            //{
            //    food = readValues.ReadString();
            //    if(food != "q" && food != null)
            //    {
            //        var addedFood = foodList.FirstOrDefault(f => f.Name == food);
            //        foods.Add(addedFood);
            //        outputValues.closeEntryMessage();
            //    }
            //}
            //if (food != "q" && food != null)
            //{
            //    var addedFood = foodList.FirstOrDefault(f => f.Name == food);
            //    foods.Add(addedFood);
            //    outputValues.closeEntryMessage();
            //}
            //recipeOutputs.enterDescriptionMessage();
            //string desc = readValues.ReadString();

            if (name != null && name != "")
            {
                recipeEngineer.constructRecipe(name, description, foods);
                recipe = recipeEngineer.GetRecipe();
                return recipe;
                //recipePlugin.saveRecipe(recipe);
            }
            return null;
        }

        //public void readRecipe(string name)
        //{
        //    Recipe recipe = recipePlugin.getRecipe(name);

        //    recipeOutputs.foodsMessage();
        //    foreach (Food food in recipe.Foods)
        //    {
        //        foodOutputs.writeFood(food);
        //    }
        //}

        public Recipe addFood(Recipe recipe, Food food)
        {
            //Recipe recipe = recipePlugin.getRecipe(recipeName);
            //int count = 0;
            //string food = "";
            //Food foodItem = new Food();
            //List<Food> foods = new List<Food>();
            //List<Food> foodList = foodPlugin.getFoodList();
            //foreach (var fd in foodList)
            //{
            //    Console.WriteLine(fd.Name);
            //}
            //while (food != null && food != "q")
            //{
            //    food = readValues.ReadString();
            //    if (food != null && food != "q")
            //    {
            //        var addedFood = foodList.FirstOrDefault(f => f.Name == food);
            //        foods.Add(addedFood);
            //        outputValues.closeEntryMessage();
            //    }
            //}
            //recipe.Foods = foods;
            //recipePlugin.saveRecipe(recipe);
            recipe.Foods.Add(food);
            return recipe;
        }

        public ShoppingList addToShoppingList(Recipe recipe, ShoppingList list)
        {
            //if(recipeName == null)
            //{
            //    recipeOutputs.enterRecipeNameMessage();
            //    recipeName = readValues.ReadString();
            //}
            //Recipe recipe = recipePlugin.getRecipe(recipeName);

            //if(listName == null)
            //{
            //    recipeOutputs.enterListNameMessage();
            //    listName = readValues.ReadString();
            //}
            //ShoppingList shoppingList = shoppingListPlugin.getShoppingList(listName);

            //foreach(var food in recipe.Foods)
            //{
            //    shoppingList.Foods.Add(food);
            //}
            //shoppingListPlugin.saveShoppingList(shoppingList);
            foreach(Food food in recipe.Foods)
            {
                list.Foods.Add(food);
            }
            
            return list;
        }
    }
}
