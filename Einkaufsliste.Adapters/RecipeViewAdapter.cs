using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Adapters
{
    public class RecipeViewAdapter
    {
        RecipeManager recipeManager = new RecipeManager();
        public Recipe createRecipe(string name, List<Guid> foodIds, string desc)
        {
            return recipeManager.createRecipe(name, foodIds, desc);
        }
        public Recipe addFood(Recipe recipe, Guid foodId)
        {
            return recipeManager.addFood(recipe, foodId);
        }
        public ShoppingList addToShoppingList(Recipe recipe, ShoppingList list)
        {
            return recipeManager.addToShoppingList(recipe, list);
        }
    }
}
