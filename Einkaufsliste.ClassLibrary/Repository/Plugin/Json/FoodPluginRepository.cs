using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository.Plugin.Json
{
    public interface FoodPluginRepository
    {
        void saveFood(List<Food> foodList);
        List<Food> getFoodList();
        void deleteFood(string name);
    }
}
