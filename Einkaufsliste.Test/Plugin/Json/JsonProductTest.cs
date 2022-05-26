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
    public class JsonProductTest
    {
        IProductManager productManager;
        ProductPluginRepository productPlugin;
        IReadValues readValues;
        IOutputValues outputValues;
        IProductOutput productOutputRepository;
        Product handy;
        List<Product> expectedProducts;
        [TestInitialize]
        public void Startup()
        {
            readValues = new ReadValues();
            outputValues = new OutputValues();
            productOutputRepository = new ProductOutputs();
            productPlugin = new ProductPlugin();
            productManager = new ProductManager();
            handy = new Product
            {
                Name = "Handy",
                Price = new Price {price = 0 }
            };
            expectedProducts = productPlugin.getProductList();
        }
        [TestMethod]
        public void SaveFood()
        {
            //arrange
            expectedProducts.Add(handy);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);

            //act
            productPlugin.saveProductList(expectedProducts);

            //assert
            List<Product> products = productPlugin.getProductList();
            Product product = products.Find(x => x.Name == handy.Name);
            Assert.AreEqual(handy.ToString(), product.ToString());
            productPlugin.deleteProduct(handy.Name);
        }
        [TestMethod]
        public void GetFood()
        {
            //arrange
            List<Product> foods = expectedProducts;
            foods.Add(handy);
            productPlugin.saveProductList(foods);

            //act
            var products = productPlugin.getProductList();

            //assert
            Assert.AreEqual(expectedProducts.Last().Name, products.Last().Name);
            productPlugin.deleteProduct(handy.Name);
        }
        [TestMethod]
        public void DeleteProduct()
        {
            //arrange
            List<Product> products = expectedProducts;
            products.Add(handy);
            productPlugin.saveProductList(products);

            //act
            productPlugin.deleteProduct(handy.Name);

            //assert
            Assert.AreEqual(expectedProducts, products);
        }
    }
}
