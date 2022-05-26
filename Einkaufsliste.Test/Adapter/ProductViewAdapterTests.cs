using Einkaufsliste.Adapters;
using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using Einkaufsliste.Test.Adapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class ProductViewAdapterTest
    {
        ProductViewAdapterMock productAdapterMock;
        Product handy;
        [TestInitialize]
        public void Startup()
        {
            productAdapterMock = new ProductViewAdapterMock();
            handy = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Handy",
                Price = new Price{price = 1},
            };
        }
        [TestMethod]
        public void CreateProductTest()
        {
            //arrange

            //act
            Product product = productAdapterMock.createProduct(handy.Name, handy.Price);

            //assert
            Assert.AreEqual(product.Name, product.Name);
        }
        [TestMethod]
        public void GetProductByIdTest()
        {
            //arrange
            List<Product> products = new List<Product>();
            products.Add(handy);
            //act
            Product product = productAdapterMock.getProductById(handy.Id, products);

            //assert
            Assert.AreEqual(handy.ToString(), product.ToString());
        }
    }
}
