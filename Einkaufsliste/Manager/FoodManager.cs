using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Json;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Plugins;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Einkaufsliste
{
    public class FoodManager : FoodRepository
    {
        ReadValuesRepository readValues;
        FoodOutputRepository foodOutputs;
        OutputValuesRepository outputValues;
        FoodPluginRepository foodPlugin;
        public FoodManager(FoodPluginRepository foodPlugin, FoodOutputRepository foodOutput,
            OutputValuesRepository outputValues, ReadValuesRepository readValues)
        {
            this.foodPlugin = foodPlugin;
            this.foodOutputs = foodOutput;
            this.outputValues = outputValues;
            this.readValues = readValues;
        }
        public void createFood(string name)
        {
            Price price = new Price();
            double priceDouble;
            int weight;
            FluentFood food = new FluentFood();
            List<Food> foods = foodPlugin.getFoodList();

            foodOutputs.enterPriceMessage();
            priceDouble = readValues.ReadDouble();
            price.price = priceDouble;

            foodOutputs.enterWeightMessage();
            weight = readValues.ReadInt();
            if(name != null)
            {
                food.NameOfTheFood(name).PriceOfTheFood(price).WeightOfTheFood(weight).IdOfTheFood(Guid.NewGuid());

                Console.WriteLine(food);

                foods.Add(food.food);

                foodPlugin.saveFood(foods);
            }
        }
       

        public void readFoodList()
        {
            List<Food> foods = foodPlugin.getFoodList();
            foreach(Food food in foods)
            {
                foodOutputs.writeFood(food);
            }
        }

        public Food getFoodById(Guid guid)
        {
            List<Food> foods = foodPlugin.getFoodList();
            Food food = foods.Find(x => x.Id == guid);
            return food;
        }
    }
}
