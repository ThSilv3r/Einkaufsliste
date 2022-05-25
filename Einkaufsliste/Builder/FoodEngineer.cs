using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class FoodEngineer
    {
        private IFoodBuilder foodBuilder;

        public FoodEngineer(IFoodBuilder foodBuilder)
        {
            this.foodBuilder = foodBuilder;
        }

        public Food GetProduct()
        {
            return foodBuilder.GetFood();
        }

        public void constructProduct(string name = null, int Weight = 0, Price price = null)
        {
            this.foodBuilder.BuildName(name);
            this.foodBuilder.BuildWeight(Weight);
            this.foodBuilder.BuildPrice(price);
            this.foodBuilder.BuildId(Guid.NewGuid());
        }

    }
}
