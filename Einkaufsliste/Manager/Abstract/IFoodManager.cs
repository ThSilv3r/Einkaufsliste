using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Manager.Abstract
{
    internal interface IFoodManager
    {
        void createFood();
        void deleteFood(string name);
        void saveFood(List<Food> foods);
        List<Food> getFoodList();
        void readFoodList();
    }
}
