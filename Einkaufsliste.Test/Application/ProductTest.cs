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
        Product handy;
        List<Product> expectedProducts;
        [TestInitialize]
        public void Startup()
        {
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
        public void CreateProduct()
        {
            //arrange
            expectedProducts.Add(handy);

            //act
            Product product = productManager.createProduct(handy.Name, handy.Price);

            //assert
            Assert.AreEqual(handy.ToString(), product.ToString());
        }

        [TestMethod]
        public void CreateProductNoName()
        {
            //arrange
            expectedProducts.Add(handy);

            //act
            Product product = productManager.createProduct("", handy.Price);

            //assert
            Assert.IsNull(product);
        }
        [TestMethod]
        public void GetProductByIdTest()
        {
            //arrange
            string output;
            List<Product> products = new List<Product>();
            products.Add(handy);
            //act
            var product = productManager.getProductById(handy.Id, products);

            //assert
            Assert.AreEqual(handy.Id, product.Id);
        }
    }
}
