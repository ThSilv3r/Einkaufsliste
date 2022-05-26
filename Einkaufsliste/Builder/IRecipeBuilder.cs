using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public interface IRecipeBuilder
    {
        void BuildName(string name);
        void BuildDescription(string description);
        void BuildFoods(List<Guid> foodIds);
        void BuildId(Guid guid);
        Recipe GetRecipe();
    }
}
