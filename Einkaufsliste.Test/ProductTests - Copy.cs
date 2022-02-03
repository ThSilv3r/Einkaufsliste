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
            Food apfel = new Food
            {
                Name = "Apfel",
                Price = 0,
                Weight = 0
            };
            List<Food> expectedFoods = foodManager.getFoodList();
            expectedFoods.Add(apfel);

            StringReader nameReader = new StringReader("Apfel");
            Console.SetIn(nameReader);

            //act
            foodManager.createFood();

            //assert
            List<Food> foods = foodManager.getFoodList();
            Food food = foods.Find(x => x.Name == apfel.Name);
            foodManager.deleteFood(apfel.Name);
            Assert.AreEqual(apfel.ToString(), food.ToString());
        }

        [TestMethod]
        public void DeleteProduct()
        {
            //arrange
            FoodManager foodManager = new FoodManager();
            Food apfel = new Food
            {
                Name = "Apfel",
                Price = 0,
                Weight = 0
            };
            List<Food> expectedFoods = foodManager.getFoodList();
            List<Food> foods = expectedFoods;
            foods.Add(apfel);
            foodManager.saveFoodList(foods);

            //act
            foodManager.deleteFood(apfel.Name);

            //assert
            Assert.AreEqual(expectedFoods, foods);
        }
    }
}
