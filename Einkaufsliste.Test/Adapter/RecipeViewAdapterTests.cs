using Einkaufsliste.Adapters;
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
    public class RecipeViewAdapterTest
    {
        RecipeViewAdapter recipeAdapter;
        Recipe testRecipe;
        Food apple;
        [TestInitialize]
        public void Startup()
        {
            recipeAdapter = new RecipeViewAdapter();
            testRecipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = "TestRecipe",
                Description = "Test",
                Foods = new List<Guid>()
            };
            apple = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 1 },
                Weight = 0
            };
        }
        [TestMethod]
        public void CreateRecipeTest()
        {
            //arrange

            //act
            Recipe recipe = recipeAdapter.createRecipe(testRecipe.Name, testRecipe.Foods, testRecipe.Description);

            //assert
            Assert.AreEqual(testRecipe.Name, recipe.Name);
        }
        [TestMethod]
        public void addFoodToRecipeTest()
        {
            //arrange

            //act
            Recipe recipe = recipeAdapter.addFoodToRecipe(testRecipe, apple.Id);

            //assert
            Assert.AreEqual(apple.Id, recipe.Foods.Last());
        }
        [TestMethod]
        public void addRecipeToShoppingListTest()
        {
            //arrange
            ShoppingList shoppingList = new ShoppingList
            {
                Id = Guid.NewGuid(),
                Foods = new List<Guid>(),
                Name = "TestListe",
                Products = new List<Guid>()
            };
            testRecipe.Foods.Add(apple.Id);
            //act
            shoppingList = recipeAdapter.addRecipeToShoppingList(testRecipe, shoppingList);

            //assert
            Assert.AreEqual(testRecipe.Foods.Last(), shoppingList.Foods.Last());
        }
    }
}
