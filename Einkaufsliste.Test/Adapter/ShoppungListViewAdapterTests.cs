using Einkaufsliste.Adapters;
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
using System.Linq;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class ShoppingListViewAdapterTest
    {
        ShoppingListAdapter listAdapter;
        Food apple;
        ShoppingList list;
        Product handy;
        [TestInitialize]
        public void Startup()
        {
            listAdapter = new ShoppingListAdapter();
            apple = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price{price = 1},
                Weight = 0
            };
            handy = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Handy",
                Price = new Price { price = 1 },
            };
            list = new ShoppingList
            {
                Id = Guid.NewGuid(),
                Name = "TestListe",
                Foods = new List<Guid>(),
                Products = new List<Guid>()
            };
        }
        [TestMethod]
        public void CreateShoppingList()
        {
            //arrange

            //act
            ShoppingList shoppingList = listAdapter.createShoppingList(list.Name);

            //assert
            Assert.AreEqual(list.Name, shoppingList.Name);
        }
        [TestMethod]
        public void AddFoodToShoppingListTest()
        {
            //arrange

            //act
            ShoppingList shoppingList = listAdapter.addFoodToShoppingList(list, apple.Id);

            //assert
            Assert.AreEqual(apple.Id, shoppingList.Foods.Last());
        }
        [TestMethod]
        public void AddProductToShoppingListTest()
        {
            //arrange

            //act
            ShoppingList shoppingList = listAdapter.addProductToShoppingList(list, handy.Id);

            //assert
            Assert.AreEqual(handy.Id, shoppingList.Products.Last());
        }
    }
}
