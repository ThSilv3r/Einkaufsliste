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

namespace Einkaufsliste.Test
{
    [TestClass]
    public class FoodTest
    {
        FoodRepository foodManager;
        FoodPluginRepository foodPlugin;
        Food apple;
        List<Food> expectedFoods;
        [TestInitialize]
        public void Startup()
        {
            foodPlugin = new FoodPlugin();
            foodManager = new FoodManager();
            apple = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price{price = 0},
                Weight = 0
            };
            expectedFoods = foodPlugin.getFoodList();
        }
        [TestMethod]
        public void CreateFood()
        {
            //arrange

            //act
            Food food = foodManager.createFood(apple.Name, apple.Weight, apple.Price);

            //assert
            Assert.AreEqual(apple.ToString(), food.ToString());
        }
        [TestMethod]
        public void CreateFoodNoName()
        {
            //arrange
            expectedFoods.Add(apple);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);
            //act
            Food food = foodManager.createFood("", apple.Weight, apple.Price);

            //assert
            Assert.IsNull(food);
        }
        [TestMethod]
        public void GetFoodByIdTest()
        {
            //arrange
            string output;
            List<Food> foods = new List<Food>();
            foods.Add(apple);
            //act
            var food = foodManager.getFoodById(apple.Id, foods);

            //assert
            Assert.AreEqual(apple.Id, food.Id);
        }
    }
}
