using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Adapters
{
    public class FoodViewAdapter
    {
        FoodManager foodManager = new FoodManager();
        public Food createFood(string name, int weight, Price price)
        {
            return foodManager.createFood(name, weight, price);
        }
        public Food getFoodById(Guid foodId, List<Food> foods)
        {
            return foodManager.getFoodById(foodId, foods);
        }
    }
}
