using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class FoodBuilder : IFoodBuilder 
    {
        private Food food;
        public FoodBuilder()
        {
            food = new Food();
        }
        public void BuildId(Guid guid)
        {
            food.Id = guid;
        }
        public void BuildName(string name)
        {
            food.Name = name;
        }

        public void BuildPrice(Price price)
        {
            food.Price = price;
        }

        public void BuildWeight(int weight)
        {
            food.Weight = weight;
        }
        public Food GetFood()
        {
            return food;
        }
    }
}
