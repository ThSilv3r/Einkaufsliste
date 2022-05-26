using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface FoodRepository
    {
        Food createFood(string name, int weight, Price price);
        Food getFoodById(Guid guid, List<Food> foods);
    }
}
