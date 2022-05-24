using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Repository.Plugin.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.ConsolePlugins
{
    public class FoodOutputs : FoodOutputRepository
    {
        public void enterWeightMessage()
        {
            Console.WriteLine("Please enter the weight of the food.");
        }
        public void enterPriceMessage()
        {
            Console.WriteLine("Please enter the Price of the food");
        }
        public void writeFood(Food food)
        {
            Console.WriteLine("Name: " + food.Name + " Price: " + food.Price + " Weight: " + food.Weight);
        }
        public void chooseFoodMessage()
        {
            Console.WriteLine("Choose the food:");
        }
        public void noFoodWarning()
        {
            Console.WriteLine("Please add foods to the food list first.");
        }
    }
}
