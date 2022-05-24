using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class RecipeTest
    {
        string path;
        RecipeRepository recipeManager;
        RecipePluginRepository recipePlugin;
        ShoppingListPluginRepository shoppingListPlugin;
        ShoppingListRepository listManager;
        FoodRepository foodManager;
        RecipeOutputRepository recipeOutput;
        FoodPluginRepository foodPlugin;
        ProductOutputRepository productOutput;
        ReadValuesRepository readValues;
        FoodOutputRepository foodOutput;
        OutputValuesRepository outputValues;
        ShoppingListOutputRepository shoppingListOutput;
        ProductPluginRepository productPlugin;
        [TestInitialize]
        public void Startup()
        {
            path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Recipes\";
            recipePlugin = new RecipePlugin();
            readValues = new ReadValues();
            foodOutput = new FoodOutputs();
            productOutput = new ProductOutputs();
            recipeOutput = new RecipeOutputs();
            shoppingListOutput = new ShoppingListOutputs();
            outputValues = new OutputValues();
            foodPlugin = new FoodPlugin();
            productPlugin = new ProductPlugin();
            shoppingListPlugin = new ShoppingListPlugin();
            recipeManager = new RecipeManager(recipePlugin, readValues, shoppingListPlugin, foodPlugin, outputValues, recipeOutput, foodOutput);
            foodManager = new FoodManager(foodPlugin, foodOutput, outputValues, readValues);
            listManager = new ShoppingListManager(shoppingListPlugin, outputValues, productOutput,
                foodOutput, shoppingListOutput, readValues, productPlugin, foodManager);
        }
        [TestMethod]
        public void CreateRecipe()
        {
            //arrange
            string name = "Test";
            List<Food> foods = new List<Food>();
            Food food = new Food
            {
                Name = name
            };
            foods.Add(food);
            foodPlugin.saveFood(foods);
            StringReader priceReader = new StringReader(name);
            Console.SetIn(priceReader);

            //act
            recipeManager.createRecipe(name);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            recipePlugin.deleteRecipe(name);
            foodPlugin.deleteFood(food.Name);
        }
        [TestMethod]
        public void CreateRecipeNoName()
        {
            //arrange
            string name = "";
            StringReader stringReader = new StringReader("");
            Console.SetIn(stringReader);
            //act
            recipeManager.createRecipe(name);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsFalse(exists);
            recipePlugin.deleteRecipe(name);
        }      
        [TestMethod]
        public void AddFood()
        {
            //arange
            string name = "AddFoodTest";
            List<Food> foods = new List<Food>();
            Recipe recipe = new Recipe
            {
                Name = name,
                Foods = foods
            };

            Food food = new Food
            {
                Name = name
            };
            foods.Add(food);

            recipePlugin.saveRecipe(recipe);
            foodPlugin.saveFood(foods);

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            //act
            recipeManager.addFood(name);

            //assert
            recipe = recipePlugin.getRecipe(name);
            Assert.IsNotNull(recipe.Foods.First());
            recipePlugin.deleteRecipe(name);
            foodPlugin.deleteFood(name);
        }
        [TestMethod]
        public void AddToShoppingList()
        {
            //arange
            string name = "Test";
            List<Food> foods = new List<Food>();
            Recipe recipe = new Recipe
            {
                Name = name,
                Foods = foods
            };
            Food food = new Food
            {
                Name = name,
                Price = new Price { price = 1}
            };
            ShoppingList shoppingList = new ShoppingList
            {
                Name = name,
                Foods = foods
            };
            foods.Add(food);
            recipePlugin.saveRecipe(recipe);
            foodPlugin.saveFood(foods);
            shoppingListPlugin.saveShoppingList(shoppingList);
            StringReader foodReader = new StringReader(name);
            Console.SetIn(foodReader);
            listManager.addFood(name);

            foodReader = new StringReader(name);
            Console.SetIn(foodReader);
            //act
            recipeManager.addToShoppingList(name, name);

            //assert
            recipe = recipePlugin.getRecipe(name);
            Assert.IsNotNull(recipe.Foods.First());
            recipePlugin.deleteRecipe(name);
            shoppingListPlugin.deleteShoppingList(name);
            foodPlugin.deleteFood(name);
        }
        [TestMethod]
        public void ReadProductListTest()
        {
            //arrange
            string output;
            string name = "Test";
            List<Food> foods = new List<Food>();
            Recipe recipe = new Recipe
            {
                Name = name,
                Foods = foods
            };
            Food food = new Food
            {
                Name = name,
                Price = new Price { price = 1 }
            };
            foods.Add(food);
            recipePlugin.saveRecipe(recipe);
            foodPlugin.saveFood(foods);
            string expected = "Foods:\r\nName: Test Price: 1 Weight: 0\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                recipeManager.readRecipe(recipe.Name);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
            recipePlugin.deleteRecipe(recipe.Name);
            foodPlugin.deleteFood(food.Name);
        }
    }
}
