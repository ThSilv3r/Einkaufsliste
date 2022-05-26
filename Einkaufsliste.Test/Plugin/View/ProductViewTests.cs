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
    public class ProductViewTest
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\";
        ProductPlugin productPlugin;
        ProductView productView;
        Product product;
        [TestInitialize]
        public void Startup()
        {
            productPlugin = new ProductPlugin();
            productView = new ProductView();
            product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = new Price { price = 1 }
            };
        }

        [TestMethod]
        public void createProductTest()
        {
            //arrange
            string name = "Test";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            //act
            productView.createProduct();

            //assert
            var products = productPlugin.getProductList();
            Assert.AreEqual(name, products.First().Name);
            productPlugin.deleteProduct(name);
        }
        [TestMethod]
        public void ReadProductTest()
        {
            //arrange
            string expected = "Name: Test Price: 0\r\n";
            string output = "";
            string name = "Test";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            productView.createProduct();

            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                stringReader = new StringReader(name);
                Console.SetIn(stringReader);
                productView.readProductList();
                output = sw.ToString();


                //assert
                Assert.AreEqual(expected, output);
                productPlugin.deleteProduct(name);
            }
        }
    }
}
