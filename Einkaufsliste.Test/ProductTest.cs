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
    public class ProductTest
    {
        ProductRepository productManager;
        ProductPluginRepository productPlugin;
        ReadValuesRepository readValues;
        OutputValuesRepository outputValues;
        ProductOutputRepository productOutputRepository;
        Product handy;
        List<Product> expectedProducts;
        [TestInitialize]
        public void Startup()
        {
            readValues = new ReadValues();
            outputValues = new OutputValues();
            productOutputRepository = new ProductOutputs();
            productPlugin = new ProductPlugin();
            productManager = new ProductManager(productPlugin, readValues, outputValues, productOutputRepository);
            handy = new Product
            {
                Name = "Handy",
                Price = new Price {price = 0 }
            };
            expectedProducts = productPlugin.getProductList();
        }
        [TestMethod]
        public void CreateProduct()
        {
            //arrange
            expectedProducts.Add(handy);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);

            //act
            productManager.createProduct("Handy");

            //assert
            List<Product> products = productPlugin.getProductList();
            Product product = products.Find(x => x.Name == handy.Name);
            productPlugin.deleteProduct(handy.Name);
            Assert.AreEqual(handy.ToString(), product.ToString());
        }

        [TestMethod]
        public void CreateProductNoName()
        {
            //arrange
            expectedProducts.Add(handy);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);

            //act
            productManager.createProduct("");

            //assert
            List<Product> products = productPlugin.getProductList();
            Product product = products.Find(x => x.Name == null);
            Assert.IsNull(product);
            productPlugin.deleteProduct(null);
        }
        [TestMethod]
        public void DeleteProduct()
        {
            //arrange
            List<Product> products = expectedProducts;
            products.Add(handy);
            productPlugin.saveProductList(products);
            StringReader priceReader = new StringReader("");
            Console.SetIn(priceReader);

            //act
            productPlugin.deleteProduct(handy.Name);

            //assert
            Assert.AreEqual(expectedProducts, products);
        }
    }
}
