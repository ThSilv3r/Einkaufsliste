using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    internal interface IRecipeBuilder
    {
        void BuildName(string name);
        void BuildDescription(string description);
        void BuildFoods(List<Food> foods);
        void BuildId(Guid guid);
        Recipe GetRecipe();
    }
}
