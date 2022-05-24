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
            foodManager = new FoodManager(foodPlugin, foodOutput, outputValues, readValues);
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
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);
            //act
            foodManager.createFood("Apple");

            //assert
            List<Food> foods = foodPlugin.getFoodList();
            Food food = foods.Find(x => x.Name == apple.Name);
            Assert.AreEqual(apple.ToString(), food.ToString());
            foodPlugin.deleteFood(apple.Name);
        }
        [TestMethod]
        public void CreateFoodNoName()
        {
            //arrange
            expectedFoods.Add(apple);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);
            //act
            foodManager.createFood("");

            //assert
            List<Food> foods = foodPlugin.getFoodList();
            Food food = foods.Find(x => x.Name == null);
            Assert.IsNull(food);
            foodPlugin.deleteFood(null);
        }
        [TestMethod]
        public void ReadFoodListTest()
        {
            //arrange
            string output;
            List<Food> foods = new List<Food>();
            foods.Add(apple);
            string expected = "Name: Apple Price: 0 Weight: 0\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                foodManager.readFoodList(foods);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void ReadNullFoodListTest()
        {
            //arrange
            string output;
            List<Food> foods = new List<Food>();
            foods.Add(apple);
            foodPlugin.saveFood(foods);
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                foodManager.readFoodList();
                output = sw.ToString();
            }

            //assert
            Assert.IsNotNull(output);
            foodPlugin.deleteFood(apple.Name);
        }
        [TestMethod]
        public void GetFoodByIdTest()
        {
            //arrange
            string output;
            List<Food> foods = new List<Food>();
            foods.Add(apple);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);
            foodPlugin.saveFood(foods);
            //act
            var food = foodManager.getFoodById(apple.Id);

            //assert
            Assert.AreEqual(apple.Id, food.Id);
            foodPlugin.deleteFood(apple.Name);
        }
    }
}
