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
        ShoppingList shoppingList;
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
            shoppingListPlugin = new ShoppingListPlugin();
            shoppingListOutputRepository = new ShoppingListOutputs();
            foodManager = new FoodManager();
            productManager = new ProductManager();
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

            listManager.addProduct(shoppingList, expectedProduct.Id);

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

            listManager.addFood(shoppingList, expectedFood.Id);

            //assert
            Guid foodId = shoppingList.Foods.Find(x => x == expectedFood.Id);
            Assert.AreEqual(expectedFood.Id, foodId);
            shoppingList.Foods.Remove(expectedFood.Id);
        }
        //[TestMethod]
        //public void ReadProductListTest()
        //{
        //    //arrange
        //    string output;
        //    string name = "Test";
        //    List<Product> products = new List<Product>();
        //    List<Food> foods = new List<Food>();
        //    Food food = new Food
        //    {
        //        Name = name,
        //        Price = new Price { price = 0},
        //        Weight = 1
        //    };
        //    Product product = new Product
        //    {
        //        Name = name,
        //        Price = new Price { price = 0 }
        //    };
        //    products.Add(product);
        //    foods.Add(food);
        //    ShoppingList shoppingList = new ShoppingList
        //    {
        //        Name = name,
        //        Foods = new List<Food>(),
        //        Products = new List<Product>()
        //    };
        //    shoppingListPlugin.saveShoppingList(shoppingList);
        //    string expected = "Products:\r\nFoods:\r\n";
        //    //act
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        Console.SetOut(sw);
        //        listManager.readShoppingList(shoppingList.Name);
        //        output = sw.ToString();
        //    }

        //    //assert
        //    Assert.AreEqual(expected, output);
        //    shoppingListPlugin.deleteShoppingList(shoppingList.Name);
        //}
    }
}
