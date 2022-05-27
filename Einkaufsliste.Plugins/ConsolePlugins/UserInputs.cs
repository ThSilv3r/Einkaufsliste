using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Plugins.ConsolePlugins
{
    public class UserInputs
    {
        ReadValues  readValues = new ReadValues();
        OutputValues outputValues = new OutputValues();
        public string getName()
        {
            outputValues.enterNameMessage();
            string name = readValues.ReadString();
            return name;
        }
        public Price getPrice()
        {
            Price price = new Price();
            Console.WriteLine("Please enter the price.");
            double priceDouble = readValues.ReadDouble();
            price.price = priceDouble;
            return price; 
        }
        public List<Food> chooseFoods(List<Food> foodList)
        {
            string foodString = "";
            List<Food> foods = new List<Food>();
            Food addedFood = new Food();
            foreach (var fd in foodList)
            {
                Console.WriteLine(fd.Name);
            }
            while (foodString != null && foodString != "q")
            {
                foodString = getName();
                if (foodString != null && foodString != "q")
                {
                    addedFood = foodList.FirstOrDefault(f => f.Name == foodString);
                    if (addedFood != null)
                    {
                        foods.Add(addedFood);
                    }
                    outputValues.closeEntryMessage();
                }
            }
            return foods;
        }
    }
}
