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
            ShoppingListManager shoppingListManager = new ShoppingListManager();
            string name = "TestListe";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            //act
            shoppingListManager.createShoppingList();

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            shoppingListManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void SaveListTest()
        {
            //arrange
            ShoppingListManager shoppingListManager = new ShoppingListManager();
            ShoppingList shoppingList = new ShoppingList { 
                Name = "TestListe" 
            };

            //act
            shoppingListManager.saveShoppingList(shoppingList);

            //assert
            bool exists = File.Exists(path + shoppingList.Name + ".json");
            Assert.IsTrue(exists);
            shoppingListManager.deleteShoppingList(shoppingList.Name);
        }
        [TestMethod]
        public void AddProduct()
        {
            //arrange

            //act

            //assert
        }
        [TestMethod]
        public void AddFood()
        {
            //arrange

            //act

            //assert
        }
        [TestMethod]
        public void GetShoppingList()
        {
            //arrange
            ShoppingListManager shoppingListManager = new ShoppingListManager();
            string name = "TestListe";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            shoppingListManager.createShoppingList();

            //act
            ShoppingList shoppingList = shoppingListManager.GetShoppingList(name);

            //assert
            Assert.IsNotNull(shoppingList);
            shoppingListManager.deleteShoppingList(name);
        }
        [TestMethod]
        public void DeleteShoppingList()
        {
            //arrange
            ShoppingListManager shoppingListManager = new ShoppingListManager();
            string name = "TestListe";

            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);

            shoppingListManager.createShoppingList();

            //act
            shoppingListManager.deleteShoppingList(name);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsFalse(exists);
        }
    }
}
