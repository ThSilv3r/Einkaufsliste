using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class FoodManager : IFoodManager
    {
        Food food;
        FoodBuilder foodBuilder;
        FoodEngineer foodEngineer;
        public Food createFood(string name, int weight, Price price)
        {
            food = new Food();
            FoodBuilder foodBuilder = new FoodBuilder();
            FoodEngineer foodEngineer = new FoodEngineer(foodBuilder);
            if(name != null && name != "")
            {
                foodEngineer.constructFood(name, weight, price);
                food = foodEngineer.GetProduct();
                return food;
            }
            return null;
        }

        public Food getFoodById(Guid guid, List<Food> foods)
        {
            Food food = foods.Find(x => x.Id == guid);
            return food;
        }
    }
}
