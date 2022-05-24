using Einkaufsliste.ClassLibrary.Entity.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class RecipeBuilder : IRecipeBuilder
    {
        private Recipe recipe;
        public RecipeBuilder()
        {
            recipe = new Recipe();
        }

        public void BuildName(string name)
        {
            recipe.Name = name;
        }
        public void BuildFoods(List<Food> foods)
        {
            recipe.Foods = foods;
        }
        public void BuildId(Guid guid)
        {
            recipe.Id = guid;
        }
        public void BuildDescription(string desc)
        {
            recipe.Description = desc;
        }
        public Recipe GetRecipe()
        {
            return recipe;
        }
    }
}
