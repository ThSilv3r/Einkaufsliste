using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public class RecipeBuilder : IRecipeBuilder
    {
        private Recipe recipe;
        public RecipeBuilder()
        {
            recipe = new Recipe();
        }

        public void BuildRecipeName(string name)
        {
            recipe.Name = name;
        }
        public void BuildRecipeFoods(List<Guid> foodIds)
        {
            recipe.Foods = foodIds;
        }
        public void BuildRecipeId(Guid guid)
        {
            recipe.Id = guid;
        }
        public void BuildRecipeDescription(string desc)
        {
            recipe.Description = desc;
        }
        public Recipe GetRecipe()
        {
            return recipe;
        }
    }
}
