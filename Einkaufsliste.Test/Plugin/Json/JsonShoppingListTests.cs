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
    public class JsonShoppingListTest
    {
        IShoppingListManager listManager;
        ShoppingListPluginRepository shoppingListPlugin;
        [TestInitialize]
        public void Startup()
        {
            shoppingListPlugin = new ShoppingListPlugin();
            listManager = new ShoppingListManager();
        }
        [TestMethod]
        public void SaveList()
        {
            //arrange
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\ShoppingLists\";
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

            ShoppingList expectedShoppingList = listManager.createShoppingList(name);
            shoppingListPlugin.saveShoppingList(expectedShoppingList);

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
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\ShoppingLists\";
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
