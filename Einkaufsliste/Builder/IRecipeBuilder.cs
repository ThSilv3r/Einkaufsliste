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
        void BuildRecipeName(string name);
        void BuildRecipeDescription(string description);
        void BuildRecipeFoods(List<Guid> foodIds);
        void BuildRecipeId(Guid guid);
        Recipe GetRecipe();
    }
}
