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
        //[TestMethod]
        //public void ReadFoodListTest()
        //{
        //    //arrange
        //    string output;
        //    List<Food> foods = new List<Food>();
        //    foods.Add(apple);
        //    string expected = "Name: Apple Price: 0 Weight: 0\r\n";
        //    //act
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        Console.SetOut(sw);
        //        foodManager.readFoodList(foods);
        //        output = sw.ToString();
        //    }

        //    //assert
        //    Assert.AreEqual(expected, output);
        //}
        //[TestMethod]
        //public void ReadNullFoodListTest()
        //{
        //    //arrange
        //    string output;
        //    List<Food> foods = new List<Food>();
        //    foods.Add(apple);
        //    foodPlugin.saveFood(foods);
        //    //act
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        Console.SetOut(sw);
        //        foodManager.readFoodList();
        //        output = sw.ToString();
        //    }

        //    //assert
        //    Assert.IsNotNull(output);
        //    foodPlugin.deleteFood(apple.Name);
        //}
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
