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
    public class JsonFoodTest
    {
        FoodRepository foodManager;
        FoodPluginRepository foodPlugin;
        Food apple;
        List<Food> expectedFoods;
        ReadValuesRepository readValues;
        FoodOutputRepository foodOutput;
        OutputValuesRepository outputValues;
        [TestInitialize]
        public void Startup()
        {
            readValues = new ReadValues();
            foodOutput = new FoodOutputs();
            outputValues = new OutputValues();
            foodPlugin = new FoodPlugin();
            foodManager = new FoodManager();
            apple = new Food
            {
                Name = "Apple",
                Price = new Price{price = 0},
                Weight = 0
            };
            expectedFoods = foodPlugin.getFoodList();
        }

        [TestMethod]
        public void SaveFood()
        {
            //arrange
            expectedFoods.Add(apple);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);

            //act
            foodPlugin.saveFood(expectedFoods);

            //assert
            List<Food> foods = foodPlugin.getFoodList();
            Food food = foods.Find(x => x.Name == apple.Name);
            Assert.AreEqual(apple.ToString(), food.ToString());
            foodPlugin.deleteFood(apple.Name);
        }
        [TestMethod]
        public void GetFood()
        {
            //arrange
            List<Food> foods = expectedFoods;
            foods.Add(apple);
            foodPlugin.saveFood(foods);

            //act
            var foodList = foodPlugin.getFoodList();

            //assert
            Assert.AreEqual(expectedFoods.Last().Name, foodList.Last().Name);
            foodPlugin.deleteFood(apple.Name);
        }

        [TestMethod]
        public void DeleteFood()
        {
            //arrange
            List<Food> foods = expectedFoods;
            foods.Add(apple);
            foodPlugin.saveFood(foods);

            //act
            foodPlugin.deleteFood(apple.Name);

            //assert
            Assert.AreEqual(expectedFoods, foods);
        }
    }
}
