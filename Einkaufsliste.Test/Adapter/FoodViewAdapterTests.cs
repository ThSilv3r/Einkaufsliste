using Einkaufsliste.Adapters;
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
    public class FoodViewAdapterTest
    {
        FoodViewAdapter foodAdapter;
        Food apple;
        [TestInitialize]
        public void Startup()
        {
            foodAdapter = new FoodViewAdapter();
            apple = new Food
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = new Price{price = 1},
                Weight = 0
            };
        }
        [TestMethod]
        public void CreateFoodTest()
        {
            //arrange

            //act
            Food food = foodAdapter.createFood(apple.Name, apple.Weight, apple.Price);

            //assert
            Assert.AreEqual(apple.Name, food.Name);
        }
        [TestMethod]
        public void GetFoodByIdTest()
        {
            //arrange
            List<Food> foods = new List<Food>();
            foods.Add(apple);
            //act
            Food food = foodAdapter.getFoodById(apple.Id, foods);

            //assert
            Assert.AreEqual(apple.ToString(), food.ToString());
        }
    }
}
