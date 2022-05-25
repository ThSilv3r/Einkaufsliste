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
        void BuildName(string name = null);
        void BuildWeight(int weight = 0);
        void BuildPrice(Price price = null);
        void BuildId(Guid guid);
        Food GetFood();
    }
}
