using Einkaufsliste.ClassLibrary;
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
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Recipes\";
        [TestMethod]
        public void CreateRecipe()
        {
            //arrange
            RecipeManager recipeManager = new RecipeManager();
            string name = "Test";
            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            //act
            recipeManager.createRecipe();

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            recipeManager.deleteRecipe(name);
        }
        [TestMethod]
        public void SaveRecipe()
        {
            //arrange
            RecipeManager recipeManager = new RecipeManager();
            string name = "Test";
            Recipe recipe = new Recipe
            {
                Name = name
            };

            //act
            recipeManager.saveRecipe(recipe);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            recipeManager.deleteRecipe(name);
        }
        [TestMethod]
        public void AddFood()
        {
            //arange
            RecipeManager recipeManager = new RecipeManager();
            FoodManager foodManager = new FoodManager();
            string name = "Test";
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

            recipeManager.saveRecipe(recipe);
            foodManager.saveFoodList(foods);

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            //act
            recipeManager.addFood(name);

            //assert
            recipe = recipeManager.GetRecipe(name);
            Assert.IsNotNull(recipe.Foods.First());
            recipeManager.deleteRecipe(name);
            foodManager.deleteFood(name);
        }
        [TestMethod]
        public void AddShoppingList()
        {
            //arange
            ShoppingListManager listManager = new ShoppingListManager();
            RecipeManager recipeManager = new RecipeManager();
            FoodManager foodManager = new FoodManager();
            string name = "Test";
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
            ShoppingList shoppingList = new ShoppingList
            {
                Foods = foods
            };
            foods.Add(food);
            recipeManager.saveRecipe(recipe);
            foodManager.saveFoodList(foods);
            listManager.saveShoppingList(shoppingList);
            StringReader foodReader = new StringReader(name);
            Console.SetIn(foodReader);
            listManager.addFood("");

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);
            //act
            recipeManager.addToShoppingList();

            //assert
            recipe = recipeManager.GetRecipe(name);
            Assert.IsNotNull(recipe.Foods.First());
            recipeManager.deleteRecipe(name);
            listManager.deleteShoppingList("");
            foodManager.deleteFood(name);
        }
    }
}
