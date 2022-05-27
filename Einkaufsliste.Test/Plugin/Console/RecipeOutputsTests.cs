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
    public class RecipeOutputsTest
    {
        IRecipeOutput recipeOutput;
        [TestInitialize]
        public void Startup()
        {
            recipeOutput = new RecipeOutputs();
        }
        [TestMethod]
        public void ListNameMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Enter the name of the shoppinglist.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                recipeOutput.enterListNameMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void RecipeNameMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Enter the recipe name.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                recipeOutput.enterRecipeNameMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void FoodsMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Foods:\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                recipeOutput.foodsMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void DescriptionMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Please enter the description:\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                recipeOutput.enterDescriptionMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
