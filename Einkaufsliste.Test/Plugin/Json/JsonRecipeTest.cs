using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
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
    public class JsonRecipeTest
    {
        string path;
        RecipePluginRepository recipePlugin;
        ShoppingListPluginRepository shoppingListPlugin;
        RecipeOutputRepository recipeOutput;
        FoodPluginRepository foodPlugin;
        ReadValuesRepository readValues;
        FoodOutputRepository foodOutput;
        OutputValuesRepository outputValues;
        RecipeRepository recipeManager;
        [TestInitialize]
        public void Startup()
        {
            path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Recipes\";
            recipePlugin = new RecipePlugin();
            readValues = new ReadValues();
            recipeOutput = new RecipeOutputs();
            outputValues = new OutputValues();
            foodPlugin = new FoodPlugin();
            shoppingListPlugin = new ShoppingListPlugin();
            recipeManager = new RecipeManager();
        }
        [TestMethod]
        public void SaveRecipe()
        {
            //arrange
            Recipe expectedRecipe = new Recipe
            {
                Name = "TestRecipe"
            };
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);

            //act
            recipePlugin.saveRecipe(expectedRecipe);

            //assert
            Recipe recipe = recipePlugin.getRecipe(expectedRecipe.Name);
            Assert.AreEqual(expectedRecipe.Name, recipe.Name);
            recipePlugin.deleteRecipe(expectedRecipe.Name);
        }
        [TestMethod]
        public void GetRecipe()
        {
            //arrange
            Recipe expectedRecipe = new Recipe
            {
                Name = "TestRecipe"
            };
            recipePlugin.saveRecipe(expectedRecipe);

            //act
            var recipe = recipePlugin.getRecipe(expectedRecipe.Name);

            //assert
            Assert.AreEqual(expectedRecipe.Name, recipe.Name);
            recipePlugin.deleteRecipe(expectedRecipe.Name);
        }
        [TestMethod]
        public void DeleteFood()
        {
            //arrange
            Recipe recipe = null;
            Recipe expectedRecipe = new Recipe
            {
                Name = "TestRecipe"
            };
            recipePlugin.saveRecipe(expectedRecipe);

            //act
            recipePlugin.deleteRecipe(expectedRecipe.Name);

            //assert
            try
            {
                recipe = recipePlugin.getRecipe(expectedRecipe.Name);
            }
            catch(Exception ex)
            {

            }
            Assert.IsNull(recipe);
        }

    }
}
