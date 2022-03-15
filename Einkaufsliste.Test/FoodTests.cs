using Einkaufsliste.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Einkaufsliste.Test
{
    [TestClass]
    public class FoodTest
    {
        private FoodManager foodManager;
        private Food apple;
        private List<Food> expectedFoods;
        [TestInitialize]
        public void Startup()
        {
            foodManager = new FoodManager();
            apple = new Food
            {
                Name = "Apple",
                Price = 0,
                Weight = 0
            };
            expectedFoods = foodManager.getFoodList();
        }
        [TestMethod]
        public void CreateFood()
        {
            //arrange
            StringReader nameReader = new StringReader("Apple");
            Console.SetIn(nameReader);

            //act
            foodManager.createFood();

            //assert
            List<Food> foods = foodManager.getFoodList();
            Food food = foods.Find(x => x.Name == apple.Name);
            Assert.AreEqual(apple.ToString(), food.ToString());
            foodManager.deleteFood(apple.Name);
        }
        [TestMethod]
        public void CreateFoodNoName()
        {
            //arrange
            expectedFoods.Add(apple);

            StringReader nameReader = new StringReader("");
            Console.SetIn(nameReader);

            //act
            foodManager.createFood();

            //assert
            List<Food> foods = foodManager.getFoodList();
            Food food = foods.Find(x => x.Name == null);
            Assert.IsNull(food);
            foodManager.deleteFood(null);
        }

        [TestMethod]
        public void GetFood()
        {
            //arrange
            expectedFoods.Add(apple);

            StringReader nameReader = new StringReader("Apple");
            Console.SetIn(nameReader);

            //act
            foodManager.createFood();

            //assert
            List<Food> foods = foodManager.getFoodList();
            Food food = foods.Find(x => x.Name == apple.Name);
            foodManager.deleteFood(apple.Name);
            Assert.AreEqual(apple.ToString(), food.ToString());
        }

        [TestMethod]
        public void DeleteFood()
        {
            //arrange
            List<Food> foods = expectedFoods;
            foods.Add(apple);
            foodManager.saveFoodList(foods);

            //act
            foodManager.deleteFood(apple.Name);

            //assert
            Assert.AreEqual(expectedFoods, foods);
        }
    }
}
