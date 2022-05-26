using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class FoodBuilder : IFoodBuilder
    {
        private Food food;
        public FoodBuilder()
        {
            food = new Food();
        }
        public void BuildFoodId(Guid guid)
        {
            food.Id = guid;
        }
        public void BuildFoodName(string name)
        {
            food.Name = name;
        }

        public void BuildFoodPrice(Price price)
        {
            food.Price = price;
        }

        public void BuildFoodWeight(int weight)
        {
            food.Weight = weight;
        }
        public Food GetFood()
        {
            return food;
        }
    }
}
