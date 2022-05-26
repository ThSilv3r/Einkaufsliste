using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Domaine.Aggregate;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using Einkaufsliste.Plugins.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class ShoppingListViewTest
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\ShoppingLists\";
        ShoppingListView shoppingListView;
        ShoppingListPlugin shoppingListPlugin;
        FoodPlugin foodPlugin;
        ProductPlugin productPlugin;
        Food food;
        Product product;
        [TestInitialize]
        public void Startup()
        {
            shoppingListView = new ShoppingListView();
            shoppingListPlugin = new ShoppingListPlugin();
            foodPlugin = new FoodPlugin();
            productPlugin = new ProductPlugin();
            food = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = new Price { price = 1},
                Weight = 1
            };
            product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = new Price { price = 1}
            };
        }

        [TestMethod]
        public void createShoppingListTest()
        {
            //arrange
            string name = "TestListe";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            //act
            shoppingListView.createShoppingList();

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            shoppingListPlugin.deleteShoppingList(name);
        }
        [TestMethod]
        public void ReadShoppingListTest()
        {
            //arrange
            string name = "TestListe";
            string output = "";
            string expected = "Please enter a name.\r\nProducts:\r\nFoods:\r\n";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);

            shoppingListView.createShoppingList();

            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                stringReader = new StringReader(name);
                Console.SetIn(stringReader);
                shoppingListView.readShoppingList();
                output = sw.ToString();


                //assert
                Assert.AreEqual(expected, output);
                shoppingListPlugin.deleteShoppingList(name);
            }
        }

        [TestMethod]
        public void AddFoodToShoppingListTest()
        {
            //arrange
            string name = "Test";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);
            shoppingListView.createShoppingList();
            List<Food> foods = new List<Food>();
            foods.Add(food);
            foodPlugin.saveFoodList(foods);

            stringReader = new StringReader(name);
            Console.SetIn(stringReader);
            //act
            shoppingListView.addFoodToShoppingList(name);

            //assert
            ShoppingList shoppingList = shoppingListPlugin.getShoppingList(name);
            Assert.AreEqual(shoppingList.Foods.First(), food.Id);
            foodPlugin.deleteFood(food.Name);
            shoppingListPlugin.deleteShoppingList(name);
        }
        [TestMethod]
        public void AddProductToShoppingListTest()
        {
            //arrange
            string name = "Test";
            StringReader stringReader = new StringReader(name);
            Console.SetIn(stringReader);
            shoppingListView.createShoppingList();
            List<Product> products = new List<Product>();
            products.Add(product);
            productPlugin.saveProductList(products);

            stringReader = new StringReader(name);
            Console.SetIn(stringReader);
            //act
            shoppingListView.addProductToShoppingList(name);

            //assert
            ShoppingList shoppingList = shoppingListPlugin.getShoppingList(name);
            Assert.AreEqual(shoppingList.Products.First(), product.Id);
            productPlugin.deleteProduct(product.Name);
            shoppingListPlugin.deleteShoppingList(name);
        }
    }
}
