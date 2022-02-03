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
        [TestMethod]
        public void CreateProduct()
        {
            //arrange
            ProductManager productManager = new ProductManager();
            Product handy = new Product
            {
                Name = "Handy",
                Price = 0
            };
            List<Product> expectedProducts = productManager.getProductList();
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
        public void DeleteProduct()
        {
            //arrange
            ProductManager productManager = new ProductManager();
            Product handy = new Product
            {
                Name = "Handy",
                Price = 100
            };
            List<Product> expectedProducts = productManager.getProductList();
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
