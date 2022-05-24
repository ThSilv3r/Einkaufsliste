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
    public class JsonShoppingListTest
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
