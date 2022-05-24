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
    public class ProductOutputsTest
    {
        ProductOutputRepository productOutput;
        [TestInitialize]
        public void Startup()
        {
            productOutput = new ProductOutputs();
        }
        [TestMethod]
        public void priceMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Please enter the Price of the product.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                productOutput.enterPriceMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void writeProductTest()
        {
            //arrange
            Product product = new Product
            {
                Name = "Butter",
                Price = new Price { price = 2 }
            };
            string output = "";
            string expected = "Name: " + product.Name + " Price: " + product.Price.price + "\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                productOutput.writeProduct(product);
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void ChooseProductMessageTest()
        {
            //arrange
            string output = "";
            string expected = "Choose the product:\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                productOutput.chooseProductMessage();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void NoProductWarningTest()
        {
            //arrange
            string output = "";
            string expected = "Please add products to the product list first.\r\n";
            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                productOutput.noProductWarning();
                output = sw.ToString();
            }

            //assert
            Assert.AreEqual(expected, output);
        }
    }
}
