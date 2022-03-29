using Einkaufsliste.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class ShoppingListTest
    {
        private string path;
        private ShoppingListManager listManager;
        [TestInitialize]
        public void Startup()
        {
            path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\ShoppingLists\";
            listManager = new ShoppingListManager();
        }
        [TestMethod]
        public void CreateList()
        {
            //arrange
            string name = "TestListe";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            //act
            listManager.createShoppingList();

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void CreateListNoName()
        {
            //arrange
            string name = "";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            //act
            listManager.createShoppingList();

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsFalse(exists);
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void SaveList()
        {
            //arrange
            ShoppingList shoppingList = new ShoppingList { 
                Name = "TestListe" 
            };

            //act
            listManager.saveShoppingList(shoppingList);

            //assert
            bool exists = File.Exists(path + shoppingList.Name + ".json");
            Assert.IsTrue(exists);
            listManager.deleteShoppingList(shoppingList.Name);
        }
        [TestMethod]
        public void AddProduct()
        {
            //arrange
            ShoppingList shoppingList = new ShoppingList();
            ProductManager productManager = new ProductManager();
            string name = "TestListe";
            Product expectedProduct = new Product
            {
                Name = "Test",
                Price = 0
            };
            StringReader nameReader = new StringReader("Test");
            Console.SetIn(nameReader);
            productManager.createProduct();

            nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            listManager.createShoppingList();
            shoppingList = listManager.getShoppingList(name);

            //act
            nameReader = new StringReader("Test");
            Console.SetIn(nameReader);

            listManager.addProduct(name);

            //assert
            ShoppingList list = listManager.getShoppingList(name);
            Product product = list.Products.Find(x => x.Name == expectedProduct.Name);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            productManager.deleteProduct("Test");
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void AddFood()
        {
            //arrange
            ShoppingList shoppingList = new ShoppingList();
            FoodManager foodManager = new FoodManager();
            string name = "TestListe";
            Food expectedFood = new Food
            {
                Name = "Test",
                Price = 0,
                Weight = 0
            };
            StringReader nameReader = new StringReader("Test");
            Console.SetIn(nameReader);
            foodManager.createFood();

            nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            listManager.createShoppingList();
            shoppingList = listManager.getShoppingList(name);

            //act
            nameReader = new StringReader("Test");
            Console.SetIn(nameReader);

            listManager.addFood(name);

            //assert
            ShoppingList list = listManager.getShoppingList(name);
            Food food = list.Foods.Find(x => x.Name == expectedFood.Name);
            Assert.AreEqual(expectedFood.Name, food.Name);
            foodManager.deleteFood("Test");
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void GetShoppingList()
        {
            //arrange
            string name = "TestListe";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            listManager.createShoppingList();

            //act
            ShoppingList shoppingList = listManager.getShoppingList(name);

            //assert
            Assert.AreEqual(name, shoppingList.Name);
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void DeleteShoppingList()
        {
            //arrange
            string name = "TestListe";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            listManager.createShoppingList();

            //act
            listManager.deleteShoppingList(name);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsFalse(exists);
        }
    }
}
