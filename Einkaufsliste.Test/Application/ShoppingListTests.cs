using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Domaine.Aggregate;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
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
        IShoppingListManager listManager;
        ShoppingList shoppingList;
        [TestInitialize]
        public void Startup()
        {
            path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\ShoppingLists\";
            listManager = new ShoppingListManager();
            shoppingList = new ShoppingList
            {
                Name = "Test",
                Foods = new List<Guid>(),
                Products = new List<Guid>(),
                Id = Guid.NewGuid()
            };
        }
        [TestMethod]
        public void CreateList()
        {
            //arrange
            string name = "TestListe";

            //act
            ShoppingList shoppingList = listManager.createShoppingList(name);

            //assert
            Assert.IsNotNull(shoppingList);
        }
        [TestMethod]
        public void CreateListNoName()
        {
            //arrange
            string name = "";

            //act
            ShoppingList shoppingList = listManager.createShoppingList(name);


            //assert
            Assert.IsNull(shoppingList);
        }
        [TestMethod]
        public void AddProduct()
        {
            //arrange
            string name = "TestListe";
            string productName = "Test";
            Product expectedProduct = new Product
            {
                Name = "Test",
                Price = new Price { price = 0},
                Id = Guid.NewGuid()
            };

            //act

            listManager.addProductToShoppingList(shoppingList, expectedProduct.Id);

            //assert
            Guid productId = shoppingList.Products.Find(x => x == expectedProduct.Id);
            Assert.AreEqual(expectedProduct.Id, productId);
            shoppingList.Products.Remove(expectedProduct.Id);
        }
        [TestMethod]
        public void AddFood()
        {
            //arrange
            string name = "TestListe";
            string foodName = "Test";
            Food expectedFood = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price { price = 0 },
                Weight = 0
            };

            //act

            listManager.addFoodToShoppingList(shoppingList, expectedFood.Id);

            //assert
            Guid foodId = shoppingList.Foods.Find(x => x == expectedFood.Id);
            Assert.AreEqual(expectedFood.Id, foodId);
            shoppingList.Foods.Remove(expectedFood.Id);
        }
    }
}
