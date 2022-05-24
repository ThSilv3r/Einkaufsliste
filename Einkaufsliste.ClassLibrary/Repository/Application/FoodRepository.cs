using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface FoodRepository
    {
        void createFood(string name);
        void readFoodList();
    }
}
