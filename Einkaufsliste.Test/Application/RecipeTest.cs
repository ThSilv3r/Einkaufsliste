using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Domaine.Aggregate;
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
        [TestInitialize]
        public void Startup()
        {
            path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Recipes\";
            recipeManager = new RecipeManager();
        }
        [TestMethod]
        public void CreateRecipe()
        {
            //arrange
            string name = "Test";
            List<Food> foods = new List<Food>();
            List<Guid> foodIds = new List<Guid>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };
            foods.Add(food);

            foreach(Food fd in foods)
            {
                foodIds.Add(fd.Id);
            }
            //act
            Recipe recipe = recipeManager.createRecipe(name, foodIds, name);

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
            List<Guid> foodIds = new List<Guid>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };
            foods.Add(food);
            foreach(Food fd in foods)
            {
                foodIds.Add(fd.Id);
            }
            //act
            Recipe recipe = recipeManager.createRecipe(name, foodIds, name);

            //assert
            Assert.IsNull(recipe);
        }      
        [TestMethod]
        public void AddFood()
        {
            //arange
            string name = "AddFoodTest";
            List<Guid> foodIds = new List<Guid>();
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
                Foods = foodIds
            };
            foodIds.Add(food.Id);

            //act
            recipe = recipeManager.addFoodToRecipe(recipe, food.Id);

            //assert
            Assert.AreEqual(food.Id, recipe.Foods.First());
        }
        [TestMethod]
        public void AddToShoppingList()
        {
            //arange
            string name = "Test";
            List<Guid> foods = new List<Guid>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };
            foods.Add(food.Id);
            Recipe recipe = new Recipe
            {
                Name = name,
                Foods = foods
            };
            ShoppingList shoppingList = new ShoppingList
            {
                Name = name,
                Foods = new List<Guid>()
            };
            //act
            shoppingList =  recipeManager.addRecipeToShoppingList(recipe, shoppingList);

            //assert
            Assert.AreEqual(recipe.Foods.Last(), shoppingList.Foods.Last());
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
