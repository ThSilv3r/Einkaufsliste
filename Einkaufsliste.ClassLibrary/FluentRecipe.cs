using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class FluentRecipe
    {
        public Recipe recipe = new Recipe();

        public FluentRecipe NameOfTheRecipe(string name)
        {
            recipe.Name = name;
            return this;
        }
        public FluentRecipe FoodOfTheRecipe(List<Food> foods)
        {
            recipe.Foods = foods;
            return this;
        }
        public FluentRecipe DescOfTheRecipe(string desc)
        {
            recipe.Description = desc;
            return this;
        }
    }
}
