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
        void BuildName(string name);
        void BuildWeight(int weight);
        void BuildPrice(Price price);
        void BuildId(Guid guid);
        Food GetFood();
    }
}
