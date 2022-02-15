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
        [TestMethod]
        public void CreateFood()
        {
            //arrange
            FoodManager foodManager = new FoodManager();
            Food apple = new Food
            {
                Name = "Apple",
                Price = 0,
                Weight = 0
            };
            List<Food> expectedFoods = foodManager.getFoodList();
            expectedFoods.Add(apple);

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
        public void GetProduct()
        {
            //arrange
            FoodManager foodManager = new FoodManager();
            Food apple = new Food
            {
                Name = "Apple",
                Price = 0,
                Weight = 0
            };
            List<Food> expectedFoods = foodManager.getFoodList();
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
        public void DeleteProduct()
        {
            //arrange
            FoodManager foodManager = new FoodManager();
            Food apple = new Food
            {
                Name = "Apple",
                Price = 0,
                Weight = 0
            };
            List<Food> expectedFoods = foodManager.getFoodList();
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
