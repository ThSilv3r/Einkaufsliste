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
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\ShoppingLists\";
        [TestMethod]
        public void CreateListTest()
        {
            //arrange
            ShoppingListManager listManager = new ShoppingListManager();
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
        public void SaveListTest()
        {
            //arrange
            ShoppingListManager listManager = new ShoppingListManager();
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
            ShoppingListManager listManager = new ShoppingListManager();
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
            shoppingList = listManager.GetShoppingList(name);

            //act
            nameReader = new StringReader("Test");
            Console.SetIn(nameReader);

            listManager.addProduct(name);

            //assert
            ShoppingList list = listManager.GetShoppingList(name);
            Product product = list.Products.Find(x => x.Name == expectedProduct.Name);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            productManager.deleteProduct("Test");
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void AddFood()
        {
            //arrange
            ShoppingListManager listManager = new ShoppingListManager();
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
            shoppingList = listManager.GetShoppingList(name);

            //act
            nameReader = new StringReader("Test");
            Console.SetIn(nameReader);

            listManager.addFood(name);

            //assert
            ShoppingList list = listManager.GetShoppingList(name);
            Food food = list.Foods.Find(x => x.Name == expectedFood.Name);
            Assert.AreEqual(expectedFood.Name, food.Name);
            foodManager.deleteFood("Test");
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void GetShoppingList()
        {
            //arrange
            ShoppingListManager listManager = new ShoppingListManager();
            string name = "TestListe";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            listManager.createShoppingList();

            //act
            ShoppingList shoppingList = listManager.GetShoppingList(name);

            //assert
            Assert.IsNotNull(shoppingList);
            listManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void DeleteShoppingList()
        {
            //arrange
            ShoppingListManager listManager = new ShoppingListManager();
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
