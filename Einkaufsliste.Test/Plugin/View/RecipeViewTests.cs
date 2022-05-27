using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Domaine.Aggregate;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using Einkaufsliste.Plugins.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class RecipeViewTest
    {
        RecipeView recipeView;
        RecipePlugin recipePlugin;
        FoodPlugin foodPlugin;
        ShoppingListPlugin listPlugin;
        Food food;
        [TestInitialize]
        public void Startup()
        {
            recipeView = new RecipeView();
            recipePlugin = new RecipePlugin();
            foodPlugin = new FoodPlugin();
            listPlugin = new ShoppingListPlugin();
            food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = new Price { price = 1},
                Weight = 1
            };
        }

        [TestMethod]
        public void createRecipeTest()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Recipes\";
            //arrange
            string name = "TestRecipe";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            //act
            recipeView.createRecipe();

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            recipePlugin.deleteRecipe(name);
        }
        [TestMethod]
        public void ReadRecipeTest()
        {
            //arrange
            string name = "TestRecipe";
            string output = "";
            string expected = "Please enter a name.\r\nFoods:\r\n";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            recipeView.createRecipe();

            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                stringReader = new StringReader(name);
                Console.SetIn(stringReader);
                recipeView.readRecipe();
                output = sw.ToString();


                //assert
                Assert.AreEqual(expected, output);
                recipePlugin.deleteRecipe(name);
            }
        }

        [TestMethod]
        public void AddFoodToRecipeTest()
        {
            //arrange
            string name = "Test";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);
            recipeView.createRecipe();
            List<Food> foods = new List<Food>();
            foods.Add(food);
            foodPlugin.saveFoodList(foods);
            Recipe testRecipe = new Recipe
            {
                Name = name,
                Id = Guid.NewGuid(),
                Description = "",
                Foods = new List<Guid>()
            };
            recipePlugin.saveRecipe(testRecipe);
            stringReader = new StringReader(name);
            Console.SetIn(stringReader);
            //act
            recipeView.addFoodToRecipe(name);

            //assert
            Recipe recipe = recipePlugin.getRecipe(name);
            Assert.AreEqual(recipe.Foods.First(), food.Id);
            foodPlugin.deleteFood(food.Name);
            recipePlugin.deleteRecipe(name);
        }
        [TestMethod]
        public void AddRecipeToShoppingListTest()
        {
            string name = "Test";
            Recipe recipe = new Recipe
            {
                Name = name,
                Id = Guid.NewGuid(),
                Description = "",
                Foods = new List<Guid>()
            };
            recipe.Foods.Add(food.Id);
            ShoppingList shoppingList = new ShoppingList
            {
                Name = name,
                Id = Guid.NewGuid(),
                Foods = new List<Guid>(),
                Products = new List<Guid>()
            };
            recipePlugin.saveRecipe(recipe);
            listPlugin.saveShoppingList(shoppingList);
            //act
            recipeView.addRecipeToShoppingList(recipe.Name, shoppingList.Name);


            //assert
            ShoppingList list = listPlugin.getShoppingList(shoppingList.Name);
            Assert.AreEqual(recipe.Foods.First(), list.Foods.First());
            recipePlugin.deleteRecipe(name);
            listPlugin.deleteShoppingList(name);
        }
    }
}
