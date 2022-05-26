using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class RecipeEngineer
    {
        private IRecipeBuilder recipeBuilder;

        public RecipeEngineer(IRecipeBuilder recipeBuilder)
        {
            this.recipeBuilder = recipeBuilder;
        }

        public Recipe GetRecipe()
        {
            return recipeBuilder.GetRecipe();
        }

        public void constructRecipe(string name, string desc, List<Guid> foods)
        {
            this.recipeBuilder.BuildName(name);
            this.recipeBuilder.BuildFoods(foods);
            this.recipeBuilder.BuildDescription(desc);
            this.recipeBuilder.BuildId(Guid.NewGuid());
        }
    }
}
