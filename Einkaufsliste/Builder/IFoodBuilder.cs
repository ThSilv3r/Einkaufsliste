using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public interface IFoodBuilder
    {
        void BuildFoodName(string name = null);
        void BuildFoodWeight(int weight = 0);
        void BuildFoodPrice(Price price = null);
        void BuildFoodId(Guid guid);
        Food GetFood();
    }
}
