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
using System.Linq;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class UserInputsTest
    {
        UserInputs userInputs;
        [TestInitialize]
        public void Startup()
        {
            userInputs = new UserInputs();
        }
        [TestMethod]
        public void getNameTest()
        {
            //arrange
            string output = "";
            string expected = "TestName";

            StringReader stringReader = new StringReader(expected);
            Console.SetIn(stringReader);
            //act


            output = userInputs.getName();

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void getPriceTest()
        {
            //arrange
            Price expectedPrice = new Price
            {
                price = 10
            };

            StringReader stringReader = new StringReader(expectedPrice.price.ToString());
            Console.SetIn(stringReader);
            //act


            Price price = userInputs.getPrice();

            //assert
            Assert.AreEqual(expectedPrice.price, price.price);
        }
        [TestMethod]
        public void chooseFoodsTest()
        {
            //arrange
            string output = "";
            string expected = "Test";
            List<Food> expectedFoods = new List<Food>();
            Food food = new Food
            {
                Id = Guid.NewGuid(),
                Name = expected,
                Price = new Price { price = 1},
                Weight = 1
            };
            expectedFoods.Add(food);

            StringReader stringReader = new StringReader(expected);
            Console.SetIn(stringReader);
            //act


            List<Food> foods = userInputs.chooseFoods(expectedFoods);

            //assert
            Assert.AreEqual(expectedFoods.Last().Id, foods.Last().Id);
        }
    }
}
