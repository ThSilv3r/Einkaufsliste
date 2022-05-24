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
    public class ShoppingListTest
    {
        private string path;
        ShoppingListRepository listManager;
        ShoppingListPluginRepository shoppingListPlugin;
        ProductPluginRepository productPlugin;
        FoodRepository foodManager;
        ProductRepository productManager;
        ShoppingListOutputRepository shoppingListOutputRepository;
        FoodPluginRepository foodPlugin;
        ReadValuesRepository readValues;
        FoodOutputRepository foodOutput;
        OutputValuesRepository outputValues;
        ProductOutputRepository productOutput;
        [TestInitialize]
        public void Startup()
        {
            path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\ShoppingLists\";
            readValues = new ReadValues();
            foodOutput = new FoodOutputs();
            productOutput = new ProductOutputs();
            outputValues = new OutputValues();
            foodPlugin = new FoodPlugin();
            productPlugin = new ProductPlugin();
            foodPlugin = new FoodPlugin();
            foodManager = new FoodManager(foodPlugin, foodOutput, outputValues, readValues);
            productManager = new ProductManager(productPlugin, readValues, outputValues, productOutput);
            shoppingListPlugin = new ShoppingListPlugin();
            listManager = new ShoppingListManager(shoppingListPlugin, outputValues, 
                productOutput, foodOutput, shoppingListOutputRepository, readValues, productPlugin, foodManager);
        }
        [TestMethod]
        public void CreateList()
        {
            //arrange
            string name = "TestListe";

            //act
            listManager.createShoppingList(name);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsTrue(exists);
            shoppingListPlugin.deleteShoppingList(name);
        }
        [TestMethod]
        public void CreateListNoName()
        {
            //arrange
            string name = "";

            //act
            listManager.createShoppingList(name);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsFalse(exists);
            shoppingListPlugin.deleteShoppingList(name);
        }
        [TestMethod]
        public void SaveList()
        {
            //arrange
            ShoppingList shoppingList = new ShoppingList { 
                Name = "TestListe" 
            };

            //act
            shoppingListPlugin.saveShoppingList(shoppingList);

            //assert
            bool exists = File.Exists(path + shoppingList.Name + ".json");
            Assert.IsTrue(exists);
            shoppingListPlugin.deleteShoppingList(shoppingList.Name);
        }
        [TestMethod]
        public void AddProduct()
        {
            //arrange
            ShoppingList shoppingList = new ShoppingList();
            string name = "TestListe";
            string productName = "Test";
            Product expectedProduct = new Product
            {
                Name = "Test",
                Price = new Price { price = 0}
            };
            StringReader nameReader = new StringReader(name);
            Console.SetIn(nameReader);
            productManager.createProduct(productName);

            listManager.createShoppingList(name);
            shoppingList = shoppingListPlugin.getShoppingList(name);

            //act
            nameReader = new StringReader(productName);
            Console.SetIn(nameReader);

            listManager.addProduct(name);

            //assert
            ShoppingList list = shoppingListPlugin.getShoppingList(name);
            Product product = list.Products.Find(x => x.Name == expectedProduct.Name);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            productPlugin.deleteProduct(productName);
            shoppingListPlugin.deleteShoppingList(name);
        }
        [TestMethod]
        public void AddFood()
        {
            //arrange
            ShoppingList shoppingList = new ShoppingList();
            string name = "TestListe";
            string foodName = "Test";
            Food expectedFood = new Food
            {
                Name = foodName,
                Price = new Price { price = 0},
                Weight = 0
            };
            StringReader nameReader = new StringReader(foodName);
            Console.SetIn(nameReader);
            foodManager.createFood(foodName);

            listManager.createShoppingList(name);
            shoppingList = shoppingListPlugin.getShoppingList(name);

            //act
            nameReader = new StringReader(foodName);
            Console.SetIn(nameReader);

            listManager.addFood(name);

            //assert
            ShoppingList list = shoppingListPlugin.getShoppingList(name);
            Food food = list.Foods.Find(x => x.Name == expectedFood.Name);
            Assert.AreEqual(expectedFood.Name, food.Name);
            foodPlugin.deleteFood(foodName);
            shoppingListPlugin.deleteShoppingList(name);
        }
        [TestMethod]
        public void GetShoppingList()
        {
            //arrange
            string name = "TestListe";

            listManager.createShoppingList(name);

            //act
            ShoppingList shoppingList = shoppingListPlugin.getShoppingList(name);

            //assert
            Assert.AreEqual(name, shoppingList.Name);
            shoppingListPlugin.deleteShoppingList(name);
        }
        [TestMethod]
        public void DeleteShoppingList()
        {
            //arrange
            string name = "TestListe";

            listManager.createShoppingList(name);

            //act
            shoppingListPlugin.deleteShoppingList(name);

            //assert
            bool exists = File.Exists(path + name + ".json");
            Assert.IsFalse(exists);
        }
    }
}
