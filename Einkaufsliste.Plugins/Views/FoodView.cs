using Einkaufsliste.Adapters;
using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.ValueObject;
using Einkaufsliste.Plugins.ConsolePlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.Views
{
    public class FoodView
    {
        FoodOutputs foodOutputs = new FoodOutputs();
        ReadValues readValues = new ReadValues();
        FoodPlugin foodPlugin = new FoodPlugin();
        FoodViewAdapter foodViewAdapter = new FoodViewAdapter();
        UserInputs userInputs = new UserInputs();
        public void createFood()
        {
            Price price = new Price();
            double priceDouble;
            int weight;
            string name; 
            List<Food> foods = foodPlugin.getFoodList();

            name = userInputs.getName();

            price = userInputs.getPrice();

            foodOutputs.enterWeightMessage();
            weight = readValues.ReadInt();

            Food food = foodViewAdapter.createFood(name, weight, price);
            foodOutputs.writeFood(food);
            foods.Add(food);
            foodPlugin.saveFoodList(foods);
        }

        public void readFoodList(List<Food> foods = null)
        {
            if (foods == null)
            {
                foods = foodPlugin.getFoodList();
            }
            foreach (Food food in foods)
            {
                foodOutputs.writeFood(food);
            }
        }
    }
}
