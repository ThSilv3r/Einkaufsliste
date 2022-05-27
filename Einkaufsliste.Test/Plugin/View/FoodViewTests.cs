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
    public class FoodViewTest
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\";
        FoodPlugin foodPlugin;
        FoodView foodView;
        Food product;
        [TestInitialize]
        public void Startup()
        {
            foodPlugin = new FoodPlugin();
            foodView = new FoodView();
            product = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = new Price { price = 1 },
                Weight = 1
            };
        }

        [TestMethod]
        public void createFoodTest()
        {
            //arrange
            string name = "Test";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            //act
            foodView.createFood();

            //assert
            var foods = foodPlugin.getFoodList();
            Assert.AreEqual(name, foods.First().Name);
            foodPlugin.deleteFood(name);
        }
        [TestMethod]
        public void ReadProductTest()
        {
            //arrange
            string expected = "Name: Test Price: 0 Weight: 0\r\n";
            string output = "";
            string name = "Test";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            foodView.createFood();

            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                stringReader = new StringReader(name);
                Console.SetIn(stringReader);
                foodView.readFoodList();
                output = sw.ToString();


                //assert
                Assert.AreEqual(expected, output);
                foodPlugin.deleteFood(name);
            }
        }
    }
}
