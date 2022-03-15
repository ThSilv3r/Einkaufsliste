using Einkaufsliste.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class ProductTest
    {
        private ProductManager productManager;
        private Product handy;
        private List<Product> expectedProducts;
        [TestInitialize]
        public void Startup()
        {
            productManager = new ProductManager();
            handy = new Product
            {
                Name = "Handy",
                Price = 0
            };
            expectedProducts = productManager.getProductList();
        }
        [TestMethod]
        public void CreateProduct()
        {
            //arrange
            expectedProducts.Add(handy);

            StringReader nameReader = new StringReader("Handy");
            Console.SetIn(nameReader);

            //StringReader priceReader = new StringReader("100");
            //Console.SetIn(priceReader);

            //act
            productManager.createProduct();

            //assert
            List<Product> products = productManager.getProductList();
            Product product = products.Find(x => x.Name == handy.Name);
            productManager.deleteProduct(handy.Name);
            Assert.AreEqual(handy.ToString(), product.ToString());
        }

        [TestMethod]
        public void CreateProductNoName()
        {
            //arrange
            expectedProducts.Add(handy);

            StringReader nameReader = new StringReader("");
            Console.SetIn(nameReader);

            //act
            productManager.createProduct();

            //assert
            List<Product> products = productManager.getProductList();
            Product product = products.Find(x => x.Name == null);
            Assert.IsNull(product);
            productManager.deleteProduct(null);
        }
        [TestMethod]
        public void DeleteProduct()
        {
            //arrange
            List<Product> products = expectedProducts;
            products.Add(handy);
            productManager.saveProductList(products);

            //act
            productManager.deleteProduct(handy.Name);

            //assert
            Assert.AreEqual(expectedProducts, products);
        }
    }
}
