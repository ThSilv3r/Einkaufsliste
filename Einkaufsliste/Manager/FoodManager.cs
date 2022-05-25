using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class FoodManager : FoodRepository
    {
        //ReadValuesRepository readValues;
        //FoodOutputRepository foodOutputs;
        //OutputValuesRepository outputValues;
        //FoodPluginRepository foodPlugin;
        //public FoodManager(FoodPluginRepository foodPlugin, FoodOutputRepository foodOutput,
        //    OutputValuesRepository outputValues, ReadValuesRepository readValues)
        //{
        //    this.foodPlugin = foodPlugin;
        //    this.foodOutputs = foodOutput;
        //    this.outputValues = outputValues;
        //    this.readValues = readValues;
        //}
        Food food;
        FoodBuilder foodBuilder;
        FoodEngineer foodEngineer;
        public Food createFood(string name, int weight, Price price)
        {
            //Price price = new Price();
            //double priceDouble;
            //int weight;
            food = new Food();
            FoodBuilder foodBuilder = new FoodBuilder();
            FoodEngineer foodEngineer = new FoodEngineer(foodBuilder);
            //List<Food> foods = foodPlugin.getFoodList();

            //foodOutputs.enterPriceMessage();
            //priceDouble = readValues.ReadDouble();
            //price.price = priceDouble;

            //foodOutputs.enterWeightMessage();
            //weight = readValues.ReadInt();
            if(name != null && name != "")
            {
                foodEngineer.constructProduct(name, weight, price);
                food = foodEngineer.GetProduct();
                return food;
                //foodOutputs.writeFood(food);

                //foods.Add(food);

                //foodPlugin.saveFood(foods);
            }
            return null;
        }
       

        //public void readFoodList(List<Food> foods = null)
        //{
        //    if(foods == null)
        //    {
        //        foods = foodPlugin.getFoodList();
        //    }
        //    foreach(Food food in foods)
        //    {
        //        foodOutputs.writeFood(food);
        //    }
        //}

        public Food getFoodById(Guid guid, List<Food> foods)
        {
            //List<Food> foods = foodPlugin.getFoodList();
            Food food = foods.Find(x => x.Id == guid);
            return food;
        }
    }
}
