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
            recipeManager = new RecipeManager();
            foodManager = new FoodManager();
            listManager = new ShoppingListManager();
        }
        [TestMethod]
        public void CreateRecipe()
        {
            //arrange
            string name = "Test";
            List<Food> foods = new List<Food>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };
            foods.Add(food);

            //act
            Recipe recipe = recipeManager.createRecipe(name, foods, name);

            //assert
            Assert.IsNotNull(recipe);
        }
        [TestMethod]
        public void CreateRecipeNoName()
        {
            //arrange
            string name = "";
            StringReader stringReader = new StringReader("");
            Console.SetIn(stringReader); 
            List<Food> foods = new List<Food>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };
            foods.Add(food);

            //act
            Recipe recipe = recipeManager.createRecipe(name, foods, name);

            //assert
            Assert.IsNull(recipe);
        }      
        [TestMethod]
        public void AddFood()
        {
            //arange
            string name = "AddFoodTest";
            List<Food> foods = new List<Food>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };
            Recipe recipe = new Recipe
            {
                Name = name,
                Foods = foods
            };
            foods.Add(food);

            //act
            recipe = recipeManager.addFood(recipe, food);

            //assert
            Assert.IsNotNull(recipe.Foods.First());
        }
        [TestMethod]
        public void AddToShoppingList()
        {
            //arange
            string name = "Test";
            List<Food> foods = new List<Food>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };
            foods.Add(food);
            Recipe recipe = new Recipe
            {
                Name = name,
                Foods = foods
            };
            ShoppingList shoppingList = new ShoppingList
            {
                Name = name,
                Foods = new List<Food>()
            };
            //act
            shoppingList =  recipeManager.addToShoppingList(recipe, shoppingList);

            //assert
            Assert.AreEqual(recipe.Foods.Last().Name, shoppingList.Foods.Last().Name);
        }
        //[TestMethod]
        //public void ReadProductListTest()
        //{
        //    //arrange
        //    string output;
        //    string name = "Test";
        //    List<Food> foods = new List<Food>();
        //    Recipe recipe = new Recipe
        //    {
        //        Name = name,
        //        Foods = foods
        //    };
        //    Food food = new Food
        //    {
        //        Name = name,
        //        Price = new Price { price = 1 }
        //    };
        //    foods.Add(food);
        //    recipePlugin.saveRecipe(recipe);
        //    foodPlugin.saveFood(foods);
        //    string expected = "Foods:\r\nName: Test Price: 1 Weight: 0\r\n";
        //    //act
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        Console.SetOut(sw);
        //        recipeManager.readRecipe(recipe.Name);
        //        output = sw.ToString();
        //    }

        //    //assert
        //    Assert.AreEqual(expected, output);
        //    recipePlugin.deleteRecipe(recipe.Name);
        //    foodPlugin.deleteFood(food.Name);
        //}
    }
}
