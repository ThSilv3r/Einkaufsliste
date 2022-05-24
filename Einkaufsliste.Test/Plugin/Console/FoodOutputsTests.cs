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
using System.Diagnostics;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class FoodOutputsTest
    {
        FoodOutputRepository foodOutput;
        ReadValuesRepository readValues;
        [TestInitialize]
        public void Startup()
        {
            foodOutput = new FoodOutputs();
            readValues = new ReadValues();
        }
        [TestMethod]
        public void WeightMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Please enter the weight of the food.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                foodOutput.enterWeightMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void PriceMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Please enter the Price of the food.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                foodOutput.enterPriceMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void WiteFoodTest()
        {
            //arrange
            Food food = new Food
            {
                Name = "Apple",
                Price = new Price { price = 1.50},
                Weight = 100
            };
            string output = "";
            string expected = "Name: " + food.Name + " Price: " + food.Price + " Weight: " + food.Weight + "\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                foodOutput.writeFood(food);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void ChooseFoodMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Choose the food:\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                foodOutput.chooseFoodMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void NoFoodWarningTest()
        {
            //arrange
            string output = "";
            string expected = "Please add foods to the food list first.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                foodOutput.noFoodWarning();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
