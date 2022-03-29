using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class FluentFood
    {
        public Food food = new Food();

        public FluentFood NameOfTheFood(string name)
        {
            food.Name = name;
            return this;
        }

        public FluentFood PriceOfTheFood(double price)
        {
            food.Price = price;
            return this;
        }

        public FluentFood WeightOfTheFood(int weight)
        {
            food.Weight = weight;
            return this;
        }
    }
}
